using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Kiko.Models;
using System.Collections.Generic;

namespace Kiko.Repository
{
    public class DeviceRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
        public IEnumerable<Device> GetDevices(string fields)
        {
            var sql = @"select * from Device ";
            var multi = db.QueryMultiple(sql);
            var _Devices = multi.Read<Device>().ToList();

            return _Devices;
        }
        public Device GetDeviceById(long Id,string fields=null)
        {
            return db.Query<Device>("SELECT * FROM Device WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
        }
        public IEnumerable<Device> GetDeviceBindedtoUserID(int ownedId,string fields=null)
        {
            fields = fields ?? "*";
            string sql = "Select "+fields+" from  Device Where OwnerId=@ownedId";
            return db.Query<Device>(sql, new { ownedId = ownedId }).ToList();

        }
        public Device GetDeviceDrivedByUserId(int DriverId, string fields=null)
        {
            fields = fields ?? "*";
            string sql = "Select " + fields + " from  Device Where DriverId=@DriverId";
            return db.Query<Device>(sql, new { driverId = DriverId }).FirstOrDefault();
          
        }

        public void Add(Device item)
        {
         
          
            db.Execute("INSERT INTO Device (IMEI,DeviceName,VehicleTitle,PlateNumber,OwnerId,DriverId,SIMnumber,ActivatedDate,ExpirationDate,Fuelid,OrganazitionId,Usage,Follow,Bounded,FenceId)  VALUES(,@IMEI,@DeviceName,@VehicleTitle,@PlateNumber,@OwnerId,@DriverId,@SIMnumber,@ActivatedDate,@ExpirationDate,@Fuelid,@OrganazitionId,@Usage,@Follow,@Bounded,@FenceId)", item);
        }

        public void Update(long Id, Device item)
        {
            db.Execute("UPDATE Device SET Id=@Id,IMEI=@IMEI,DeviceName=@DeviceName,VehicleTitle=@VehicleTitle,Offline=@Offline,PlateNumber=@PlateNumber,OwnerId=@OwnerId,DriverId=@DriverId,SIMnumber=@SIMnumber,ActivatedDate=@ActivatedDate,ExpirationDate=@ExpirationDate,Fuelid=@Fuelid,OrganazitionId=@OrganazitionId,Usage=@Usage,Follow=@Follow,Bounded=@Bounded,FenceId=@FenceId WHERE Id =@Id", new { Id, item.IMEI, item.DeviceName, item.VehicleTitle, item.Offline, item.PlateNumber, item.OwnerId, item.DriverId, item.SIMnumber, item.ActivatedDate, item.ExpirationDate, item.Fuelid, item.OrganazitionId, item.Usage, item.Follow, item.Bounded, item.FenceId });
        }

        public void Delete(int Id)
        {
            db.Execute("DELETE FROM Device WHERE Id =@Id  ", new { Id });
        }
    }
}