using System.ComponentModel.DataAnnotations;

namespace gestion_tareas.Service
{
    public class ValidationService
    {
        public List<string> ValidateModel<T>(T model) where T : class
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (isValid)
                return new List<string>();

            return validationResults
                .Select(vr => vr.ErrorMessage)
                .Where(msg => !string.IsNullOrEmpty(msg))
                .ToList();
        }
    }
}

