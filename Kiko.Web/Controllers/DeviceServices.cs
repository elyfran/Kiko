//using Kiko.API.Helpers; 
using Kiko.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

using Kiko.Repository;
using Marvin.JsonPatch;
using System.Web.Http.Routing;
using System.Web;

namespace Kiko.API
{

    public class DeviceController : ApiController
    {
        private DeviceRepository _DeviceRepository = new DeviceRepository();
        // GET odata/Device 
        const int maxPageSize = 10;
        [Route("api/devices", Name = "AlldevicesList")]
        public IHttpActionResult Get(string fields = null, string sort = "Id", int? page = 1, int pageSize = maxPageSize)
        {


            var _devices = _DeviceRepository.GetDevices(fields, sort, page, pageSize);
            // ensure the page size isn't larger than the maximum.
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            // calculate data for metadata
            var totalCount = _devices.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 1 ? urlHelper.Link("AlldevicesList",
                new
                {
                    page = page - 1,
                    pageSize = pageSize,
                    sort = sort
                    ,
                    fields = fields
                  
                }) : "";
            var nextLink = page < totalPages ? urlHelper.Link("AlldevicesList",
                new
                {
                    page = page + 1,
                    pageSize = pageSize,
                    sort = sort
                     ,
                    fields = fields
                    
                }) : "";


            var paginationHeader = new
            {
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages,
                previousPageLink = prevLink,
                nextPageLink = nextLink
            };

            HttpContext.Current.Response.Headers.Add("X-Pagination",
               Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));


            // return result
            return Ok(_devices);
        }
        // GET odata/Device('key') 
 
        public IHttpActionResult Get( long id,string fields="*")
        {
            var _Device = _DeviceRepository.GetDeviceById(id,fields);
            if (_Device==null)
            {
                return NotFound();
            }
            else
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
            return Ok(item);
        }
        public IHttpActionResult Put( long key, Device item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _DeviceRepository.Update(key, item);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPatch]
        public IHttpActionResult Patch(long id, [FromBody]JsonPatchDocument<Device> devicePatchDocument)
        {
            // get the expense from the repository
            var device = _DeviceRepository.GetDeviceById(id);

            // apply the patch document 
            devicePatchDocument.ApplyTo(device);

            return Ok(devicePatchDocument);
            // changes have been applied.  Submit to backend, ... 
        }
        public IHttpActionResult Delete(long  id) {
            _DeviceRepository.Delete(id);
            return   StatusCode(HttpStatusCode.NoContent);
        }
    }
}