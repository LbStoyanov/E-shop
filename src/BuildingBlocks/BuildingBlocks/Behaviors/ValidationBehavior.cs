using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;


namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : ICommand<TResponse> // The filter here is only for CREATE,UPDATE & DELETE operations thats why inherit from ICommand Interface
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

       var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r =>r.Errors)
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        //Only valid requests reach the handle method

        return await next();
    }
}

