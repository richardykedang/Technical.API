using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical.API.Models;
using Technical.API.Models.Bpkp;
using Technical.API.Models.Bpkp.Request;
using Technical.API.Models.Bpkp.Response;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;
using Technical.API.Repository.Auth;
using Technical.API.Repository.Bpkp;
using Technical.API.Repository.Storage;

namespace Technical.API.Controllers
{
    [Route("api/bpkp")]
    [ApiController]
    [Authorize]
    public class BpkpController : ControllerBase
    {
        private readonly IBpkpService _bpkpService;
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;
        private ResponseDto _response;

        public BpkpController(IBpkpService bpkpService, ILocationService locationService, IUserService userService)
        {
            this._bpkpService = bpkpService;
            this._locationService = locationService;
            this._userService = userService;
            _response = new ResponseDto();
        }

   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BpkbResponse>>> GetBpkp([FromQuery] bool isLoggedInUser = false)
        {
            var response = await _bpkpService.GetAsync(isLoggedInUser);
            if (response == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Retrieved Failed";
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.Result = response;
            return Ok(_response);
        }

      
        [HttpPost]
        public async Task<ActionResult> Post(BpkpRequest request)
        {
            var location = await _locationService.ExistAsync(request.LocationId);
            var userId = _userService.UserId;
            
            if (location == null)
            {
                throw new ArgumentException("Invalid location ID");
            }
            Bpkb bpkb = new()
            {
                AgreementNumber = request.AgreementNumber,
                BranchId = request.BranchId,
                BpkbNo = request.BpkbNo,
                BpkbDateIn = request.BpkbDateIn,
                BpkbDate = request.BpkbDate,
                FakturNo = request.FakturNo,
                FakturDate = request.FakturDate,
                PoliceNo = request.PoliceNo,
                LocationId = location.LocationId,
                CreatedBy = userId,
                LastUpdatedBy = userId,
                LastUpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            

            };
            var createdBpkb = await _bpkpService.CreateAsync(bpkb);
            return CreatedAtAction(nameof(GetBpkp), new { id = createdBpkb.AgreementNumber });

        }
    }
}
