////using Kiko.API.Helpers; 
// using Kiko.Models;
//using System; 
//using System.Linq; 
//using System.Net; 
//using System.Web.Http; 


//using Kiko.Repository; 
//namespace Kiko.API 
// { 
//  public class FuelsController : ApiController 
//   { 
//    private FuelsRepository _FuelsRepository = new FuelsRepository(); 
//    // GET odata/Fuels 
 
// public IHttpActionResult Get() 
// { 
//return Ok(_FuelsRepository.GetFuelss()); 
//} 
//  // GET odata/Fuels('key') 

//public IHttpActionResult Get( int key) 
//{ 
//  var _Fuels = _FuelsRepository.GetFuels(key); 
//return Ok(_Fuels); 
//} 
// [HttpPost] 
// public IHttpActionResult Post(Fuels item) 
// { 
//   if (!ModelState.IsValid) 
//   { 
//     return BadRequest(ModelState); 
// } 
//_FuelsRepository.Add(item); 
//return Created(item);
//} 
// public IHttpActionResult Put( int key, Fuels item) 
//  { 
//    if (!ModelState.IsValid) 
//   { 
//      return BadRequest(ModelState); 
// } 
//_FuelsRepository.Update(key, item); 
//return StatusCode(HttpStatusCode.NoContent); 
//     } 
// public IHttpActionResult Patch( int key, Delta<Fuels> patch) 
//{ 
//   if (!ModelState.IsValid) 
//  { 
//     return BadRequest(ModelState); 
// } 
//var currentFuels = _FuelsRepository.GetFuels(key); 
//if (currentFuels == null) 
//{ 
//   return NotFound(); 
//} 
//patch.Patch(currentFuels); 
//return StatusCode(HttpStatusCode.NoContent); 
//} 
// public IHttpActionResult Delete( int key) { _FuelsRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
//} 
//}