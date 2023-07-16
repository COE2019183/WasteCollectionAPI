using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.Mapping;
using WMS_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injedcting the Database Dependency
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Inject the Automapper Profile

builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); //To map the profiles in the automapper profiles file.

//INjecting all the repositories

builder.Services.AddScoped<IBinRepository, PostgreSQLBinRepository>();

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
