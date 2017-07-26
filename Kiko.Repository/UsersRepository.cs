//using System.Data;
//using System.Linq;
//using System.Data.SqlClient;
//using Dapper;
//using Kiko.Models;
//using System.Collections.Generic;

//namespace Kiko.Repository
//{
//    public class UsersRepository
//    {
//        private IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=gpsDB;Integrated Security=True");
//        //public IEnumerable<Users> GetUserss()
//        //{
         
//        //}
//        public Users GetUsers(int Id)
//        {
//            return db.Query<Users>("SELECT * FROM Users WHERE Id=@Id", new { Id = Id }).SingleOrDefault();
//        }
//        public void Add(Users item)
//        {
//            db.Execute("INSERT INTO Users (Id,FullName,Mobile,imagePath,username,password,Address,TelegramId,Email,Admin,DeviceLimit,Disabled,ExpirationTime,Latitude,Longitude)  VALUES(@Id,@FullName,@Mobile,@imagePath,@username,@password,@Address,@TelegramId,@Email,@Admin,@DeviceLimit,@Disabled,@ExpirationTime,@Latitude,@Longitude)", item);
//        }

//        public void Update(int Id, Users item)
//        {
//            db.Execute("UPDATE Users SET Id=@Id,FullName=@FullName,Mobile=@Mobile,imagePath=@imagePath,username=@username,password=@password,Address=@Address,TelegramId=@TelegramId,Email=@Email,Admin=@Admin,DeviceLimit=@DeviceLimit,Disabled=@Disabled,ExpirationTime=@ExpirationTime,Latitude=@Latitude,Longitude=@Longitude WHERE Id =@Id", new { Id, item.FullName, item.Mobile, item.imagePath, item.username, item.password, item.Address, item.TelegramId, item.Email, item.Admin, item.DeviceLimit, item.Disabled, item.ExpirationTime, item.Latitude, item.Longitude });
//        }

//        public void Delete(int Id)
//        {
//            db.Execute("DELETE FROM Users WHERE Id =@Id  ", new { Id });
//        }
//    }
//}