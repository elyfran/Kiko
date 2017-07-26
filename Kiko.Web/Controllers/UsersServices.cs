////using Kiko.API.Helpers; 
// using Kiko.Models;
//using System; 
//using System.Linq; 
//using System.Net; 
//using System.Web.Http; 


//using Kiko.Repository; 
//namespace Kiko.API 
// { 
//  public class UsersController : ApiController 
//   { 
//    private UsersRepository _UsersRepository = new UsersRepository(); 
//    // GET odata/Users 
 
// public IHttpActionResult Get() 
// { 
//return Ok(_UsersRepository.GetUserss()); 
//} 
//  // GET odata/Users('key') 

//public IHttpActionResult Get( int key) 
//{ 
//  var _Users = _UsersRepository.GetUsers(key); 
//return Ok(_Users); 
//} 
// [HttpPost] 
// public IHttpActionResult Post(Users item) 
// { 
//   if (!ModelState.IsValid) 
//   { 
//     return BadRequest(ModelState); 
// } 
//_UsersRepository.Add(item); 
//return Created(item);
//} 
// public IHttpActionResult Put( int key, Users item) 
//  { 
//    if (!ModelState.IsValid) 
//   { 
//      return BadRequest(ModelState); 
// } 
//_UsersRepository.Update(key, item); 
//return StatusCode(HttpStatusCode.NoContent); 
//     } 
// public IHttpActionResult Patch( int key, Delta<Users> patch) 
//{ 
//   if (!ModelState.IsValid) 
//  { 
//     return BadRequest(ModelState); 
// } 
//var currentUsers = _UsersRepository.GetUsers(key); 
//if (currentUsers == null) 
//{ 
//   return NotFound(); 
//} 
//patch.Patch(currentUsers); 
//return StatusCode(HttpStatusCode.NoContent); 
//} 
// public IHttpActionResult Delete( int key) { _UsersRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
//} 
//}