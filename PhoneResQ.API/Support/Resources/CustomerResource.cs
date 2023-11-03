using System.ComponentModel.DataAnnotations;

namespace PhoneResQ.API.Support.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class SaveCustomerResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(8)]
        public string DNI { get; set; }
        [Required]
        [MaxLength(32)]
        public string Email { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}
