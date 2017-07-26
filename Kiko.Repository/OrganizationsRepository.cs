//using System.Data;
//using System.Linq;
//using System.Data.SqlClient;
//using Dapper;
//using Kiko.Models;
//using System.Collections.Generic;

//namespace Kiko.Repository
//{
//    public class OrganizationsRepository
//    {
//        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
//        public IEnumerable<Organizations> GetOrganizationss()
//        {
//            var sql = @"select * from Organizations ;  Select * from Device ; 
// ";
//            var multi = db.QueryMultiple(sql);
//            var _Organizationss = multi.Read<Organizations>().ToList();
//            var _Devices = multi.Read<Device>().ToList();

//            foreach (var item in _Organizationss)
//            {
//                item.Devices = _Devices.FindAll(x => x.OrganizationsId == item.Id);

//            }
//            return _Organizationss;
//        }
//        public Organizations GetOrganizations(int Id)
//        {
//            return db.Query<Organizations>("SELECT * FROM Organizations WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
//        }
//        public void Add(Organizations item)
//        {
//            db.Execute("INSERT INTO Organizations (Id,Title,City,province,Address,Lat,Long)  VALUES(@Id,@Title,@City,@province,@Address,@Lat,@Long)", item);
//        }

//        public void Update(int Id, Organizations item)
//        {
//            db.Execute("UPDATE Organizations SET Id=@Id,Title=@Title,City=@City,province=@province,Address=@Address,Lat=@Lat,Long=@Long WHERE Id =@Id", new { Id, item.Title, item.City, item.province, item.Address, item.Lat, item.Long });
//        }

//        public void Delete(int Id)
//        {
//            db.Execute("DELETE FROM Organizations WHERE Id =@Id  ", new { Id });
//        }
//    }
//}