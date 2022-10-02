using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behavious
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())  // si se definio alguna validacion, hacer
            {
                var context = new ValidationContext<TRequest>(request); // tomar la peticion que entra y pasarselas al contexto
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))); // tomamos todas las validaciones del contexto
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList(); // recolectamos un listado de errores

                if (failures.Count != 0) // si se encontro algun error, hacer 
                    throw new ValidationExceptionApp(failures); // 'Exceptions' del namespace Application.Exceptions
            }

            return await next();
        }
    }
}
