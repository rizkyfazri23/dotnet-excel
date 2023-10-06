using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using excel; 

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
