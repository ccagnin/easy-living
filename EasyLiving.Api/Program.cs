using EasyLiving.Application.Services.Auth;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IAuthService, AuthService>();
}


var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}
