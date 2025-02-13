using CQRSPrototype.IUserCommandRepository;
using CQRSPrototype.IUserQueryRepository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new ArgumentNullException("La cadena de conexión no puede ser nula");

builder.Services.AddSingleton(new DatabaseHelper(connectionString));

builder.Services.AddScoped<IUsuarioQueryRepository, UsuarioQueryRepository>();
builder.Services.AddScoped<IUsuarioCommandRepository, UsuarioCommandRepository>();


builder.Services.AddScoped<CreateUsuarioCommand>();
builder.Services.AddScoped<GetUsuariosQuery>();
builder.Services.AddScoped<GetUsuarioByIdQuery>();
builder.Services.AddScoped<DeleteUsuarioCommand>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();