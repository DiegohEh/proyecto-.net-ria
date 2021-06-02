- Primero lo clonas en una carpeta designada por ti
`git clone https://github.com/DiegohEh/proyecto-.net-ria.git`

- Muevete a ese directorio con el comando cd

- Luego te fijas si tienes una inicializacion de git
`git remote -v`

- Si no la tienes haz:
`1. git init`

`2. git remote add origin https://github.com/DiegohEh/proyecto-.net-ria`

----------------------------------------------------------------------------

- Para ver los cambios que hiciste:
`git status`

- Para añadir a un paquete esos cambios
`git add .`

- Para hacer COMMIT
`git commit -m "Breve mensaje diciendo que hiciste"`

- Para hacer PUSH
`git push origin main // Si main no es tu rama entonces cambialo a tu rama`

- Crear una nueva rama
`git branch eugenio`

- Ver lista de ramas
`git branch`

- Cambiar a una rama
`git checkout eugenio`

- Para Hacer PULL
`1. git fetch --all`

`2. git pull origin main`

- Si quieres empezar todo desde 0
`1. git fetch --all`

`2. git reset --hard origin/main`

----------------------------------------------------------------------------

Cambios a realizar en el proyecto: 

- Asegurarse de que su base se llame "BaseArticulos"
- Asegurarse de que sus tablas tengan los datos necesarios y se llamen "articulos" y "LogArticulos"

- Ir al archivo web.config(2.BackEnd\1.Services\InternalServices\Web.config), y reemplazar con sus datos las siguientes líneas:

`<add name="BdArticulos" connectionString="Initial Catalog=SuNombredeBaseAQUI;Data Source=SuNombredeServidorAQUI;Integrated Security=true"/>`

`<add name="TiendaDB" connectionString="metadata=res://*/Database.ModeloBD.csdl|res://*/Database.ModeloBD.ssdl|res://*/Database.ModeloBD.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=SuNombredeServidorAQUI;initial catalog=SuNombredeBaseAQUI;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />`

- Ir al archivo App.config(3.DataAccess\Persistencia\App.config), y reemplazar con sus datos las siguientes líneas:

`<add name="TiendaDB" connectionString="metadata=res://*/Database.ModeloBD.csdl|res://*/Database.ModeloBD.ssdl|res://*/Database.ModeloBD.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=SuNombredeServidorAQUI;initial catalog=SuNombredeBaseAQUI;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />`



— LUEGO DE REALIZAR ESTO, EL PROYECTO DEBERÍA FUNCIONAR — 
