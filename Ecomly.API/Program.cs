using Ecomly.Core;
using Ecomly.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//Add Infrastructure services
builder.Services.AddInfrastructure();
//Add Core services
builder.Services.AddCore();

builder.Services.AddControllers();
//Build the Web application
var app = builder.Build();
//Routing
app.UseRouting();
//Auth
app.UseAuthentication();
app.UseAuthorization();
//Contoller Routes
app.MapControllers();


app.Run();
