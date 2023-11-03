using PhoneResQ.API.Support.Domain.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhoneResQ.API.Support.Resources
{
    public class DeviceResource
    {
        public int Id { get; set; }
        public long IMEI { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }

    public class SaveDeviceResource
    {
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        public long IMEI { get; set; }
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}
