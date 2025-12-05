using Iticket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Dto.Request
{
    public class ProductRequestDto
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
        public int CategoryId { get; set; }

        #region ProductEvent
        public ICollection<ProductEventRequestDto> ProductEvents { get; set; }
        #endregion
    }
}
