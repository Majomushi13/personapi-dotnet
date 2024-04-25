# personaapi-dotnet

Este es un proyecto ASP.NET Core para manejar la API de personas.

## Requisitos

- Visual Studio o Rider instalado.
- .NET SDK 5.0 o superior instalado.
- Un servidor SQL Server disponible para conectar con la base de datos.

## Instrucciones de configuración

1. **Clona el repositorio:**
    ```bash
    git clone <URL_DEL_REPOSITORIO>
    cd personaapi-dotnet
    ```

2. **Elimina la carpeta `Migrations`:**
    Antes de continuar, elimina la carpeta `Migrations` del proyecto.

3. **Configura el `appsettings.json`:**
    Ve al archivo `appsettings.json` y edita la cadena de conexión (`Connection`) para apuntar a tu servidor SQL Server. Debes cambiar `LAPTOP-FELIPE` por el nombre de tu servidor, tal como en el ejemplo:
    ```json
    "Connection": "Server=LAPTOP-FELIPE;Database=Persona_db;Trusted_Connection=true;TrustServerCertificate=true"
    ```

4. **Crea una migración inicial:**
    Abre la Consola del Administrador de Paquetes en Visual Studio o Rider y ejecuta el siguiente comando para crear la migración inicial:
    ```bash
    Add-Migration Initial
    ```

5. **Actualiza la base de datos:**
    Una vez creada la carpeta `Migrations`, ejecuta el siguiente comando para aplicar las migraciones a la base de datos:
    ```bash
    Update-Database
    ```

6. **Ejecuta el programa:**
    Ya puedes ejecutar el programa desde Visual Studio o Rider seleccionando la opción de ejecución (`Run`) o mediante la consola con el siguiente comando:
    ```bash
    dotnet run
    ```

¡Y eso es todo! Ahora deberías tener el proyecto `personaapi-dotnet` configurado y en funcionamiento.
