namespace MiApp.Application.Dtos;

/* Este DTO se usa CUANDO EL CLIENTE QUIERE ACTUALIZAR una categoría.
Similar al de creación, pero aquí el ID viene en la URL (api/categories/{id}),
por eso no lo ponemos dentro del body.
*/

public class UpdateCategoryDto
{
    public string Name {get; set;} = string.Empty;
    //El nuevo nombre que el cliente quiere poner.

    public string? Description {get; set;}
    //La nueva descripcion
}


/*
¿Crees que es correcto tener dos clases iguales, o podríamos reutilizar una sola?
(Pista: piensa en el principio I de SOLID - Interface Segregation - y en el futuro. 
Si mañana decimos que al actualizar NO se puede modificar el nombre, pero al crear sí, 
¿qué pasaría si usáramos la misma clase?)
*/