namespace Pos.Core.Entities
{
    public class SaleEntity: BaseEntity
    {        
        public string UserId { get; set; }
        public decimal Total { get; set; }        
        public string State { get; set; }

        public List<ProductSaleEntity> ListProducts { get; set; }
    }
}