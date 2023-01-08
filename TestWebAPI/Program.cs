using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.DAL;
using TestWebAPI.Models.DTO;
using TestWebAPI.Models.Inputs.Customer;
using TestWebAPI.Models.Output.Customer;
using TestWebAPI.Services;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddOptions();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.Configure<SecretParametersSettings>(
    builder.Configuration.GetSection("SecretParametersSettings"));

builder.Services.AddDbContext<DbFactoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Production"));
});

var mapperConfig = new MapperConfiguration(
    mc =>
    {
        //Input
        mc.CreateMap<CustomerCreateInput, Customer>();
        mc.CreateMap<CustomerUpdateInput, Customer>();

        //Output
        mc.CreateMap<Customer, CustomerOutput>();
    });
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
   options.AddPolicy("policyName",
                     builder =>
                     {
                         builder.AllowAnyOrigin()//WithOrigins(policiesConfiguration.Website)
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

// Middleware A
app.Use(async (context, next) =>
{
    Console.WriteLine("A (before)");
    await next();
    Console.WriteLine("A (after)");
});

// Middleware B
app.Use(async (context, next) =>
{
    Console.WriteLine("B (before)");
    await next();
    Console.WriteLine("B (after)");
});

// Middleware C (terminal)
app.Use(async (context, next) =>
{
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
