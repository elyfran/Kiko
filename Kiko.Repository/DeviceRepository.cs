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
        private const int maxPagesize = 10;
        public IEnumerable<Device> GetDevices(string fields = null, string orderby = "Id", int? top = null, int? page = 1, int? pagesize = maxPagesize)
        {
            fields = fields ?? "*";
            int? skip = (page - 1) * 10;
          var sql = @"SELECT "+ top!=null?" TOP "+top.ToString():"" +
                fields+" FROM Device+ ORDER BY "+orderby +"  " +
                page != null && top==null  ? " OFFSET  "+skip.ToString()+" ROWS       FETCH First "+pagesize.ToString()+" ROWS only":"";
            return db.QueryAsync<Device>(sql).Result.ToList();
  
        }
        public Device GetDeviceById(long Id, string fields = null)
        {
            fields = fields ?? "*";
            string sql = "Select " + fields + " from  Device Where Id=@Id";
            return db.Query<Device>(sql, new { Id = Id }).SingleOrDefault();
        }
        public Device GetDeviceByIMEI(string IEMI, string fields = null)
        {
            fields = fields ?? "*";
            string sql = "Select " + fields + " from  Device Where IEMI=@IEMI";
            return db.Query<Device>(sql, new { IEMI = IEMI }).SingleOrDefault();
        }
        public IEnumerable<Device> GetDeviceBindedtoUserID(int ownedId, string fields = null)
        {
            fields = fields ?? "*";
            string sql = "Select " + fields + " from  Device Where OwnerId=@ownedId";
            return db.Query<Device>(sql, new { ownedId = ownedId }).ToList();

        }
        public Device GetDeviceDrivedByUserId(int DriverId, string fields = null)
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
            db.Execute("UPDATE Device SET DeviceName=@DeviceName,VehicleTitle=@VehicleTitle,Offline=@Offline,PlateNumber=@PlateNumber,OwnerId=@OwnerId,DriverId=@DriverId,SIMnumber=@SIMnumber,ActivatedDate=@ActivatedDate,ExpirationDate=@ExpirationDate,Fuelid=@Fuelid,OrganazitionId=@OrganazitionId,Usage=@Usage,Follow=@Follow,Bounded=@Bounded,FenceId=@FenceId WHERE Id =@Id", new { item.DeviceName, item.VehicleTitle, item.Offline, item.PlateNumber, item.OwnerId, item.DriverId, item.SIMnumber, item.ActivatedDate, item.ExpirationDate, item.Fuelid, item.OrganazitionId, item.Usage, item.Follow, item.Bounded, item.FenceId });
        }

        public void Delete(long Id)
        {
            db.Execute("DELETE FROM Device WHERE Id =@Id  ", new { Id });
        }
    }
}