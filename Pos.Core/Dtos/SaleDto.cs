namespace Pos.Core.Dtos
{
    public class SaleDtoIn
    {
        public string UserId { get; set; }
        public string Id { get; set; }
    }

    public class SaleDto
    {
        public string Id { get; set; }

        public string State { get; set; }

        public DateTime DateRegistration { get; set; }

        public decimal Total { get; set; }

        public int TotalProducts { get { return this.ListProducts.Count; } }

        public List<ProductSaleDto> ListProducts { get; set; }
    }
}