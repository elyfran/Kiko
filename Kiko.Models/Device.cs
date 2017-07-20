using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Kiko.Models
{
    public class Device
    {
        public Device()
        {
            DevicePositionDatas = new List<DevicePositionData>();
            Eventnotes = new List<Eventnote>();

        }

        [Required]

        public long Id { get; set; }
        [Required]
        [StringLength(17)]
        public string IMEI { get; set; }
        [Required]
        [StringLength(11)]
        public string DeviceName { get; set; }
        [StringLength(50)]
        public string VehicleTitle { get; set; }

        public bool? Offline { get; set; }
        [StringLength(50)]
        public string PlateNumber { get; set; }
        [Required]

        public int OwnerId { get; set; }
        [Required]

        public int DriverId { get; set; }
        [Required]
        [StringLength(12)]
        public string SIMnumber { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime ActivatedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime ExpirationDate { get; set; }
        [Required]

        public byte Fuelid { get; set; }

        public int? OrganazitionId { get; set; }
        [StringLength(20)]
        public string Usage { get; set; }

        public bool? Follow { get; set; }

        public bool? Bounded { get; set; }

        public byte? FenceId { get; set; }
        public virtual Users User_owned { get; set; }
        public virtual Users User_drived { get; set; }
        public virtual Fuels Fuels { get; set; }
        public virtual ICollection<DevicePositionData> DevicePositionDatas { get; set; }
        public virtual ICollection<Eventnote> Eventnotes { get; set; }
        public virtual DeviceDetailed DeviceDetailed { get; set; }
        public virtual Fences Fences { get; set; }
        public virtual Organizations Organizations { get; set; }

    }
}