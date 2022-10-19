1. En el proyecto BusBookingApi de los módulos anteriores, emplea la librería [Mediatr](https://github.com/jbogard/MediatR) para mover la lógica de los servicios a un handler por cada caso de uso (endpoint).
    * Emplea [MediatR.Extensions.Microsoft.DependencyInjection](https://github.com/jbogard/MediatR.Extensions.Microsoft.DependencyInjection) para registrar los handlers en el contenedor de inyección de inyección de dependencias
    * Emplea CQRS para separar por completo la lógica de comandos y queries:
         * Dentro de cada carpeta de cada recurso, divide los handlers en carpetas distintas para commands y queries
         * No compartas lógica ni modelos de datos entre commands y queries.