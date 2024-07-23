﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    [ApiController]
    public class BpkpController : ControllerBase
    {
        private readonly IBpkpService _bpkpService;
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;

        public BpkpController(IBpkpService bpkpService, ILocationService locationService, IUserService userService)
        {
            this._bpkpService = bpkpService;
            this._locationService = locationService;
            this._userService = userService;
        }

        // GET: api/Hotels
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<LocationResponse>>> GetBpkp()
        {
            var response = await _bpkpService.GetAsync();
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
        public async Task<ActionResult> Post(BpkpRequest request)
        {
            var location = await _locationService.ExistAsync(request.LocationId);
            var userId = _userService.UserId;
            var agreementNumber = Guid.NewGuid().ToString();
            if (location == null)
            {
                throw new ArgumentException("Invalid location ID");
            }
            Bpkb bpkb = new()
            {
                AgreementNumber = agreementNumber,
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
