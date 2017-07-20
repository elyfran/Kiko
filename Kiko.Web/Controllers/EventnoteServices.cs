//using Kiko.API.Helpers; 
 using Kiko.Models;
using System; 
using System.Linq; 
using System.Net; 
using System.Web.Http; 


using Kiko.Repository; 
namespace Kiko.API 
 { 
  public class EventnoteController : ApiController 
   { 
    private EventnoteRepository _EventnoteRepository = new EventnoteRepository(); 
    // GET odata/Eventnote 
 
 public IHttpActionResult Get() 
 { 
return Ok(_EventnoteRepository.GetEventnotes()); 
} 
  // GET odata/Eventnote('key') 

public IHttpActionResult Get( int key) 
{ 
  var _Eventnote = _EventnoteRepository.GetEventnote(key); 
return Ok(_Eventnote); 
} 
 [HttpPost] 
 public IHttpActionResult Post(Eventnote item) 
 { 
   if (!ModelState.IsValid) 
   { 
     return BadRequest(ModelState); 
 } 
_EventnoteRepository.Add(item); 
return Created(item);
} 
 public IHttpActionResult Put( int key, Eventnote item) 
  { 
    if (!ModelState.IsValid) 
   { 
      return BadRequest(ModelState); 
 } 
_EventnoteRepository.Update(key, item); 
return StatusCode(HttpStatusCode.NoContent); 
     } 
 public IHttpActionResult Patch( int key, Delta<Eventnote> patch) 
{ 
   if (!ModelState.IsValid) 
  { 
     return BadRequest(ModelState); 
 } 
var currentEventnote = _EventnoteRepository.GetEventnote(key); 
if (currentEventnote == null) 
{ 
   return NotFound(); 
} 
patch.Patch(currentEventnote); 
return StatusCode(HttpStatusCode.NoContent); 
} 
 public IHttpActionResult Delete( int key) { _EventnoteRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
} 
}