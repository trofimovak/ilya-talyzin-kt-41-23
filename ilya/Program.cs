using Microsoft.EntityFrameworkCore;
using ilya.Database;
using ilya.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// 1. Регистрация сервисов в DI-контейнере
builder.Services.AddControllers(); // Обязательно для работы контроллеров
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Подключение DbContext
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация ваших сервисов из ЛР 4
builder.Services.AddServices();

var app = builder.Build();

// 2. Настройка Middleware
// Включаем Swagger ДЛЯ ВСЕХ СРЕД (чтобы точно работало при локальной отладке)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = "swagger"; // Доступ по адресу /swagger
});

app.UseHttpsRedirection();
app.UseAuthorization();

// Регистрация маршрутов контроллеров
app.MapControllers();

app.Run();