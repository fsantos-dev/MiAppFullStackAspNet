using System.Timers;

namespace MiApp.Application.Dtos;


// CategoryDto: es la "foto" que le enviamos al cliente (Angular) cuando pide una categoria
// No contiene lógica de negocio, solo datos planos.

public class CategoryDto
{
    public int Id {get; set;}
    // El ID es público por que el frontend lo necesita para saber que categoría es.

    public string Name {get; set;} = string.Empty;
    // El nombre es obligatorio

    public string? Description {get; set;}
    // La desctipción puede ser nula, igual que en la entidad.

    public bool IsActive {get; set;}
    // Exponemos si está activa, Aunque no la usemos en el frontend ahora.
    // La dejamos por si necesitamos mostrar un "Activo/Inactivo".

    public DateTime CreatedAt {get; set;}
    // Exponemos la fecha de creación. Es útil para saber cuando se registro.


    /*
    OCP (Open/Closed): La entidad Category está "cerrada" para cambios directos. 
    Si mañana agregamos una propiedad ImageUrl a la BD, solo añadimos esa propiedad al DTO si queremos. 
    La entidad de dominio cambia, pero el DTO se adapta sin romper el contrato con Angular.
    */



}