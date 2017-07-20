using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class Eventnote
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public long DevieceId { get; set; }
        [Required]
        [StringLength(17)]
        public string IMEI { get; set; }
        public TimeSpan? FiredTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FiredDate { get; set; }
        [Required]
        [StringLength(50)]
        public string FiredLat { get; set; }
        [Required]
        [StringLength(50)]
        public string FiredLong { get; set; }
        [Required]
        public byte EventTypeId { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Device Device { get; set; }

    }
}