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
        private readonly IUserService _userService;

        public BpkpService(AppDbContext context, IUserService userService)
        {
            this._context = context;
            this._userService = userService;
        }
        public async Task<Bpkb> CreateAsync(Bpkb request)
        {
            _context.Bpkbs.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }


        public async Task<IEnumerable<BpkbResponse>> GetAsync(bool isLoggedInUser)
        {
            // Ambil data pengguna (hanya satu query)
            var users = await _context.Users.ToDictionaryAsync(u => u.Id, u => u.UserName);

            IQueryable<Bpkb> query = _context.Bpkbs.Include(b => b.StorageLocation);

            if (isLoggedInUser)
            {
                // Ambil nama pengguna saat ini
                var currentUser = _userService.UserId;

                // Ambil ID pengguna dari nama pengguna saat ini
                var userId = _context.Users.FirstOrDefault(u => u.Id == currentUser)?.Id;

                // Filter BPKB berdasarkan ID pengguna saat ini
                query = query.Where(bpkb => bpkb.CreatedBy == userId);
            }

            var bpkbs = await query.ToListAsync();

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
                CreatedBy = users.TryGetValue(bpkb.CreatedBy, out var userName) ? userName : "Unknown"
            }).ToList();

            return result;
        }
    }
}
