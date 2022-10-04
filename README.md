# AgencyCodaChallenge

Pasos para probar el codigo fuente
1. Clonar el proyecto en una carpeta local
2. Configurar la solución "AgencyCodaTest".
    a. En la propiedad de "Proyecto de Inicio" seleccionar "Proyectos de inicio múltiples"
    b. Seleccionar los proyectos "Api" y "WebSystem" con el valor de "Iniciar"
3. Configurar su usuario para que vincule con la Api y el WebSystem
    a. Configurar su usuario desde el portal de Azure.
        Instructivo https://www.youtube.com/watch?v=sRop37oQ_Hk&ab_channel=NotJustBI
    b. En el "Appsettings" que se encuentra en la ruta D:\GIT\AgencyCodaTest\WebApi\appsettings.json se debera cambiar los valores configurados en el portal de Azure
4. Correr la solución
5. Al iniciar la aplicación y posterior a autenticarse, brindarle los permisos a la misma para acceder al calendario.

Nota:
    Se puede usar como test del sistema el usuario creado para esta finalidad, cuyas credenciales se encuentran en el archivo "Credentials.txt"

    