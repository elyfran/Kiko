using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Kiko.Models;
using System.Collections.Generic;

namespace Kiko.Repository
{
    public class FuelsRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
        public IEnumerable<Fuels> GetFuelss()
        {
            var sql = @"select * from Fuels ;  Select * from Device ; 
 ";
            var multi = db.QueryMultiple(sql);
            var _Fuelss = multi.Read<Fuels>().ToList();
            var _Devices = multi.Read<Device>().ToList();

            foreach (var item in _Fuelss)
            {
                item.Devices = _Devices.FindAll(x => x.FuelsId == item.Id);

            }
            return _Fuelss;
        }
        public Fuels GetFuels(byte Id)
        {
            return db.Query<Fuels>("SELECT * FROM Fuels WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
        }
        public void Add(Fuels item)
        {
            db.Execute("INSERT INTO Fuels (Id,Name,FuelTank,inCity,inSuperhighway)  VALUES(@Id,@Name,@FuelTank,@inCity,@inSuperhighway)", item);
        }

        public void Update(byte Id, Fuels item)
        {
            db.Execute("UPDATE Fuels SET Id=@Id,Name=@Name,FuelTank=@FuelTank,inCity=@inCity,inSuperhighway=@inSuperhighway WHERE Id =@Id", new { Id, item.Name, item.FuelTank, item.inCity, item.inSuperhighway });
        }

        public void Delete(int Id)
        {
            db.Execute("DELETE FROM Fuels WHERE Id =@Id  ", new { Id });
        }
    }
}