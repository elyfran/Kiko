using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Kiko.Models;
using System.Collections.Generic;

namespace Kiko.Repository
{
    public class EventTypeRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
        public IEnumerable<EventType> GetEventTypes()
        {
            var sql = @"select * from EventType ;  Select * from Eventnote ; 
 ";
            var multi = db.QueryMultiple(sql);
            var _EventTypes = multi.Read<EventType>().ToList();
            var _Eventnotes = multi.Read<Eventnote>().ToList();

            foreach (var item in _EventTypes)
            {
                item.Eventnotes = _Eventnotes.FindAll(x => x.EventTypeId == item.Id);

            }
            return _EventTypes;
        }
        public EventType GetEventType(byte Id)
        {
            return db.Query<EventType>("SELECT * FROM EventType WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
        }
        public void Add(EventType item)
        {
            db.Execute("INSERT INTO EventType (Id,Title)  VALUES(@Id,@Title)", item);
        }

        public void Update(byte Id, EventType item)
        {
            db.Execute("UPDATE EventType SET Id=@Id,Title=@Title WHERE Id =@Id", new { Id, item.Title });
        }

        public void Delete(int Id)
        {
            db.Execute("DELETE FROM EventType WHERE Id =@Id  ", new { Id });
        }
    }
}