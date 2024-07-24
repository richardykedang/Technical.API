using Microsoft.EntityFrameworkCore;
using Technical.API.Data;
using Technical.API.Models;
using Technical.API.Models.Bpkp;
using Technical.API.Models.StorageLoc;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;

namespace Technical.API.Repository.Storage
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;

        public LocationService(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<string> CreateAsync(LocationRequest request)
        {
            var locationId = Guid.NewGuid().ToString();
            var location = new StorageLocation()
            {
                LocationId = locationId,
                LocationName = request.LocationName,
            };
            
            _context.Add(location);
            await _context.SaveChangesAsync();
            return location.LocationId;
        }

        public async Task<IEnumerable<LocationResponse>> GetAsync()
        {
            var storageLocations = await _context.StorageLocations
            .Include(sl => sl.Bpkbs) // Include related Bpkbs
            .ToListAsync();

            // Assuming LocationResponse is a DTO class
            return storageLocations.Select(sl => new LocationResponse
            {
                
                LocationName = sl.LocationName,
                LocationId = sl.LocationId,
                //Bpkbs = sl.Bpkbs.Select(b => new Bpkb
                //{
                //    AgreementNumber = b.AgreementNumber,
                //    BpkbNo = b.BpkbNo,
                //    BpkbDate = b.BpkbDate
                //    // Map other properties as needed
                //}).ToList()
            });
        }

        public async Task<StorageLocation> ExistAsync(string id)
        {
            var storageLocation = await _context.StorageLocations.FirstOrDefaultAsync(x => x.LocationId == id);
            return storageLocation;
        }

    }
}
