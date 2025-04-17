## 🧱 Arquitectura del Proyecto
El proyecto sigue una arquitectura en capas, dividida en los siguientes componentes

- **GranjaDeHuevo.API**:Contiene los controladores y la configuración de la API
- **GranjaDeHuevo.Domain**:Define las entidades y las interfaces de los repositorios
- **GranjaDeHuevo.Infrastructure**:Implementa los repositorios y gestiona el acceso a datos
- **DB**:Incluye scripts de base de datos y archivos `.bak` para restaurar la base de datos
Este enfoque promueve la separación de responsabilidades, facilitando el mantenimiento y la escalabilidad del sistema

---

## 🛠️ Configuración de la Base de Datos en SSMS

1. **Configurar la Autenticación**:
    En SSMS, haz clic derecho en el nombre del servidor y selecciona "Propiedades.
    En la sección "Seguridad", asegúrate de que la opción "Modo de autenticación de SQL Server y Windows" esté seleccionad.
    Reinicia el servidor SQL para aplicar los cambio.

2. **Crear un Usuario de SQL Server**:
    En SSMS, expande la carpeta "Seguridad" y luego "Inicios de sesión.
    Haz clic derecho en "Inicios de sesión" y selecciona "Nuevo inicio de sesión....
    En la ventana que aparece, ingresa un nombre de inicio de sesión y selecciona "Autenticación de SQL Server.
    Establece una contraseña y configura las opciones adicionales según tus necesidade.
    En la sección "Asignación de usuarios", asigna el usuario a la base de datos restaurada y otórgale los roles necesarios (por ejemplo, `db_owner`.

---

## ⚙️ Configuración en C#

1. **Actualizar la Cadena de Conexión**:
    Abre el archivo `appsettings.json` ubicado en el proyecto `GranjaDeHuevo.API.
    Localiza la sección `ConnectionStrings` y actualiza la cadena de conexión con los detalles de tu servidor SQL, nombre de la base de datos, usuario y contraseñ.

   Ejemplo:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=TU_SERVIDOR;Database=EggFarmDB;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
   }
   ``


2. **Verificar la Configuración de Entity Framework**:
    Asegúrate de que en el archivo `Startup.cs` esté configurando correctamente el contexto de la base de datos utilizando la cadena de conexión proporcionad.

   Ejemplo:

   ```csharp
   services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
   ``


---

## 🚀 Ejecución de la API

1. **Compilar el Proyecto**:
  - Abre el archivo de solución `GranjaDeHuevo.sln` en Visual Studo.
  - Restaura los paquetes NuGet necesaris.
  - Compila la solución para asegurarte de que no haya errors.

2. **Ejecutar la API**:
  - Establece `GranjaDeHuevo.API` como el proyecto de inico.
  - Ejecuta la aplicación (F5 o Ctrl+F).
  - La API debería iniciarse y estar disponible en la URL especificada (por ejemplo, `https://localhost:5001).

3. **Probar los Endpoints**:
  - Utiliza herramientas como Postman o Swagger (aun no esta configurado, pero lo puede configurar) para probar los diferentes endpoints de la API.

---

## 👤 Guía para Usuarios

1. **Requisitos Previos**

Antes de comenzar, asegúrate de tener instalado lo siguiente en tu máquina:

- **.NET SDK** (versión 6 o superior)
- **Visual Studio** 
- **SQL Server Management Studio (SSMS)** para ejecutar el script de la base de datos.


2. **Clonar el Repositorio**:
  - Ejecuta el siguiente comando en tu termial:

     ```bash
     git clone https://github.com/EsloanJimenez/EggFarmBack.git
     ```

3. **Configurar la Base de Datos**:
  - Sigue los pasos mencionados anteriormente para restaurar la base de datos y configurar la autenticacón.

4. **Actualizar la Cadena de Conexión**:
  - Modifica el archivo `appsettings.json` con los detalles de tu servidor QL.

5. **Compilar y Ejecutar la API**:
  - Abre la solución en Visual Studio, compila y ejecuta la PI.

6. **Probar la API**:
  - Utiliza herramientas como Postman o Swagger para interactuar con los endpoints disponibes.

## Contribuciones

Si deseas contribuir al proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -am 'Añadir nueva funcionalidad'`).
4. Haz push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

