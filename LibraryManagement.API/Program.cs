using LibraryManagement.API.Endpoints;
using LibraryManagement.API.Middleware;
using LibraryManagement.Gateway;

var builder = WebApplication.CreateBuilder(args);
// Configura CORS para permitir cualquier origen (ajusta según tu frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Agrega la inyeccion de dependencias
builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();
// Usa CORS antes de los endpoints
app.UseCors("AllowAll");

// Inicializa las migraciones para crear la tabla en la BD
app.Services.InitializeDatabase();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

// Mapea los endpoints
app.MapBookEndpoints();

app.Run();
