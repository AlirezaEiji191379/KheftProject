using KheftProject.Core.DependencyInjection;
using KheftProject.Core.Middlewares.Security;

var builder = WebApplication.CreateBuilder(args);
// DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKheftServices();


// Middlewares
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseMiddleware<SecurityMiddleware>();

app.MapControllers();

app.Run("http://*:5000");