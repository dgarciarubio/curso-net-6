1. Crea un proyecto .Net 6 con la plantilla de API Empty (API Vacía) que se llame ContactsProject, dentro de una solución SLN llamada CursoNet6
2. Añade una clase a tu proyecto que se llame, Contact que tendrá tres propiedades: Id (int), Name (string), TelephoneNumber (string). Crea una lista dentro del proyecto de contactos y añade a tu API los endpoints de:
* Obtener todos los contactos.
* Obtener un contacto pasando el Id
* Actualizar un contacto pasando el Id
* Crear un Nuevo Contacto
* Borrar un contacto pasando un Id
* Buscar un contacto pasando un patrón por el que buscar (por ejemplo si pasas "Ang" se buscarán todos los contactos que contengan en su nombre la cadena "ang")
3. Crea para tu API anterior un fichero json con Postman con todas las peticiones de tu API.