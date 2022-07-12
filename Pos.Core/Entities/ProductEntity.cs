namespace Pos.Core.Entities
{
    public class ProductEntity: BaseEntity
    {        
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal Sale { get; set; }

        public string CodeBar { get; set; }

        public string UserId { get; set; }
    }
}