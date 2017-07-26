////using Kiko.API.Helpers; 
//using Kiko.Models;
//using System;
//using System.Linq;
//using System.Net;
//using System.Web.Http;


//using Kiko.Repository;
//namespace Kiko.API
//{
//    public class DevicePositionDataController : ApiController
//    {
//        private DevicePositionDataRepository _DevicePositionDataRepository = new DevicePositionDataRepository();
//        // GET odata/DevicePositionData 

//        public IHttpActionResult Get()
//        {
//            return Ok(_DevicePositionDataRepository.GetDevicePositionDatas());
//        }
//        // GET odata/DevicePositionData('key') 

//        public IHttpActionResult Get(long key)
//        {
//            var _DevicePositionData = _DevicePositionDataRepository.GetDevicePositionData(key);
//            if (_DevicePositionData == null)
//                return NotFound();
//            else
           
//                return Ok(_DevicePositionData);
            

//        }
//        [HttpPost]
//        public IHttpActionResult Post(DevicePositionData item)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            _DevicePositionDataRepository.Add(item);
//            return Ok(item);
//        }

//    }
//}