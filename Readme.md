# Desarrollo tarea de análisis

## Identificación de entidades clave:

- Hackatón
- Equipo
- Participante
- Mentor
- Proyecto
- Evaluación
- Premio
- Organizador

## **Determinar los atributos**

### Hackatón

- Nombre
- Fecha de inicio
- Fecha de fin
- Tema principal
- Organizador

### Equipo

- Nombre del equipo
- Cantidad de miembros
- Experiencia (desarrollo, diseño, gestión de proyectos)

### Participante

- Nombre
- Rol en el equipo (desarrollador, diseñador, líder)
- Experiencia

### Mentor

- Nombre
- Áreas de experiencia

### Proyecto

- Nombre
- Descripción
- Estado de desarrollo (en progreso, finalizado, etc.)
- Fecha de entrega final

### Evaluación

- Puntuación
- Comentarios
- Criterios (innovación, funcionalidad, presentación)

### Premio

- Nombre
- Descripción
- Valor

### Organizador

- Nombre
- Información de contacto

## **Identificar las relaciones entre las entidades**.

- Hackatón - Equipo: Un hackatón tiene muchos equipos, un equipo participa en un hackatón.
- Equipo - Participante: Un equipo tiene varios participantes, un participante pertenece a un equipo.
- Hackatón - Mentor: Un hackatón tiene varios mentores, un mentor puede participar en varios hackatones.
- Mentor - Equipo: Un mentor puede guiar a varios equipos, un equipo puede ser guiado por varios mentores.
- Equipo - Proyecto: Un equipo desarrolla un proyecto, un proyecto es desarrollado por un equipo.
- Proyecto - Evaluación: Un proyecto recibe varias evaluaciones, una evaluación corresponde a un proyecto.
- Mentor - Evaluación: Un mentor realiza varias evaluaciones, una evaluación es realizada por un mentor.
- Hackatón - Premio: Un hackatón ofrece varios premios, un premio pertenece a un hackatón.
- Organizador - Hackatón: Un organizador puede gestionar varios hackatones, un hackatón es gestionado por un organizador.
- Instalar postgresSQL en mac
    
    # Instalación y Configuración de PostgreSQL en Mac M2
    
    ## Paso 1: Instalar PostgreSQL
    
    1. La forma más sencilla de instalar PostgreSQL es usando Homebrew. Si no tienes Homebrew instalado, puedes instalarlo con este comando:
        
        ```bash
        /bin/bash -c "$(curl -fsSL <https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh>)"
        
        ```
        
    2. Una vez que tengas Homebrew, instala PostgreSQL:
        
        ```bash
        brew install postgresql
        
        ```
        
    3. Inicia el servicio de PostgreSQL:
        
        ```bash
        brew services start postgresql
        
        ```
        
    
    ## Paso 2: Crear una base de datos
    
    1. Accede a la consola de PostgreSQL:
        
        ```bash
        psql postgres
        
        ```
        
    2. Crea una nueva base de datos para tu proyecto de Hackathon:
        
        ```sql
        CREATE DATABASE hackathondb;
        
        ```
        
    3. Crea un nuevo usuario (opcional, pero recomendado):
        
        ```sql
        CREATE USER hackathonuser WITH ENCRYPTED PASSWORD 'tu_contraseña_segura';
        
        ```
        
    4. Otorga todos los privilegios al nuevo usuario en la nueva base de datos:
        
        ```sql
        GRANT ALL PRIVILEGES ON DATABASE hackathondb TO hackathonuser;
        
        ```
        
    5. Sal de la consola de PostgreSQL:
        
        ```sql
        \\q
        
        ```
        
    
    ## Paso 3: Configurar tu aplicación .NET para usar PostgreSQL
    
    1. Instala los paquetes NuGet necesarios en tu proyecto .NET:
        
        ```bash
        dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
        
        ```
        
    2. En tu archivo `appsettings.json`, agrega la cadena de conexión:
        
        ```json
        {
          "ConnectionStrings": {
            "DefaultConnection": "Host=localhost;Database=hackathondb;Username=hackathonuser;Password=tu_contraseña_segura"
          }
        }
        
        ```
        
    3. En tu clase `Program.cs`, configura el contexto de la base de datos:
        
        ```csharp
        services.AddDbContext<HackathonContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        
        ```
        
    4. Asegúrate de que tu `DatabaseContex.cs` esté utilizando PostgreSQL:
        
        ```csharp
        public class DatabaseContex : DbContext
        {
            public DatabaseContex(DbContextOptions<DatabaseContex> options)
                : base(options)
            {
            }
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=hackathondb;Username=hackathonuser;Password=tu_contraseña_segura");
            }
        
        }
        
        ```
        
    
    ## Paso 4: Migrar tu base de datos
    
    1. Crea una migración inicial:
        
        ```bash
        dotnet ef migrations add InitialCreate
        
        ```
        
    2. Aplica la migración a la base de datos:
        
        ```bash
        dotnet ef database update
        
        ```
        
    
    Ahora tienes PostgreSQL instalado, configurado y listo para usar con tu aplicación de Gestión de Hackatones en tu Mac M2.