using ShoppingCartBot.Models;

namespace ShoppingCartBot.Services
{
    public interface IShoppingListManager
    {
        void AddItem(Product item);
        ShoppingListItem[] GetShoppingList();
    }
}