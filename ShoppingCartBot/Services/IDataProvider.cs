using ShoppingCartBot.Models;

namespace ShoppingCartBot.Services
{
    public interface IDataProvider<T>
    {
        IResponseData<T> Data { get;}
        IResponseData<T> Fetch(string userSearchString);
    }
}
