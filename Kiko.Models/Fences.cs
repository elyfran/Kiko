using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class Fences
    {
        public Fences()
        {
            Devices = new List<Device>();
        }

        [Required]

        public byte Id { get; set; }
        [Required]
        [StringLength(17)]
        public string IMEI { get; set; }
        [Required]

        public long DeviceId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string CenterLat { get; set; }
        [StringLength(50)]
        public string CenterLong { get; set; }

        public int? RadiusMeter { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ProvinceBound { get; set; }
        [StringLength(50)]
        public string CityBound { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

    }
}