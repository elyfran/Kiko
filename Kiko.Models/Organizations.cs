using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class Organizations
    {
        public Organizations()
        {
            Devices = new List<Device>();

        }

        [Required]

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(10)]
        public string City { get; set; }
        [StringLength(10)]
        public string province { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Lat { get; set; }
        [StringLength(50)]
        public string Long { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

    }
}