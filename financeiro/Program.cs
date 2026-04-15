using financeiro.Application.Contract;
using financeiro.Domain.Repository;
using financeiro.Domain.Service;
using financeiro.Infraestructure.Database;
using financeiro.Infraestructure.Repository;
using financeiro.Infraestructure.Service;
using Financeiro.Infraestructure.Database;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.Services.Scan(scan => scan
    .FromAssembliesOf(
        typeof(CriarUsuario),
        typeof(UsuarioRepository),
        typeof(IDbConnectionFactory),
        typeof(BcryptHashService)
    )
    .AddClasses(classes => classes.AssignableToAny(
        typeof(ICriarUsuario),
        typeof(IUsuarioRepository),
        typeof(IDbConnectionFactory),
        typeof(IHashService)
    ))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);


// Configure PostgreSQL connection
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

MigrationRunner.Run(connectionString);
app.Run();
