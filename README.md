<p align="center">
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://i.imgur.com/6wj0hh6.jpg" alt="Project logo"></a>
</p>

<h3 align="center">Todo APP</h3>

<div align="center">

[![Status](https://img.shields.io/badge/status-active-success.svg)]()
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](/LICENSE)

</div>

---

<p align="center"> Solución para gestionar tareas por hacer (TODO)
    <br> 
</p>

## 📝 Contenidos

- [Sobre el proyecto](#about)
- [Instrucciones](#getting_started)
- [API REST](#api_rest)
- [ReactJs Front](#front_end)
- [Built Using](#built_using)
- [Authors](#authors)
- [Acknowledgments](#acknowledgement)

## 🧐 Sobre el proyecto <a name = "about"></a>

Solución para gestionar tareas por hacer (TODO). La solución está compuesta por dos proyectos (uno para el back-end y otro para el front-end):
+ TodoAppSvc: El back-end es una API REST web service creada usando .NET Core 2.0 que tiene a disponibilidad los distintos verbos que va a consumir el front-end. 
+ TodoAppWeb: El front-end es un proyecto de ReactJs creado usando el template de VS2019. 


## 🏁 Instrucciones <a name = "getting_started"></a>

Estas instrucciones le proporcionarán una copia del proyecto en funcionamiento en su máquina local para fines de desarrollo y prueba. En el README.md no se abarca el deploy.

### Requisitos

Requesitos para instalar el software y cómo instalarlas.

```
+ Microsoft Visual Studio Community 2017 o superior
+ Microsoft SQL Server 2008 o superior
+ .NET Core 2.0
```

### Instalación

Pasos a seguir para ejecutar la solución:
1. Obtener el proyecto de git:

```
git clone https://github.com/paulofer85/TodoApp.git
```
2. Abrir ´MS SQL Server Management Studio´ y ejecutar el archivo 'TodoAPP-Create.sql'
3. Abrir proyecto en VS2017 (o superior).
4. Setear como proyecto por default a TodoAppSvc.
5. Ejecutar la solución y dejar ejecutandola.
6. Abrir una consola de comandos (cmd o pm) y ejecutar la solución de front-end:

```
C:\>cd \TodoApp\TodoApp\TodoAppWeb\ClientApp
C:\TodoApp\TodoApp\TodoAppWeb\ClientApp>npm start
```

# API REST <a name = "api_rest"></a>

Los verbos disponibles son:
  - http://localhost:49791/api/todoes (GET): devuelve todos los TODO
  - http://localhost:49791/api/todoes (POST): crea un nuevo TODO
  - http://localhost:49791/api/todoes/byFilter?descripcion:#PAR1&estatus:#PAR2 (GET): busca los TODO segun la descripcion de #PAR1 y el estatus #PAR2
  - http://localhost:49791/api/todoes/#ID (GET): permite cambiar el estado de un TODO


## 🔧 Running the tests <a name = "tests"></a>

Explain how to run the automated tests for this system.


## Test de la API REST via Postman

Se adjunta dentro de la solución un set de pruebas (TodoApp.postman_collection.json) que pueden ser importados a Postman y ejecutados para probar cada uno de los verbos.


# ReactJs Front-end <a name = "front_end"></a>

Para mas información por favor ver el README.md que se encuentra presente dentro de la carpeta del proyecto front-end \TodoAppWeb\ClientApp.

## 🚀 Deployment <a name = "deployment"></a>

TODO

## ⛏️ Built Using <a name = "built_using"></a>

- [ReactJs](https://www.reactjs.org/) - Front-end
- [.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) - Server API WEB Framework
- [NodeJs](https://nodejs.org/en/) - Server Environment

## ✍️ Authors <a name = "authors"></a>

- [@paulofer85](https://github.com/paulofer85) - Initial work
- [@MavHa] - Requerimientos

