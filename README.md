# PruebaTecnicaOnOff

PruebaTecnicaOnOff
Descripción
PruebaTecnicaOnOff es una aplicación diseñada para la asignación de numeros de 5 ditgitos para sorteos o rifas de los clientes que usan la API.

Arquitectura
El proyecto sigue una arquitectura por capas para promover la separación de preocupaciones y la modularidad. Las capas principales son:

Capa de API: Contiene el controlador de Web API para gestionar las solicitudes HTTP entrantes y dirigirlas a los servicios correspondientes. También incluye la lógica de autenticación por ApiKey.
Capa de Aplicación: Contiene la lógica de aplicación, incluidos los servicios que implementan las reglas de negocio específicas de la aplicación.
Capa de Core: Contiene las entidades y abstracciones comunes utilizadas en toda la aplicación.
Capa de Infraestructura: Contiene implementaciones concretas de repositorios y otros componentes de infraestructura, así como configuraciones relacionadas con la base de datos.

Estructura del proyecto:

PruebaTecnicaOnOff/
│
├── Api/
│   ├── Controllers/
│   │   └── PremioSorteoController.cs
│   ├── Auth/
│   │   └── ApiKeyMiddleware.cs
│   └── Program.cs
│
├── Application/
│   ├── Servicios/
│   │   └── IPremioSorteoService.cs
│   └── IServicios/
│       └── PremioSorteoService.cs
│
├── Core/
│   ├── Entities/
│   │   └── NumeroAsignado.cs
│   └── Entities/
│       └── PremioSorteo.cs
│
└── Infrastructure/
    ├── Context/
    │   └── PruebaTecnicaOnOffContext.cs
    ├── IRepositorio/
    │   ├── IPremioSorteoRepository.cs
    │   └── NumeroAsignadoRepository.cs
    └── Repositorio/
        └── PremioSorteoRepository.cs


Uso
Para ejecutar el proyecto, sigue estos pasos:

Clona este repositorio en tu máquina local.
Abre el proyecto en Visual Studio.
Asegúrate de tener instalado el SDK de .NET 8.
Ejecuta el archivo sql "QUERY PRUEBA TECNICA ONOFF" en un motor de base de datos sql server.
Ejecuta la aplicación y accede a través de tu navegador o herramienta de prueba de API favorita.

