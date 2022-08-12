using Microsoft.EntityFrameworkCore;
using BigBazzar.Data;
using BigBazzar.Repository;
using BigBazzar.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BigBazzarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BigBazzarContext") ?? throw new InvalidOperationException("Connection string 'BigBazzarContext' not found.")));


builder.Services.AddScoped<IAdminRepo, AdminRepo>();

builder.Services.AddScoped<ITraderRepo, TraderRepo>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IEmailService, EmailService>();


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
