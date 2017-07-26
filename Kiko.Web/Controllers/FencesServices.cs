////using Kiko.API.Helpers; 
// using Kiko.Models;
//using System; 
//using System.Linq; 
//using System.Net; 
//using System.Web.Http; 


//using Kiko.Repository; 
//namespace Kiko.API 
// { 
//  public class FencesController : ApiController 
//   { 
//    private FencesRepository _FencesRepository = new FencesRepository(); 
//    // GET odata/Fences 
 
// public IHttpActionResult Get() 
// { 
//return Ok(_FencesRepository.GetFencess()); 
//} 
//  // GET odata/Fences('key') 

//public IHttpActionResult Get( int key) 
//{ 
//  var _Fences = _FencesRepository.GetFences(key); 
//return Ok(_Fences); 
//} 
// [HttpPost] 
// public IHttpActionResult Post(Fences item) 
// { 
//   if (!ModelState.IsValid) 
//   { 
//     return BadRequest(ModelState); 
// } 
//_FencesRepository.Add(item); 
//return Created(item);
//} 
// public IHttpActionResult Put( int key, Fences item) 
//  { 
//    if (!ModelState.IsValid) 
//   { 
//      return BadRequest(ModelState); 
// } 
//_FencesRepository.Update(key, item); 
//return StatusCode(HttpStatusCode.NoContent); 
//     } 
// public IHttpActionResult Patch( int key, Delta<Fences> patch) 
//{ 
//   if (!ModelState.IsValid) 
//  { 
//     return BadRequest(ModelState); 
// } 
//var currentFences = _FencesRepository.GetFences(key); 
//if (currentFences == null) 
//{ 
//   return NotFound(); 
//} 
//patch.Patch(currentFences); 
//return StatusCode(HttpStatusCode.NoContent); 
//} 
// public IHttpActionResult Delete( int key) { _FencesRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
//} 
//}