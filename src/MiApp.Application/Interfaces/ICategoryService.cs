using MiApp.Application.Dtos;

namespace MiApp.Application.Interfaces;

/*
Esta nterfaz define el CONTRATO que debe cumplir cualquier servicio de categorías.
La API solo conoce este contrato, no la implementación concreta.
*/


public interface IcategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    // Obtener todas las categorias (Retorna una lista de categorias).

    Task<CategoryDto?> GetByIdAsync(int id);
    // Obtener una categoria por su Id (Retorna categoryDto o null si no existe).

    Task<CategoryDto> CreateAsync(CreateCategoryDto createDto);
    // Crear una categoria por su Id (Recibe CreateCategoryDto, retorna el CategoryDto actualizado o null).

    Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto updateDto);
    // Actualizar una categoria existente (Recibe id y UpdateCategoryDto, retorna el categoryDto actualizado o null).

    Task<bool> DeleteAsync(int id);
    // Eliminar una categoria(Retorna true si se elimino, false si no existía).
}