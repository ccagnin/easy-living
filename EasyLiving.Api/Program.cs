using EasyLiving.Api.Commom.Errors;
using EasyLiving.Application;
using EasyLiving.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, EasyLivingProblemDetailsFactory>();
}


var app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}
