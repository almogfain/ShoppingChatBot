using System.Collections.Generic;

namespace ShoppingCartBot.Models
{
    public class ShopYourWayApiResponseData : IResponseData<Product>
    {
        public int Count { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
