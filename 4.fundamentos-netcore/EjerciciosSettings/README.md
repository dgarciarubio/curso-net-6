1. Crea un proyecto .Net Core con la plantilla de vacío que se llame ApiStructure, dentro de una solución SLN llamada MyProject
2. Cambia el puerto del perfil ApiStructure al 9449. Ejécuta la solución con ese perfil.
3. Añade en el appsettings.json un parametro "ProjectSettings" y dentro de este otro con "ProjectName" cuyo valor será "ApiStructure". Crea un endpoint en "/projectname" y que saque un string con el formato: "Hello {nombredelproyecto}".
4. Añade un fichero appsettings.staging.json donde el nombre del proyecto sea ApiStructureStaging. Ejecuta el proyecto en modo Staging y comprueba que ese es el nombre que usa ahora.
5. Usando el servicio IOptionsSnapshot, haz que el valor del ProjectName se pueda refrescar en caliente en los entornos que no sean de Producción. Para verlo, crea un endpoint que se llame "/projectsecret" y que en este endpoint devuelva un string con: "Hello {nombredelproyecto} con refresco". Comprueba que si cambias el json de appsettings.Development.json el valor sin parar la ejecución se refresca.
6. Genera los user secrets en el proyecto. Pon como user secrets el valor del nombre del proyecto a: "ApiStructureLocal".
7. Crea un endpoint en "/logTime" que registre la hora a la que fue llamado con la categoría "Logs.LogTime" y nivel "Warning". Comprueba los logs.
8. Eleva el nivel para la categoría Logs.LogTime a Information. Comprueba que no hay logs.
