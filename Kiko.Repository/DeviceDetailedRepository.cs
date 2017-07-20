using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Kiko.Models;
using System.Collections.Generic;

namespace Kiko.Repository
{
    public class DeviceDetailedRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
        public IEnumerable<DeviceDetailed> GetDeviceDetaileds()
        {
            var sql = @"select * from DeviceDetailed ;  Select * from Device ; 
 ";
            var multi = db.QueryMultiple(sql);
            var _DeviceDetaileds = multi.Read<DeviceDetailed>().ToList();
            var _Devices = multi.Read<Device>().ToList();

            foreach (var item in _DeviceDetaileds)
            {
                item.Device = _Devices.Find(x => x.Id == item.DeviceId);

            }
            return _DeviceDetaileds;
        }
        public DeviceDetailed GetDeviceDetailed(long DeviceId)
        {
            return db.Query<DeviceDetailed>("SELECT * FROM DeviceDetailed WHERE DeviceId=@DeviceId", new { DeviceId = DeviceId }).SingleOrDefault();
        }
        public void Add(DeviceDetailed item)
        {
            db.Execute("INSERT INTO DeviceDetailed (DeviceId,Fueluse,Overspeed,BatteryPercent)  VALUES(@DeviceId,@Fueluse,@Overspeed,@BatteryPercent)", item);
        }

        public void Update(long DeviceId, DeviceDetailed item)
        {
            db.Execute("UPDATE DeviceDetailed SET DeviceId=@DeviceId,Fueluse=@Fueluse,Overspeed=@Overspeed,BatteryPercent=@BatteryPercent WHERE DeviceId =@DeviceId", new { DeviceId, item.Fueluse, item.Overspeed, item.BatteryPercent });
        }

        public void Delete(long DeviceId)
        {
            db.Execute("DELETE FROM DeviceDetailed WHERE DeviceId =@DeviceId  ", new { DeviceId });
        }
    }
}