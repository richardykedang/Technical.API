using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Technical.API.Models.StorageLoc;

namespace Technical.API.Models.Bpkp
{
    public class Bpkb
    {
        [Key]
        public string AgreementNumber { get; set; }
        public string BpkbNo { get; set; }
        public string BranchId { get; set; }
        public DateTime BpkbDate { get; set; }
        public string FakturNo { get; set; }
        public DateTime FakturDate { get; set; }

        [ForeignKey(nameof(StorageLocation))]
        public string LocationId { get; set; }
        public string PoliceNo { get; set; }
        public DateTime BpkbDateIn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        [JsonIgnore]

        public virtual StorageLocation StorageLocation { get; set; }
    }
}
