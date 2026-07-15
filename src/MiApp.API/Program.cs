using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// 1. Agregar controladores ( Necesario para usar  [ApiController] y las rutas)
// Esto registra todos los controladores que creemos ( Incluyendo CategoriesController ).
builder.Services.AddControllers();

// 2. Configurar swagger para documentar la API.
// swagger genera una interfaz vistual (/swagger) para probar los endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // En desarrollo, mostramos Swagger UI (Interfaz gráfica )
    app.UseSwagger();
    app.UseSwaggerUI();

}

// CORS debe ir antes de Authorization/MapControllers
// app.UseCors("AllowAngularApp");

app.UseHttpsRedirection(); // Redirige HTPP a HTTPS ( Seguridad ).
app.UseAuthorization(); // Por ahora no lo usamos, pero lo dejamos preparada para la Fase 3 ( JWT ).
app.MapControllers(); // Mapea las rutas de los controladores (ej: /api/categories)

app.Run();


