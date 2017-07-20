using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class DevicePositionData
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [StringLength(17)]
        public string IMEI { get; set; }
        public long? DeviceId { get; set; }
        [Required]
        [StringLength(50)]
        public string Latitude { get; set; }
        [Required]
        [StringLength(50)]
        public string Longitude { get; set; }
        [Required]
        public byte Spead { get; set; }
        [StringLength(5)]
        public string Course { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime insertedDate { get; set; }
        [Required]
        public TimeSpan insertedTime { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public virtual Device Device { get; set; }

    }
}