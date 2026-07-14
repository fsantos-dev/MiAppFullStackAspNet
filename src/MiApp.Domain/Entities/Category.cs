using System; // Para usar DataTime

namespace MiApp.Domain.Entities; // el namespace indica donde vive esta clase


/*
Representa una categoria de productos en el sistema
Esta es una ENTIDAD DE DOMINIO (No tiene logica de base de datos ni de API).
*/

public class Category
{
    //Proipiedades: Son los atributos que tiene una categoria

    public int Id {get; set;}
    // "Id" es el identificador unico de cada categoria.
    // Sera autogenerado por la base de datos(o en memoria, por ahora).

    public string Name {get; set;} = string.Empty; 
    // "Name" es el nombre de l;a categoria (ej: "Electronicos").
    // Inicializamos con string.Empty para evitar que sea null por defecto.

    public string? Description {get; set;}
    // "Description" es opcional (nullable con "?").
    // Puede ser nulll si no se proporciona

    public bool IsActive {get; set;} = true;
    // "IsAcctive" indica si la categoria está habilitada.
    // Por defecto es true(activa al crearse).


    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    // "CreatedAt" guarda la fecha y hora de creación.
    // Usamos DateTime.UtcNow para que sea universal (No depende de zona horaria).

    public DateTime? UpdatedAt {get; set;}
    // "UpdatedAt" guarda la última fecha de modificación.
    // Es nullable por que al crearse aún no se ha actualizado.


    /*
    SRP (Single Responsibility Principle - "S" de SOLID): 
    Esta clase solo representa la entidad "Categoría". 
    No tiene métodos para guardar en base de datos, ni para mostrarse en pantalla, ni para validar. 
    Su única responsabilidad es ser el modelo de datos del dominio.
    */





}


