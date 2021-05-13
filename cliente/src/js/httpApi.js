const url = 'https://localhost:44323/'

export async function get(path){
    let res = await fetch(url+path)
    if(res.ok){
        let result = await res.json()
        return Promise.resolve(result)
    }
    return Promise.reject('Error al obtener informacion de', url)
}

export async function post(path, data){
    let res = await fetch(url+path,{
        method: 'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    }).catch(err => {
        console.log(err)
    })
}

export async function destroy(path){
    try{
        let res = await fetch(url+path, {
            method: 'delete',
        })
        if(res.ok){
            return Promise.resolve(res)
        }
    }catch(err){
        return Promise.reject('Error al hacer delete sobre ', url)
    }
}