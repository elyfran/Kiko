//using Kiko.API.Helpers; 
using Kiko.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using Kiko.Repository;
namespace Kiko.API
{
    public class DeviceController : ApiController
    {
        private DeviceRepository _DeviceRepository = new DeviceRepository();
        // GET odata/Device 
        [EnableQuery(MaxExpansionDepth = 3, MaxSkip = 10, MaxTop = 10, PageSize = 10)]
        public IHttpActionResult Get()
        {
            return Ok(_DeviceRepository.GetDevices());
        }
        // GET odata/Device('key') 
        [EnableQuery]
        public IHttpActionResult Get( int key)
        {
            var _Device = _DeviceRepository.GetDevice(key);
            return Ok(_Device);
        }
        [HttpPost]
        public IHttpActionResult Post(Device item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _DeviceRepository.Add(item);
            return Created(item);
        }
        public IHttpActionResult Put( int key, Device item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _DeviceRepository.Update(key, item);
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult Patch( int key, Delta<Device> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentDevice = _DeviceRepository.GetDevice(key);
            if (currentDevice == null)
            {
                return NotFound();
            }
            patch.Patch(currentDevice);
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult Delete( int key) { _DeviceRepository.Delete(key); return StatusCode(HttpStatusCode.NoContent); }
    }
}