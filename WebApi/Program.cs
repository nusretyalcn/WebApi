using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess;

var builder = WebApplication.CreateBuilder(args);

string MyAllowOrigins = "_myAllowOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebApiContext>(x => x.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database=WebApi;Trusted_Connection=True"));

builder.Services.AddCors(options => {
    options.AddPolicy(
        name: MyAllowOrigins,
        builder => {
            builder
            .WithOrigins("http://localhost:4200")
            //.WithMethods("GET", "DELETE", "POST")
            .AllowAnyHeader()
            .AllowAnyMethod();

        });
});

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

app.UseCors(MyAllowOrigins);

app.Run();
