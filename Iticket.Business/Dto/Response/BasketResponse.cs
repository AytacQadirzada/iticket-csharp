namespace Iticket.Business.Dto.Response
{
    public class BasketResponse
    {
        public ICollection<BasketItemResponse> Products { get; set; }
    }
}