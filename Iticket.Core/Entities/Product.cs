using Iticket.Core.Entities.Base;

namespace Iticket.Core.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string BannerImage { get; set; }
        public string PosterImage { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public double MinPrice { get; set; }
        public int AgeLimit { get; set; }
        public string About { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public ICollection<ProductEvent> ProductEvents { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
