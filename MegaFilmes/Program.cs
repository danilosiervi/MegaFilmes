using MegaFilmes.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MyConnection");

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseSqlServer(connectionString, m => m.MigrationsAssembly("MegaFilmes.API"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
