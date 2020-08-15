using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Requests
{
    public class ValidMaritalStatus : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var maritalStatus = (MaritalStatus)value;
            var requestWithCustomValidationAttribute = (RequestWithCustomValidationAttribute)validationContext.ObjectInstance;

            // if "married" then the spouse first and last name must be present
            if (maritalStatus == MaritalStatus.Married)
            {
                var (valid, result) = GetValidationStatus(requestWithCustomValidationAttribute.SpouseFirstName,
                                                          requestWithCustomValidationAttribute.SpouseLastName);

                if (!valid)
                {
                    return result;
                }
            }

            return ValidationResult.Success;
        }

        private (bool, ValidationResult) GetValidationStatus(string FirstName, string LastName) =>
            (string.IsNullOrEmpty(FirstName), string.IsNullOrEmpty(LastName)) switch
            {
                (true, false) => (false, new ValidationResult("Spouse first name may not be empty", new[] { nameof(FirstName)})),
                (false, true) => (false, new ValidationResult("Spouse last name may not be empty", new[] { nameof(LastName)})),
                (true, true) => (false, new ValidationResult("Spouse first and last name may not be empty", new[] { nameof(FirstName), nameof(LastName)})),
                _ => (true, null)
            };
    }
}