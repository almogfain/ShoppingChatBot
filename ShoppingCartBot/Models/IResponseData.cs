using System.Collections.Generic;

namespace ShoppingCartBot.Models
{
    public interface IResponseData<T>
    {
        int Count { get; set; }
        IEnumerable<T> Products { get; set; }
    }
}
