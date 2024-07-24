using Microsoft.EntityFrameworkCore;
using Technical.API.Data;
using Technical.API.Models.Bpkp;
using Technical.API.Models.Bpkp.Request;
using Technical.API.Models.Bpkp.Response;
using Technical.API.Models.StorageLoc;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;
using Technical.API.Repository.Auth;

namespace Technical.API.Repository.Bpkp
{
    public class BpkpService : IBpkpService
    {
        private readonly AppDbContext _context;


        public BpkpService(AppDbContext context)
        {
            this._context = context;

        }
        public async Task<Bpkb> CreateAsync(Bpkb request)
        {
            _context.Bpkbs.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }


        public async Task<IEnumerable<BpkbResponse>> GetAsync()
        {
            var bpkbs = await _context.Bpkbs.Include(b => b.StorageLocation).ToListAsync();

            var result = bpkbs.Select(bpkb => new BpkbResponse
            {
                AgreementNumber = bpkb.AgreementNumber,
                BranchId = bpkb.BranchId,
                BpkbNo = bpkb.BpkbNo,
                BpkbDateIn = bpkb.BpkbDateIn,
                BpkbDate = bpkb.BpkbDate,
                FakturNo = bpkb.FakturNo,
                FakturDate = bpkb.FakturDate,
                PoliceNo = bpkb.PoliceNo,
                LocationId = bpkb.LocationId,
                LocationName = bpkb.StorageLocation?.LocationName,
                CreatedBy = _context.Users.Where(u => u.Id == bpkb.CreatedBy)
                .Select(u => u.UserName)
                .FirstOrDefault()
            }).ToList();

            return result;
        }
    }
}
