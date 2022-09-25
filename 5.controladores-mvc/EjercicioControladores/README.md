1. Crea un proyecto de API en NetCore 6 y configura Swagger en él.
2. Crea un controlador de Clientes. Los clientes tendrán los campos Id, Dni, Nombre, Apellidos, Edad, Genero, Email. Añade cuatro casos de ejemplo a la lista por defecto. En tu controlador crea endpoints para poder listar, editar, crear y borrar un cliente. Para hacer esto crea un servicio que sea singleton y tenga una lista de clientes como variable privada con la que jugar.
3. Añade un campo al cliente que sea FechaModificacion. No devuelvas ese campo en el API.
4. Añade en el appsettings el tamaño de pagina que quiere devolver el cliente. Modifica el endpoint de /customers, ahora pasa un parámetro <page> con la página que se quiere y devuelva esa página utilizando el tamaño de página del appsettings. Si el parámetro <page> no viene en la llamada, devuelve todos los clientes como antes.
5. Añade a la llamada de la lista el numero de clientes actuales para que el cliente pueda saber la cantidad de paginas que hay.
6. Cambia la respuesta del endpoint de clientes y en lugar de devolver la edad de los mismos, devuelve un booleano con la información de si es mayor de edad.
7. Cuando se consulte un cliente que no está en el sistema en el GET de un cliente con id, devuelve un 404.
8. Devuelve un 201 junto con el lugar donde puedes encontrar el usuario en la creación. Mira el método CreatedAt.
  * Ejemplo de la función CreatedAt: https://stackoverflow.com/questions/47939945/how-to-use-created-or-createdataction-createdatroute-in-an-asp-net-core-api
9. Valida que el DNI cumpla con el formato adecuado al crear o editar un cliente.
10. Valida que al menos se hayan introducido o nombre, o apellidos, al crear o editar un cliente.
