using System.ComponentModel.DataAnnotations;

namespace Technical.API.Models
{
    public class StorageLocation
    {
        [Key]
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public virtual ICollection<Bpkb> Bpkbs { get; set; }
    }
}
