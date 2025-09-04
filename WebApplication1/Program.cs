using LibraryManagementSystem.Infrastructure.SqlSever.Data;
using LibraryManagementSystem.Infrastructure.SqlSever.MapperProfile;
using LibraryManagementSystem.Infrastructure.SqlSever.Repositories;
using LibraryManagementSystem.UseCase;
using LibraryManagementSystem.UseCase.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Console.WriteLine(builder.Configuration.GetConnectionString("Data Source=ACERNITRO5\\SQLEXPRESS03;Initial Catalog=LibraryDB;Integrated Security=True;Trust Server Certificate=True"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => { }, typeof(SqlServer2EntityProfile));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookManager, BookManager>();
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
