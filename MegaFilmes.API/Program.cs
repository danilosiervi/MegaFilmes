using MegaFilmes.Data;
using MegaFilmes.Data.Daos;
using MegaFilmes.Services.AtorServices;
using MegaFilmes.Services.AvaliacaoServices;
using MegaFilmes.Services.DiretorServices;
using MegaFilmes.Services.FilmeServices;
using MegaFilmes.Services.GeneroServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyConnection");

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseSqlServer(connectionString, m => m.MigrationsAssembly("MegaFilmes.API"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IDao<>), typeof(Dao<>));
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IDiretorService, DiretorService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IAtorService, AtorService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
