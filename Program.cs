using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using excel;
using APIMDEmployee.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    OpenApiInfo info = new OpenApiInfo();
    info.Title = "TestAPI1 Swagger API Documentation"; 
    info.Version = "v1";
    opt.SwaggerDoc("v1", info);
});

builder.Services.AddDbContext<ePaymentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

var app = builder.Build();


app.UseSwagger((option) =>
{
    option.SerializeAsV2 = true;
});
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
