using CQRSPrototype.CQRS.Commands;
using CQRSPrototype.IUserCommandRepository;
using CQRSPrototype.IUserQueryRepository;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la conexión a la base de datos
builder.Services.AddSingleton<DatabaseHelper>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new DatabaseHelper(connectionString);
});

// Repositorios
builder.Services.AddScoped<IUsuarioCommandRepository, UsuarioCommandRepository>();
builder.Services.AddScoped<IUsuarioQueryRepository, UsuarioQueryRepository>();

// Handlers de CQRS
builder.Services.AddScoped<CreateUsuarioCommandHandler>();
builder.Services.AddScoped<DeleteUsuarioCommandHandler>();
builder.Services.AddScoped<GetUsuariosQueryHandler>();
builder.Services.AddScoped<GetUsuarioByIdQueryHandler>();

var app = builder.Build();

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();