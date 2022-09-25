### CLIENTES:

* GET /customers?page={pagevalue}
* GET /customers/{id}
* PUT /customers/{customerid}
* DELETE /customers/{customerid}
* POST /customers | BODY: { name: string, dni: string, image: bytes[] } => 200 OK, 412 (si no hay ni imagen o nombre o dni)

### VIAJES:

* GET /customers/{id}/travels
* POST /customers/{id}/travels | BODY: { day: date, route: route, window: boolean, table: boolean, water: boolean }

### RUTAS:

* GET /routes => RESPONSE { window: boolean, table: boolean, water: boolean }
* GET /routes/{id}/passengers { numberOfSeat: number, dni: string }

** Todo depende del contexto, por lo que puede haber muchos tipos de soluciones diferentes.