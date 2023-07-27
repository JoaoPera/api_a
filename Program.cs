using api_a.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string db_file_path = builder.Configuration.GetConnectionString("DefaultConnection");
//string db_full_path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, db_file_path));//
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(db_file_path) );

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
