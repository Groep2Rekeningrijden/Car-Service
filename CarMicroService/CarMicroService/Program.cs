using CarMicroService.Data;
using CarMicroService.Models.RabbitMq;
using CarMicroService.Services.CarService;
using CarMicroService.Services.CarTypeService;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var FrontEndOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    //options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(5, 7, 31)));
    //options.UseMySql(builder.Configuration.GetConnectionString("MigrationConnection"), new MySqlServerVersion(new Version(5, 7, 31)));
    options.UseMySql(builder.Configuration.GetConnectionString("KubernetesConnection"), new MySqlServerVersion(new Version(5, 7, 31)));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarTypeService, CarTypeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FrontEndOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); ;
                      });
});

var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
builder.Services.AddMassTransit(mt => mt.AddMassTransit(x => {
    x.UsingRabbitMq((cntxt, cfg) => {
        cfg.Host(rabbitMqSettings.Uri, c => {
            c.Username(rabbitMqSettings.UserName);
            c.Password(rabbitMqSettings.Password);
        });
    });
}));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(FrontEndOrigins);
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

