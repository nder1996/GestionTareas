# 📋 Sistema de Gestión de Tareas

Un sistema completo para administración de tareas con arquitectura moderna, frontend en Angular y backend en ASP.NET Core.

## ✨ Características

- ✅ **Gestión completa de tareas**: Crear, editar, eliminar y visualizar tareas
- 🔴🟡🟢 **Prioridades personalizadas**: Asignación de prioridades (Alta, Media, Baja)
- 🔄 **Control de estados**: Cambiar estados (Pendiente, En progreso, Completada)
- 📅 **Gestión temporal**: Administración de fechas de vencimiento
- 📋 **Historial**: Visualización del historial completo de tareas
- 🔍 **Búsqueda avanzada**: Filtrado y búsqueda de tareas por múltiples criterios
- 🔄 **Restauración**: Posibilidad de reactivar tareas completadas
- 🗑️ **Archivado**: Opción para archivar tareas sin eliminarlas permanentemente

## 🏗️ Arquitectura

### Frontend (Angular)

- **Domain-Driven Design (DDD)** 🧩
  - Organización por dominios funcionales
  - Estructura de carpetas por responsabilidades:
    ```
    src/
    ├── app/
    │   ├── domain/         # Contratos e interfaces del modelo de negocio
    │   ├── application/    # Casos de uso y DTOs
    │   ├── presentation/   # Componentes visuales y páginas
    │   └── infrastructure/ # Implementaciones y comunicación externa
    ```

- **Arquitectura Hexagonal** 🔌
  - Puertos: Interfaces en `domain/` (ej: `ITareaRepositorio`)
  - Adaptadores: Implementaciones en `infrastructure/adapters/`

- **Lazy Loading** ⚡
  - Módulos cargados bajo demanda para optimizar rendimiento

### Backend (ASP.NET Core)

- **Clean Architecture** 🧪
  - Capas con dependencias hacia el centro:
    ```
    src/
    ├── Models/           # Entidades centrales (Tarea, Estado, Prioridad)
    ├── Repository/       # Acceso a datos
    │   ├── Interfaces/   # Contratos de repositorios
    │   └── Implementations/ # Implementaciones concretas
    ├── Services/         # Lógica de negocio
    ├── DTOs/             # Objetos de transferencia
    │   ├── Request/      # DTOs de entrada
    │   └── Response/     # DTOs de salida
    └── Controllers/      # API REST
    ```

- **Patrones implementados** 📐
  - Repository: Abstracción del acceso a datos
  - DTO: Separación entre modelos de dominio y contratos de API
  - Facade: Capa de servicio como fachada para operaciones complejas
  - Inyección de Dependencias: Registro centralizado de servicios

## 🚀 Tecnologías

### Frontend
- ⚡ Angular 16
- 🎨 PrimeNG 16.9
- 📱 Bootstrap 5.3
- 🔄 RxJS 7.8

### Backend
- 🖥️ ASP.NET Core 6
- 📊 Entity Framework Core
- 📝 Swagger/OpenAPI
- 🔒 CORS configurado

## ⚙️ Instalación

### Backend
```bash
cd Backend/gestion-tareas
dotnet restore
dotnet build
dotnet run --project gestion-tareas
```

### Frontend
```bash
cd Frontend/gestion-tareas
npm install
ng serve
```

## 🌐 Despliegue

- **Backend**: Desplegado con Docker en Render
- **Frontend**: Disponible en [Vercel](https://gestion-tareas-one.vercel.app)

## 📸 Capturas de pantalla

[Añadir capturas de pantalla de la aplicación aquí]

## 🤝 Contribuir

Las contribuciones son bienvenidas. Por favor, abra un issue o envíe un pull request para sugerir cambios o mejoras.

## 📄 Licencia

[Incluir información de licencia]

