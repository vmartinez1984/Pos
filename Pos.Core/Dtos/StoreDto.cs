using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pos.Core.Validators;

namespace Pos.Core.Dtos
{
    public class StoreDtoIn
    {
        [NotExistsBarcode]
        public string Barcode { get; set; }

        [Range(0, 10000)]
        public int Pieces { get; set; }

        public DateTime? DateExpired { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }

    public class StoreDto : StoreDtoIn
    {

        public DateTime DateRegistration { get; set; } = DateTime.Now;

    }
}