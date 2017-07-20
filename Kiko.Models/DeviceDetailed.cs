using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class DeviceDetailed
    {
        [Required]
        public long DeviceId { get; set; }
        public float? Fueluse { get; set; }
        public byte? Overspeed { get; set; }
        public byte? BatteryPercent { get; set; }
        public virtual Device Device { get; set; }

    }
}