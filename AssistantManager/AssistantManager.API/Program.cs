using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using AssistantManager.Core.Services;
using AssistantManager.Infrastructure;
using AssistantManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AssistantDatabaseContext>(opt => opt.UseSqlite(connectionString: "Data Source=database.db")); //para generar la bd

builder.Services.AddScoped<IRepository<Ingredient>, IngredientEFRepository>();
builder.Services.AddScoped<IService<Ingredient>, IngredientService>();

builder.Services.AddScoped<IRepository<GroceryList>, GroceryListEFRepository>();
builder.Services.AddScoped<IService<GroceryList>, GroceryListService>();

builder.Services.AddScoped<IRepository<Reminder>, ReminderEFRepository>();
builder.Services.AddScoped<IService<Reminder>, ReminderService>();

builder.Services.AddScoped<IRepository<Song>, SongEFRepository>();
builder.Services.AddScoped<IService<Song>, SongService>();

builder.Services.AddScoped<IRepository<Album>, AlbumEFRepository>();
builder.Services.AddScoped<IService<Album>, AlbumService>();

//builder.Services.AddCors(options => options.AddPolicy("application",
//    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

//Agregar contexto y crear base de datos
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AssistantDatabaseContext>();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
