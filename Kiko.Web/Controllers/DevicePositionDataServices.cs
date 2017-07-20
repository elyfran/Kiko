//using Kiko.API.Helpers; 
using Kiko.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;


using Kiko.Repository;
namespace Kiko.API
{
    public class DevicePositionDataController : ApiController
    {
        private DevicePositionDataRepository _DevicePositionDataRepository = new DevicePositionDataRepository();
        // GET odata/DevicePositionData 

        public IHttpActionResult Get()
        {
            return Ok(_DevicePositionDataRepository.GetDevicePositionDatas());
        }
        // GET odata/DevicePositionData('key') 

        public IHttpActionResult Get(int key)
        {
            var _DevicePositionData = _DevicePositionDataRepository.GetDevicePositionData(key);
            return Ok(_DevicePositionData);
        }
        [HttpPost]
        public IHttpActionResult Post(DevicePositionData item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _DevicePositionDataRepository.Add(item);
            return Created(item);
        }
        public IHttpActionResult Put(int key, DevicePositionData item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _DevicePositionDataRepository.Update(key, item);
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult Patch(int key, Delta<DevicePositionData> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentDevicePositionData = _DevicePositionDataRepository.GetDevicePositionData(key);
            if (currentDevicePositionData == null)
            {
                return NotFound();
            }
            patch.Patch(currentDevicePositionData);
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult Delete(int key) { _DevicePositionDataRepository.Delete(key); return StatusCode(HttpStatusCode.NoContent); }
    }
}