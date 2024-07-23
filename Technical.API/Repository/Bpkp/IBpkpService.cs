using Technical.API.Models.Bpkp;
using Technical.API.Models.Bpkp.Request;
using Technical.API.Models.Bpkp.Response;
using Technical.API.Models.StorageLoc;
using Technical.API.Models.StorageLoc.Request;
using Technical.API.Models.StorageLoc.Response;

namespace Technical.API.Repository.Bpkp
{
    public interface IBpkpService
    {
        Task<IEnumerable<BpkbResponse>> GetAsync();
        Task<Bpkb> CreateAsync(Bpkb request);
        
    }
}
