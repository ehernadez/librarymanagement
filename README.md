
# LibraryManagement Backend

Repositorio: [https://github.com/ehernadez/librarymanagement](https://github.com/ehernadez/librarymanagement)

## Descripción 
API RESTful para la gestión de libros, desarrollada en .NET 9, con persistencia en PostgreSQL y empaquetada para ejecución en Docker. Incluye endpoints para crear, consultar, actualizar y eliminar libros, validación de datos y manejo de errores.

## Requisitos previos
- Docker y Docker Compose
- (Opcional) .NET 9 SDK si deseas ejecutar o modificar el código fuera de contenedor

## Instalación y ejecución rápida
1. **Descarga el proyecto**
   - Clona el repositorio:
     ```bash
     git clone https://github.com/ehernadez/librarymanagement
     cd LibraryManagement
     ```
2. **Ejecuta con Docker Compose**
   - En la raíz del proyecto, ejecuta:
     ```bash
     docker compose up --build
     ```

   - Esto levantará automáticamente:
     - Una base de datos PostgreSQL llamada `library` (usuario: `root`, contraseña: `root`)
     - La API en el puerto `5000` (mapeado al puerto 80 del contenedor)
   - No necesitas crear la base de datos manualmente ni modificar archivos de configuración.

3. **Acceso a la API y documentación**
   - API: [http://localhost:5000](http://localhost:5000)
   - Swagger: [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

## Endpoints principales
- `POST /books` - Agregar libro
- `GET /books` - Listar libros
- `GET /books/{id}` - Obtener libro por ID
- `PUT /books/{id}` - Actualizar libro
- `DELETE /books/{id}` - Eliminar libro

## Validaciones y manejo de errores
- Todos los datos enviados son validados.
- Los errores (por ejemplo, libro no encontrado) se devuelven con mensajes claros y códigos HTTP adecuados.

## ORM y migraciones
- Se utiliza Entity Framework Core.
- Las migraciones se aplican automáticamente al iniciar la API, creando las tablas necesarias.

## Configuración Manual (opcional)
Si deseas modificar la cadena de conexión o ejecutar el proyecto fuera de Docker:
- Edita `LibraryManagement.API/appsettings.json` y ajusta la sección `ConnectionStrings`.
- Puedes crear la base de datos y la tabla manualmente usando el archivo `init-db.sql` incluido en el proyecto. Este archivo contiene:
  ```sql
  CREATE DATABASE library;

  -- Ejecuta lo siguiente dentro de la base de datos 'library'
  CREATE TABLE IF NOT EXISTS "Books" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "Author" VARCHAR(255) NOT NULL,
    "Year" INT NOT NULL,
    "ISBN" VARCHAR(50) NOT NULL
  );
  ```

## Desarrollo y pruebas locales
1. Instala .NET 9 SDK
2. Restaura dependencias y ejecuta migraciones:
   ```bash
   dotnet restore
   dotnet ef database update --project LibraryManagement.Infraestructure
   ```
3. Ejecuta la API localmente:
   ```bash
   dotnet run --project LibraryManagement.API
   ```