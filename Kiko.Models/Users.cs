using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class Users
    {
        public Users()
        {
            Devices_owned = new List<Device>();
            Devices_drived = new List<Device>();

        }

        [Required]

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(12)]
        public string Mobile { get; set; }
        [StringLength(50)]
        public string imagePath { get; set; }
        [Required]
        [StringLength(50)]
        public string username { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(50)]
        public string TelegramId { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public bool? Admin { get; set; }

        public int? DeviceLimit { get; set; }

        public bool? Disabled { get; set; }
        [DataType(DataType.Date)]

        public DateTime? ExpirationTime  { get; set; }
    [StringLength(50)]
    public string Latitude { get; set; }
    [StringLength(50)]
    public string Longitude { get; set; }
    public virtual ICollection<Device> Devices_owned { get; set; }
    public virtual ICollection<Device> Devices_drived { get; set; }

} 
}