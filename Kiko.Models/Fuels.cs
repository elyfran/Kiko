using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class Fuels
    {
        public Fuels()
        {
            Devices = new List<Device>();

        }

        [Required]

        public byte Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public byte? FuelTank { get; set; }
        [Required]

        public float inCity { get; set; }
        [Required]

        public float inSuperhighway { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

    }
}