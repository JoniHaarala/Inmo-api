<img src="Inmo API.png" alt="logo"/>

# Inmo  API

We have created this API to manage the information that we use in our project of a system for a real estate company. This project is for personal use since the company we refer to is not real so you are free to use this API for personal purposes or for small projects.
For now this is only a presentation file, that means ofcourse that i well agreggate in a future all the freatures to use this API thanks...


## Authors

- [@JoniHaarala](https://github.com/JoniHaarala)


## Contributing

Contributions are always welcome!

See `contributing.md` for ways to get started.

Please adhere to this project's `code of conduct`.


## FAQ

#### Its free to use?

Answer: YES. You can use this API for any kind of personal proyect or to practice api request. At the moment a token is not required to access the relevant information, but ho knows if it neads in future updates if all runs very well :) 


## Feedback

This is my first deployed API i made, so if you have any feedback or sugestion for the API documentation or have a problem, please reach out to us at jonatan.haaralaorosco@gmail.com


## License

[MIT](https://choosealicense.com/licenses/mit/)

## API Reference
- A continuacion se propone la documentacion para acceder a la API y a sus funcionalidades
- The following is the proposed documentation for accessing the API and its functionalities

 
### Para Factura

#### Get all bills
```http
  GET api/Factura/ListarFacturas
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | Get a list of all registered bills|


#### Get one bill
```http
  GET /api​/Factura​/ObtenerPorId​/{idFactura}
```
| Parameter   | Type  | Description                       |
| :---------- | :---- | :-------------------------------- |
| `idFactura` | `int` |Return all data from a unique Bill |
|             |       |**Required**. Id of item to fetch  |


#### Get all bills ID
```http
  GET /api​/Factura​/ListarIdFactura
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | Get the ID of all regsitered bills|


#### Save one bill
```http
  POST /api​/Factura​/GuardarFactura
```
| Parameter        | Type               | Description                |
| :--------------- | :----------------- | :------------------------- |
| `object{params}` | `json/application` | Post data from a new bill and returns a OK message|


#### Edit bill information
```http
  PUT /api​/Factura​/EditarFactura​/{idFactura}
```
| Parameter   | Type  | Description                |
| :---------- | :---- | :------------------------- |
| `idFactura` | `int` | EDIT the data of a bill using the ID|
|             |       |**Required**. Id of item to fetch  |


#### Edit bill Status
```http
  PUT /api​/Factura​/EditarEstado/{idFactura}
```
| Parameter   | Type  | Description                |
| :---------- | :---- | :------------------------- |
| `idFactura` | `int` | Edit the state of a bill using the ID |
|             |       |**Required**. Id of item to fetch  |


#### Delete bill
```http
  DELETE /api​/Factura​/Eliminar/{idFactura}
```
| Parameter   | Type     | Description                |
| :---------- | :------- | :------------------------- |
| `idFactura` | `string` | DELETE a specific bill based on his ID|
|             |          |**Required**. Id of item to fetch  |



## Para Banco

#### Get all Bank's
```http
  GET /api​/Banco​/ListarBancos
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | Get a list of all bank's   |


#### Get all account's
```http
  GET ​/api​/Banco​/ListarCuentas
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | Get a list of all account's|



## Para Proveedor

#### Get all Suppliers
```http
  GET /api/Proveedor/ListarProveedor
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | Get a list of all registered bills|



## Para los Inmuebles

#### Get all real estates
```http
  GET ​/api​/Inmueble​/Inmuebles
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | Get a list of all estates|


#### Get specific property
```http
  GET /api​/Inmueble​/GetInmueble​/{Idinmueble}
```
| Parameter    | Type     | Description                |
| :----------- | :------- | :------------------------- |
| `Idinmueble` | `string` | Get a list of one estate |
|              |          |**Required**. Id of item to fetch  |

## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)

[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)


## Tech Stack

**Server:** ASP.net Core 6, SQL Server 2019
