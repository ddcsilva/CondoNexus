using CondoNexus.API.Configurations;
using CondoNexus.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CondoNexusContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CondoNexusConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiConfiguration();

builder.Services.ResolveDependencies();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.MapControllers();

app.Run();
