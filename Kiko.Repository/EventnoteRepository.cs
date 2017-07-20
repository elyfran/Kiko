using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Kiko.Models;
using System.Collections.Generic;

namespace Kiko.Repository
{
    public class EventnoteRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
        public IEnumerable<Eventnote> GetEventnotes()
        {
            var sql = @"select * from Eventnote ;  Select * from EventType ;  Select * from Device ; 
 ";
            var multi = db.QueryMultiple(sql);
            var _Eventnotes = multi.Read<Eventnote>().ToList();
            var _EventTypes = multi.Read<EventType>().ToList();
            var _Devices = multi.Read<Device>().ToList();

            foreach (var item in _Eventnotes)
            {
                item.EventType = _EventTypes.Find(x => x.Id == item.EventTypeId);
                item.Device = _Devices.Find(x => x.Id == item.DeviceId);

            }
            return _Eventnotes;
        }
        public Eventnote GetEventnote(int Id)
        {
            return db.Query<Eventnote>("SELECT * FROM Eventnote WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
        }
        public void Add(Eventnote item)
        {
            db.Execute("INSERT INTO Eventnote (Id,DevieceId,IMEI,FiredTime,FiredDate,FiredLat,FiredLong,EventTypeId,Address)  VALUES(@Id,@DevieceId,@IMEI,@FiredTime,@FiredDate,@FiredLat,@FiredLong,@EventTypeId,@Address)", item);
        }

        public void Update(int Id, Eventnote item)
        {
            db.Execute("UPDATE Eventnote SET Id=@Id,DevieceId=@DevieceId,IMEI=@IMEI,FiredTime=@FiredTime,FiredDate=@FiredDate,FiredLat=@FiredLat,FiredLong=@FiredLong,EventTypeId=@EventTypeId,Address=@Address WHERE Id =@Id", new { Id, item.DevieceId, item.IMEI, item.FiredTime, item.FiredDate, item.FiredLat, item.FiredLong, item.EventTypeId, item.Address });
        }

        public void Delete(int Id)
        {
            db.Execute("DELETE FROM Eventnote WHERE Id =@Id  ", new { Id });
        }
    }
}