using System.Collections.Generic;
using System.Linq;
using ShoppingCartBot.Models;

namespace ShoppingCartBot.Services
{
    class ShoppingListManager : IShoppingListManager
    {
        private List<ShoppingListItem> UserShoppingLost;

        public ShoppingListManager()
        {
            UserShoppingLost = new List<ShoppingListItem>();
        }

        public void AddItem(Product item)
        {
            ShoppingListItem itemInList = UserShoppingLost.FirstOrDefault(x => x.Product.Equals(item));

            if (itemInList == null)
            {
                UserShoppingLost.Add(new ShoppingListItem(item, 1));
            }
            else
            {
                itemInList.Amount++;
            }
        }

        public ShoppingListItem[] GetShoppingList()
        {
            return UserShoppingLost.ToArray();
        }
    }
}
