using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationExceptionApp : Exception
    {
        public List<string> Errors { get; set; }

        public ValidationExceptionApp() : base("Se han producido uno o mas errores de validación - 'ValidationException : Exception'.")
        {
            Errors = new List<string>();
        }

        public ValidationExceptionApp(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
}
