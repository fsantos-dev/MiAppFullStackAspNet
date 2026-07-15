using MiApp.Application.Dtos;
using MiApp.Application.Interfaces;
using MiApp.Domain.Entities;

namespace MiApp.Application.Services;

/*
Esta clase implementa la interfaz ICategoryService.
Aqui va la logica de negocio (Reglas de creación, actualización, etc.)
*/

public class CategoryService : IcategoryService

{

    // ============================================================================
    // Simulacion de Base de Datos ( En Memoria )
    // ============================================================================

    // Esta lista actua como nuestra "tablaa" de categorias
    // Es estatica para que persista entre llamadas ( Simula una base de datos real)
    // El guion bajo iniciando la variable se usa para variables privadas

    private static List<Category> _categories = new();

    // Simula un auto incremental de SQL Server.
    private static int _nextId = 1;

    //============================================================================//


    //Obtener todas las categorias
    public Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        // Convertimos cada Category (Entidad de dominio) a CategoryDto (DTO de la aplicación)
        var dtos = _categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            IsActive = c.IsActive,
            CreatedAt = c.CreatedAt
        });

        return Task.FromResult(dtos);
    }

    public Task<CategoryDto?> GetByIdAsync(int id)
    {
        //Buscamos la primera categoría que coincida con el Id.
        var category = _categories.FirstOrDefault(c => c.Id == id);

        //Si no existe, retornamos null (el ? en Task<CategoryDto?> permite esto).
        if (category == null)
        {
            return Task.FromResult<CategoryDto?>(null);
        }

        //Si existe la convertimos a DTO y la retornamos
        var dto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            IsActive = category.IsActive,
            CreatedAt = category.CreatedAt
        };

        return Task.FromResult<CategoryDto?>(dto);
    }


    // Crear una nueva categoria
    public Task<CategoryDto> CreateAsync(CreateCategoryDto createDto)
    {
        //Creamos una nueva entidad Category a partir del DTO de creación.
        var category = new Category
        {
            Id = _nextId++, // Asignamos el siguiente Id disponible.
            Name = createDto.Name, // El nombre viene del DTO
            Description = createDto.Description, // Descripción (Puede ser null)
            IsActive = true, // Por defecto, siempre esta activa al crear
            CreatedAt = DateTime.UtcNow // Fecha en UTC (Estándar global)
        };

        // Guardamos en la lista ( Simulando INSERT EN BD)
        _categories.Add(category);

        // Convertimos a DTO para devolver al cliente
        var dto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            IsActive = category.IsActive,
            CreatedAt = category.CreatedAt
        };

        // Devolvemos el DTO creado. Nuca retornamois NULL aquí.
        return Task.FromResult<CategoryDto>(dto);
    }

    public Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto updateDto)
    {
        //Buscamos la categoria a actualizar
        var category = _categories.FirstOrDefault(c => c.Id == id);

        // Si no existe, retornamos NULL (Para que la API devuelva 404).
        if (category == null)
        {
            return Task.FromResult<CategoryDto?>(null);
        }

        // Actualizamos las propiedades permitidas (Name y Description).
        // Nota: No actualizamos Id, CreateAt, ni IsActive.
        category.Name = updateDto.Name;
        category.Description = updateDto.Description;
        category.UpdatedAt = DateTime.UtcNow; // Marcamos la fecha de actualización

        // Convertimos a DTO para devolver al cliente.
        var dto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            IsActive = category.IsActive,
            CreatedAt = category.CreatedAt
        };

        return Task.FromResult<CategoryDto?>(dto);

    }

    //Eliminar una categoria
    public Task<bool> DeleteAsync(int id)
    {
        //Buscamos la categoria a eliminar
        var category = _categories.FirstOrDefault(c => c.Id == id);

        // Si no existe, retornamos false ( Para que la API retorne 404 ).
        if (category == null)
        {
            return Task.FromResult(false);
        }

        // La removemos de la lista ( Simulando DELETE en BD)
        _categories.Remove(category);

        // Retornamos true indicando que se eliminó correctamente
        return Task.FromResult(true);

    }



}
