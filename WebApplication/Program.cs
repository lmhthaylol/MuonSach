using LibraryManagementSystem.Infrastructure.SqlSever.Data;
using LibraryManagementSystem.Infrastructure.SqlSever.MapperProfile;
using LibraryManagementSystem.Infrastructure.SqlSever.Repositories;
using LibraryManagementSystem.UseCase;
using LibraryManagementSystem.UseCase.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(SqlServer2EntityProfile));

builder.Services.AddScoped<IBookRepository, BookRepository>();
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
