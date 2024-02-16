using EasyLiving.Application.Auth.Commom;
using ErrorOr;
using MediatR;

namespace EasyLiving.Application.Auth.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthResult>>;