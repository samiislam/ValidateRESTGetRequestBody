using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Requests
{
    public class RequestWithClassLevelValidation : IValidatableObject
    {
        [Required]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var (valid, result) = GetValidationStatus(FirstName, LastName);

            if(!valid)
            {
                yield return result;
            }
        }

        private (bool, ValidationResult) GetValidationStatus(string FirstName, string LastName) =>
            (string.IsNullOrEmpty(FirstName), string.IsNullOrEmpty(LastName)) switch
            {
                (true, false) => (false, new ValidationResult("First name may not be empty", new[] { nameof(FirstName)})),
                (false, true) => (false, new ValidationResult("Last name may not be empty", new[] { nameof(LastName)})),
                (true, true) => (false, new ValidationResult("First and last name may not be empty", new[] { nameof(FirstName), nameof(LastName)})),
                _ => (true, null)
            };
    }
}