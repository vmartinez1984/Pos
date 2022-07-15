namespace Pos.Core.Entities
{
    public class StoreEntity : BaseEntity
    {
        public string Barcode { get; set; }

        public int Pieces { get; set; }

        public DateTime? DateExpired { get; set; }

        public string UserId { get; set; }
    }
}