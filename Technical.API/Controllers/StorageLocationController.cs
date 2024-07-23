using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;
using Technical.API.Repository.Storage;

namespace Technical.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StorageLocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public StorageLocationController(ILocationService locationService)
        {
            this._locationService = locationService;
        }

        // GET: api/Hotels
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<LocationResponse>>> GetLocation()
        {
            var response = await _locationService.GetAsync();
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(LocationRequest request)
        {
            var response = await _locationService.CreateAsync(request);
            if (string.IsNullOrEmpty(response))
            {
                return BadRequest(response);
            }
            return CreatedAtAction(nameof(GetLocation), new { id = response });
        }
    }
}
