using FluentValidation.AspNetCore;
using StokTakipSistemi.BLL.DependencyResolvers;
using StokTakipSistemi.ENTITIES.DataTransferObjects;
using StokTakipSistemi.ENTITIES.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextService();
builder.Services.AddRepositoryManagerServices();
builder.Services.AddAutoMapper(typeof(MapperClasses).Assembly);
builder.Services.AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<KategoriDtoValidation>(); });

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
