using System.ComponentModel.DataAnnotations;
using Technical.API.Models.Bpkp;

namespace Technical.API.Models.StorageLoc
{
    public class StorageLocation
    {
        [Key]
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public virtual ICollection<Bpkb> Bpkbs { get; set; }
    }
}
