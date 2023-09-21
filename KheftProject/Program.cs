using KheftProject.Core.DataAccess;
using KheftProject.Core.DependencyInjection;
using KheftProject.Core.Middlewares.Security;

var builder = WebApplication.CreateBuilder(args);
// DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKheftServices(builder.Configuration);
builder.Services.AddScoped<SecurityMiddleware>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTelegramBot",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins(builder.Configuration["TelegramBot"])
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();
// Migrator
await Migrator.Migrate(app);

// Middlewares
app.UseCors("AllowTelegramBot");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseMiddleware<SecurityMiddleware>();

app.MapControllers();

app.Run($"http://localhost:{app.Configuration["PortNumber"]}");