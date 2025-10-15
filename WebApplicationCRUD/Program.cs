using CRUD_BAL.Service;
using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Model;
using CRUD_DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContextPool<ApplicationDbContext>(option =>
option.UseSqlServer(connectionString)
);
builder.Services.AddTransient<IRepository<Person>, Repository>();
builder.Services.AddTransient<Service, Service>();

//builder.Services.AddScoped<IRepository<Person>, Repository>();


//builder.Services.AddControllers();
//builder.Services.AddHttpClient();
//builder.Services.AddScoped<Service, Service>();
//builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
