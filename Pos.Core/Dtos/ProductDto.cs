using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pos.Core.Dtos
{
    public class ProductDtoIn
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Cost { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Sale { get; set; }

        [Required]
        [StringLength(13)]
        public string CodeBar { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }

    public class ProductDto: ProductDtoIn
    {
        public string Id { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}