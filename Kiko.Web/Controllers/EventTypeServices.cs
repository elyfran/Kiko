////using Kiko.API.Helpers; 
// using Kiko.Models;
//using System; 
//using System.Linq; 
//using System.Net; 
//using System.Web.Http; 


//using Kiko.Repository; 
//namespace Kiko.API 
// { 
//  public class EventTypeController : ApiController 
//   { 
//    private EventTypeRepository _EventTypeRepository = new EventTypeRepository(); 
//    // GET odata/EventType 
 
// public IHttpActionResult Get() 
// { 
//return Ok(_EventTypeRepository.GetEventTypes()); 
//} 
//  // GET odata/EventType('key') 

//public IHttpActionResult Get( int key) 
//{ 
//  var _EventType = _EventTypeRepository.GetEventType(key); 
//return Ok(_EventType); 
//} 
// [HttpPost] 
// public IHttpActionResult Post(EventType item) 
// { 
//   if (!ModelState.IsValid) 
//   { 
//     return BadRequest(ModelState); 
// } 
//_EventTypeRepository.Add(item); 
//return Created(item);
//} 
// public IHttpActionResult Put( int key, EventType item) 
//  { 
//    if (!ModelState.IsValid) 
//   { 
//      return BadRequest(ModelState); 
// } 
//_EventTypeRepository.Update(key, item); 
//return StatusCode(HttpStatusCode.NoContent); 
//     } 
// public IHttpActionResult Patch( int key, Delta<EventType> patch) 
//{ 
//   if (!ModelState.IsValid) 
//  { 
//     return BadRequest(ModelState); 
// } 
//var currentEventType = _EventTypeRepository.GetEventType(key); 
//if (currentEventType == null) 
//{ 
//   return NotFound(); 
//} 
//patch.Patch(currentEventType); 
//return StatusCode(HttpStatusCode.NoContent); 
//} 
// public IHttpActionResult Delete( int key) { _EventTypeRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
//} 
//}