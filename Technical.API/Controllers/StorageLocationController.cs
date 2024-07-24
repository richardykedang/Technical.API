using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical.API.Models;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;
using Technical.API.Repository.Storage;

namespace Technical.API.Controllers
{
    [Route("api/location")]
    [ApiController]
    [Authorize]
    public class StorageLocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private ResponseDto _response;
        public StorageLocationController(ILocationService locationService)
        {
            this._locationService = locationService;
            _response = new ResponseDto();
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationResponse>>> Get()
        {
            var response = await _locationService.GetAsync();
            if (response == null)
            {
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.Result = response;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResponseDto> Post(LocationRequest request)
        {
            var response = await _locationService.CreateAsync(request);
            if (string.IsNullOrEmpty(response))
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to created";
                return _response;
            }
            _response.Result = response;
            _response.IsSuccess = true;

            return _response;
        }
    }
}
