1. Analice estos nombres de URLs y exponga si son correctas o no y por qué.

* PUT /users/56/edit ❌ => No se debe usar el verbo edit.
* GET /user/56 => ❌ user está en singular y debería estar en plural.
* DELETE /users/ => 🤔 es "correcta". Quiere decir borrar todos los usuarios, pero es rara, ya que dependería del contexto borrar todos los usuarios sería algo correcto o no. Normalmente los usuarios se borrarían de uno en uno.
* GET /users/56 => ✔️
* PUT /user/45 => ❌ user está en singular y debería estar en plural
* POST /users/create => ❌ no se debe usar el verbo create.
* POST /user/create => ❌ user está en singular y debería estar en plural y no se debe usar el verbo create.
* GET /users/56/invoice => invoice está en singular y no en plural.
* PUT /users/34 => ✔️
* POST /users/54 => ❌ la creación del usuario no debería llevar ID.
* DELETE /users/delete/43 => ❌ no debería tener el verbo delete.
* GET /users/page/2 => ❌ page=2 debería estar en el QueryString.
* GET /users/654/image.png => ❌ el formato debería ir en la cabecera, por lo que .png no es correcto.
* GET /users?page=2?order=DESC => ❌ la ? solo se pone la primera vez. Las demás veces se concatenan los parámetros con &.
* GET /users/invoice/67/3 => ❌ invoice está en singular y debería estar en plural. 
* GET /users?page=2 => ✔️
* GET /users?page=2&order=ASC => ✔️