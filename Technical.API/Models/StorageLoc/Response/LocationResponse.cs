using Technical.API.Models.Bpkp;

namespace Technical.API.Models.StorageLoc.Response
{
    public class LocationResponse
    {
        public string LocationName { get; set; }
        public virtual ICollection<Bpkb> Bpkbs { get; set; }
    }
}
