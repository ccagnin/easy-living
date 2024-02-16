using EasyLiving.Application.Auth.Commom;
using ErrorOr;
using MediatR;

namespace EasyLiving.Application.Auth.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthResult>>;