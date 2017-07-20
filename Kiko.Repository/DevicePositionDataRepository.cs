using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Kiko.Models;
using System.Collections.Generic;

namespace Kiko.Repository
{
    public class DevicePositionDataRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
        public IEnumerable<DevicePositionData> GetDevicePositionDatas()
        {
            var sql = @"select * from DevicePositionData ;  Select * from Device ; 
 ";
            var multi = db.QueryMultiple(sql);
            var _DevicePositionDatas = multi.Read<DevicePositionData>().ToList();
            var _Devices = multi.Read<Device>().ToList();

            foreach (var item in _DevicePositionDatas)
            {
                item.Device = _Devices.Find(x => x.Id == item.DeviceId);

            }
            return _DevicePositionDatas;
        }
        public DevicePositionData GetDevicePositionData(long Id)
        {
            return db.Query<DevicePositionData>("SELECT * FROM DevicePositionData WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
        }
        public void Add(DevicePositionData item)
        {
            db.Execute("INSERT INTO DevicePositionData (Id,IMEI,DeviceId,Latitude,Longitude,Spead,Course,insertedDate,insertedTime,Address)  VALUES(@Id,@IMEI,@DeviceId,@Latitude,@Longitude,@Spead,@Course,@insertedDate,@insertedTime,@Address)", item);
        }

        public void Update(long Id, DevicePositionData item)
        {
            db.Execute("UPDATE DevicePositionData SET Id=@Id,IMEI=@IMEI,DeviceId=@DeviceId,Latitude=@Latitude,Longitude=@Longitude,Spead=@Spead,Course=@Course,insertedDate=@insertedDate,insertedTime=@insertedTime,Address=@Address WHERE Id =@Id", new { Id, item.IMEI, item.DeviceId, item.Latitude, item.Longitude, item.Spead, item.Course, item.insertedDate, item.insertedTime, item.Address });
        }

        public void Delete(int Id)
        {
            db.Execute("DELETE FROM DevicePositionData WHERE Id =@Id  ", new { Id });
        }
    }
}