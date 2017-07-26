//using System.Data;
//using System.Linq;
//using System.Data.SqlClient;
//using Dapper;
//using Kiko.Models;
//using System.Collections.Generic;

//namespace Kiko.Repository
//{
//    public class FencesRepository
//    {
//        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
//        public IEnumerable<Fences> GetFencess()
//        {
//            var sql = @"select * from Fences ;  Select * from Device ; 
// ";
//            var multi = db.QueryMultiple(sql);
//            var _Fencess = multi.Read<Fences>().ToList();
//            var _Devices = multi.Read<Device>().ToList();

//            foreach (var item in _Fencess)
//            {
//                item.Devices = _Devices.FindAll(x => x.FencesId == item.Id);

//            }
//            return _Fencess;
//        }
//        public Fences GetFences(byte Id)
//        {
//            return db.Query<Fences>("SELECT * FROM Fences WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
//        }
//        public void Add(Fences item)
//        {
//            db.Execute("INSERT INTO Fences (Id,IMEI,DeviceId,Title,CenterLat,CenterLong,RadiusMeter,Description,ProvinceBound,CityBound)  VALUES(@Id,@IMEI,@DeviceId,@Title,@CenterLat,@CenterLong,@RadiusMeter,@Description,@ProvinceBound,@CityBound)", item);
//        }

//        public void Update(byte Id, Fences item)
//        {
//            db.Execute("UPDATE Fences SET Id=@Id,IMEI=@IMEI,DeviceId=@DeviceId,Title=@Title,CenterLat=@CenterLat,CenterLong=@CenterLong,RadiusMeter=@RadiusMeter,Description=@Description,ProvinceBound=@ProvinceBound,CityBound=@CityBound WHERE Id =@Id", new { Id, item.IMEI, item.DeviceId, item.Title, item.CenterLat, item.CenterLong, item.RadiusMeter, item.Description, item.ProvinceBound, item.CityBound });
//        }

//        public void Delete(int Id)
//        {
//            db.Execute("DELETE FROM Fences WHERE Id =@Id  ", new { Id });
//        }
//    }
//}