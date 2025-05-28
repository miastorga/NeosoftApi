En mi caso ejecute un contedor con la base de datos con el comando
docker run --detach --name some-mariadb -p 3306:3306 --env MARIADB_USER=example-user --env MARIADB_PASSWORD=my_cool_secret --env MARIADB_DATABASE=exmple-database --env MARIADB_ROOT_PASSWORD=my-secret-pw mariadb:latest
y configure la connection string como dice el punto n3

1. Glonar el repositorio
2. Ir a la carpeta del proyecto
3. Configurar la conexion a la base de datos en el appsetting.Develooment
4. Instalar/Restaurar las dependencias NuGet con dotnet restore
5. Aplicar las migraciones con 'dotnet ef database udpate'
6. Ejecutar la api en modo debug o on dotnet run. Deberia ejecutarse en el puerto "5191". Si no se ejecuta en ese puerto, cambiarlo en lauchSetting, ya que el frontend hace las peticiones a "http://localhost:5191"

Intente hacer funcionar el docker compose pero no me funciono,
si ustedes pueden revisar asi se les facilita la revision.
