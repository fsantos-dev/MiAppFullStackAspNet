namespace MiApp.Application.Dtos;

/*
Este DTO se usan cuando el cliente quiere CREAR una categoria.
Nota: NO tiene Id, NO tiene CreatedAtl NO tiene IsActive.
¿Por qué? Porque el Id lo geneta la base de datos, CreatedAt lo pone el servidor
y IsActive por defecto siempre es true al crear.
*/

public class CreateCategoryDto
{
    public string Name {get; set;} = string.Empty;
    //El cliente DEBE enviar un nombre

    public string? Description {get; set;}
    //El cliente PUEDE enviar una descripcion
}


/*
¿Crees que es correcto tener dos clases iguales, o podríamos reutilizar una sola?
(Pista: piensa en el principio I de SOLID - Interface Segregation - y en el futuro. 
Si mañana decimos que al actualizar NO se puede modificar el nombre, pero al crear sí, 
¿qué pasaría si usáramos la misma clase?)
*/