using Technical.API.Models.StorageLoc;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;

namespace Technical.API.Repository.Storage
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationResponse>> GetAsync();
        Task<string> CreateAsync(LocationRequest request);
    }
}
