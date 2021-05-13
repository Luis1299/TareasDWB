import React, { useEffect, useState } from 'react'
import { destroy, get, post } from '../js/httpApi'

export default function CustomerScreen(){

    const [data, setData] = useState([])
    const [nuevoCliente, setNuevoCliente] = useState({
        customerId: '',
        companyName: '',
        contactName: '',
        phone: '',
        country: '',
        city: '',
        address: ''
    })

    function updateData(){
        get('api/customer').then(
            res => {
                setData(res)
            }
        )
    }

    async function addCustomer(e){
        e.preventDefault()
        console.log(nuevoCliente)
        await post('api/customer', nuevoCliente)
        updateData()
    }

    async function destroyCustomer(customer){
        try{
            await destroy('api/Customer/'+customer.customerId)
            alert("Cliente con id: "+ customer.customerId +" eliminado")
            updateData()
        }catch(err){
            alert("No se pudo borrar el cliente con id: "+ customer.customerId)
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
                    <h3><a className="uk-button uk-button-secondary" href="/Employees">Empleados</a></h3>
                    </nav>
                </div>
            </div>

            <h3 className="uk-heading-divider">Nuevo Cliente</h3>
            <form>
                <div className="uk-margin">
                     <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="ID" onChange={e => setNuevoCliente({...nuevoCliente, customerId: e.target.value})}/>
                    </div>
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Nombre de la compañia" onChange={e => setNuevoCliente({...nuevoCliente, companyName: e.target.value})}/>
                    </div>
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Contacto" onChange={e => setNuevoCliente({...nuevoCliente, contactName: e.target.value})}/>
                    </div>
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Telefono" onChange={e => setNuevoCliente({...nuevoCliente, phone: e.target.value})}/>
                    </div>
                    <div className="uk-margin">
                        <select className="uk-select" onChange={e => setNuevoCliente({...nuevoCliente, country: e.target.value})}>
                            <option>Mexico</option>
                            <option>USA</option>
                            <option>UK</option>
                            <option>Germany</option>
                            <option>Sweden</option>
                            <option>France</option>
                            <option>Canada</option>
                            <option>Spain</option>
                            <option>Switzerland</option>
                        </select>
                    </div>
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Ciudad" onChange={e => setNuevoCliente({...nuevoCliente, city: e.target.value})}/>
                    </div>
                    <div className="uk-margin">
                        <input type="text" className="uk-input" placeholder="Direccion" onChange={e => setNuevoCliente({...nuevoCliente, address: e.target.value})}/>
                    </div>
                </div>
                <div className="uk-margin">
                    <button 
                        className="uk-button uk-button-primary" 
                        style={{backgroundColor: "green"}}
                        onClick={addCustomer}
                        >
                        Agregar Cliente
                    </button>
                </div>
            </form>

            <h3 className="uk-heading-divider">Tabla Clientes</h3>

            <table className="uk-table uk-table-divider uk-table-middle uk-table-striped">
                <thead className="uk-table-head">
                    <tr>
                        <th>Id</th>
                        <th>Compañia</th>
                        <th>Contacto</th>
                        <th>Telefono</th>
                        <th>Pais</th>
                        <th>Ciudad</th>
                        <th>Direccion</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                {
                    data.map((customer, index) => (
                        <tr key={index}>
                            <td>{customer.customerId}</td>
                            <td>{customer.companyName}</td>
                            <td>{customer.contactName}</td>
                            <td>{customer.phone}</td>
                            <td>{customer.country}</td>
                            <td>{customer.city}</td>
                            <td>{customer.address}</td>
                            <td><button className="uk-button uk-button-danger" onClick={_=>destroyCustomer(customer)}>Borrar</button></td>
                        </tr>
                    ))
                }
                </tbody>
            </table>
        </div>
    )
}