import React, { useEffect, useState } from 'react'
import { destroy, get, post } from '../js/httpApi'

export default function EmployeeScreen(){

    const [data, setData] = useState([])
    const [nuevoEmpleado, setNuevoEmpleado] = useState({
        firstName: '',
        lastName: '',
        birthDate: '',
        country: '',
        address: ''
    })

    function updateData(){
        get('api/employee').then(
            res => {
                setData(res)
            }
        )
    }

    async function addEmployee(e){
        e.preventDefault()
        // console.log(nuevoEmpleado)
        await post('api/Employee', nuevoEmpleado)
        updateData()
    }

    async function destroyEmployee(e){
        try{
            await destroy('api/Employee/'+e.employeeId)
            alert("Empleado con id: "+e.employeeId +" eliminado")
            updateData()
        }catch(err){
            alert("No se pudo borrar el empleado con id: "+ e.employeeId)
        }
    } 

    useEffect(() => {
        updateData()
    }, [])

    return(
        <div className="uk-container uk-margin-top">
            <div className="uk-navbar">
                <div className="uk-navbar-left">
                    <h3 className="uk-margin-right">Cambiar Tabla:</h3>
                    <nav className="uk-navbar-nav">
                    <h3><a className="uk-button uk-button-secondary" href="/Customers">Clientes</a></h3>
                    </nav>
                </div>
            </div>


            <h3 className="uk-heading-divider">Nuevo Empleado</h3>
            <form>
                <div className="uk-margin">
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Nombre" onChange={e => setNuevoEmpleado({...nuevoEmpleado, firstName: e.target.value})}/>
                    </div>
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Apellido" onChange={e => setNuevoEmpleado({...nuevoEmpleado, lastName: e.target.value})}/>
                    </div>
                </div>
                <div className="uk-margin">
                    <input type="date" className="uk-input" placeholder="Fecha de nacimiento" onChange={e => setNuevoEmpleado({...nuevoEmpleado, birthDate: e.target.value})}/>
                </div>
                <div className="uk-margin">
                    <select className="uk-select" onChange={e => setNuevoEmpleado({...nuevoEmpleado, country: e.target.value})}>
                        <option>Mexico</option>
                        <option>USA</option>
                        <option>UK</option>
                    </select>
                </div>
                <div className="uk-margin">
                    <input type="text" className="uk-input" placeholder="Direccion" onChange={e => setNuevoEmpleado({...nuevoEmpleado, address: e.target.value})}/>
                </div>
                <div className="uk-margin">
                    <button 
                        className="uk-button uk-button-primary" 
                        style={{backgroundColor: "green"}}
                        onClick={addEmployee}
                        >
                        Agregar Empleado
                    </button>
                </div>
            </form>

            <h3 className="uk-heading-divider">Tabla Empleados</h3>
            <table className="uk-table uk-table-divider uk-table-middle uk-table-striped">
                <thead className="uk-table-head">
                    <tr className="">
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Fecha de nacimiento</th>
                        <th>Pais</th>
                        <th>Dirección</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        data.map((employee, key) => {
                            return(
                                <tr key={key}>
                                    <td>{employee.employeeId}</td>
                                    <td>{employee.firstName}</td>
                                    <td>{employee.lastName}</td>
                                    <td>{new Date(employee.birthDate).toLocaleDateString()}</td>
                                    <td>{employee.country || 'No data'}</td>
                                    <td>{employee.address || 'No data'}</td>
                                    <td><button className="uk-button uk-button-danger" onClick={_=>destroyEmployee(employee)}>Borrar</button></td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
        </div>
    )
}