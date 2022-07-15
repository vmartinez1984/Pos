using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pos.Core.Validators;

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
        public decimal Price { get; set; }

        [Required]
        [StringLength(13)]
        [ExistsBarcode]
        public string Barcode { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }

    public class ProductDto : ProductDtoIn
    {
        public string Id { get; set; }

        public DateTime DateRegistration { get; set; }
    }

    public class ProductSaleDtoIn
    {
        [Required]
        [StringLength(13)]
        [NotExistsBarcode]
        public string Barcode { get; set; }

        public string SaleId { get; set; }
    }

    public class ProductSaleDto
    {
        public string Barcode { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}