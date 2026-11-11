using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Activo los controllers
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// 2. Conecto el DbContext con la cadena de appsettings.json
builder.Services.AddDbContext<CatalogoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();

// 3. Esto crea las tablas solito, sin migraciones
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatalogoDbContext>();
    db.Database.EnsureCreated();
}

app.Run();