//using Kiko.API.Helpers; 
 using Kiko.Models;
using System; 
using System.Linq; 
using System.Net; 
using System.Web.Http; 


using Kiko.Repository; 
namespace Kiko.API 
 { 
  public class DeviceDetailedController : ApiController 
   { 
    private DeviceDetailedRepository _DeviceDetailedRepository = new DeviceDetailedRepository(); 
    // GET odata/DeviceDetailed 
 
 public IHttpActionResult Get() 
 { 
return Ok(_DeviceDetailedRepository.GetDeviceDetaileds()); 
} 
  // GET odata/DeviceDetailed('key') 

public IHttpActionResult Get( int key) 
{ 
  var _DeviceDetailed = _DeviceDetailedRepository.GetDeviceDetailed(key); 
return Ok(_DeviceDetailed); 
} 
 [HttpPost] 
 public IHttpActionResult Post(DeviceDetailed item) 
 { 
   if (!ModelState.IsValid) 
   { 
     return BadRequest(ModelState); 
 } 
_DeviceDetailedRepository.Add(item); 
return Created(item);
} 
 public IHttpActionResult Put( int key, DeviceDetailed item) 
  { 
    if (!ModelState.IsValid) 
   { 
      return BadRequest(ModelState); 
 } 
_DeviceDetailedRepository.Update(key, item); 
return StatusCode(HttpStatusCode.NoContent); 
     } 
 public IHttpActionResult Patch( int key, Delta<DeviceDetailed> patch) 
{ 
   if (!ModelState.IsValid) 
  { 
     return BadRequest(ModelState); 
 } 
var currentDeviceDetailed = _DeviceDetailedRepository.GetDeviceDetailed(key); 
if (currentDeviceDetailed == null) 
{ 
   return NotFound(); 
} 
patch.Patch(currentDeviceDetailed); 
return StatusCode(HttpStatusCode.NoContent); 
} 
 public IHttpActionResult Delete( int key) { _DeviceDetailedRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
} 
}