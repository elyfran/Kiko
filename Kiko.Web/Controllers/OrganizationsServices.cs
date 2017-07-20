//using Kiko.API.Helpers; 
using Kiko.Models;
using System.Net;
using System.Web.Http;
using Kiko.Repository;
namespace Kiko.API
{
    public class OrganizationsController : ApiController 
   { 
    private OrganizationsRepository _OrganizationsRepository = new OrganizationsRepository(); 
    // GET odata/Organizations 
 
 public IHttpActionResult Get() 
 { 
return Ok(_OrganizationsRepository.GetOrganizationss()); 
} 
  // GET odata/Organizations('key') 

public IHttpActionResult Get( int key) 
{ 
  var _Organizations = _OrganizationsRepository.GetOrganizations(key); 
return Ok(_Organizations); 
} 
 [HttpPost] 
 public IHttpActionResult Post(Organizations item) 
 { 
   if (!ModelState.IsValid) 
   { 
     return BadRequest(ModelState); 
 } 
_OrganizationsRepository.Add(item); 
return Created(item);
} 
 public IHttpActionResult Put( int key, Organizations item) 
  { 
    if (!ModelState.IsValid) 
   { 
      return BadRequest(ModelState); 
 } 
_OrganizationsRepository.Update(key, item); 
return StatusCode(HttpStatusCode.NoContent); 
     } 
 public IHttpActionResult Patch( int key, Delta<Organizations> patch) 
{ 
   if (!ModelState.IsValid) 
  { 
     return BadRequest(ModelState); 
 } 
var currentOrganizations = _OrganizationsRepository.GetOrganizations(key); 
if (currentOrganizations == null) 
{ 
   return NotFound(); 
} 
patch.Patch(currentOrganizations); 
return StatusCode(HttpStatusCode.NoContent); 
} 
 public IHttpActionResult Delete( int key) { _OrganizationsRepository.Delete(key);return StatusCode(HttpStatusCode.NoContent); } 
} 
}