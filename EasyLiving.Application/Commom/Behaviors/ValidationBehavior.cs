using System.Runtime.InteropServices.JavaScript;
using EasyLiving.Application.Auth.Commands.Register;
using EasyLiving.Application.Auth.Commom;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace EasyLiving.Application.Commom.Behaviors;

public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IValidator<RegisterCommand> _validator;
    
    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }
    
    public async Task<ErrorOr<AuthResult>> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<ErrorOr<AuthResult>> next, 
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }
        
        var errors = validationResult.Errors.Select(
            validationFailure => Error.Validation(
                validationFailure.PropertyName, 
                validationFailure.ErrorMessage)).ToList();
        
        return errors;
    }
}