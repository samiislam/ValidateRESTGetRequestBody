using System.ComponentModel.DataAnnotations;

namespace WebAPI.Requests
{
    public enum MaritalStatus
    {
        Single = 0,
        Married = 1
    }

    public class RequestWithCustomValidationAttribute
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [ValidMaritalStatus]
        public MaritalStatus MaritalStatus { get; set; }

        public string SpouseFirstName { get; set; }

        public string SpouseLastName { get; set; }
    }
}