using System.ComponentModel.DataAnnotations;

namespace WebAPI.Requests
{
    public class RequestWithBuiltInValidationAttribute
    {
        [Required]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}