using System.ComponentModel.DataAnnotations;

namespace PhoneResQ.API.Support.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class SaveCustomerResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(8)]
        public string DNI { get; set; } = string.Empty;
        [Required]
        [MaxLength(32)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(12)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; } = string.Empty;
    }

    public class CustomerLoginResource
    {
        [Required]
        [MaxLength(32)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; } = string.Empty;
    }
}
