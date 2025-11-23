using AutoMapper;
using Ecomly.API.Middlewares;
using Ecomly.Core;
using Ecomly.Core.Mappers;
using Ecomly.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //Add Infrastructure services
        builder.Services.AddInfrastructure();
        //Add Core services
        builder.Services.AddCore();

        builder.Services.AddControllers().AddJsonOptions(
            options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        builder.Services.AddAutoMapper(typeof(AppUserMappingProfile).Assembly);
        //builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationAutoValidation();
        //Build the Web application
        var app = builder.Build();
        app.UseExceptionHandlingMiddleware();
        //Routing
        app.UseRouting();
        //Auth
        app.UseAuthentication();
        app.UseAuthorization();
        //Contoller Routes
        app.MapControllers();


        app.Run();
    }
}