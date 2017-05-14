using ShoppingCartBot.Services;
using System;
using System.Linq;

namespace ShoppingCartBot.Models.Actions
{
    public class ShowShoppingListAction : IAction
    {
        private readonly IShoppingListManager shoppingListManager;

        public string ActionString { get; }

        public ShowShoppingListAction(IShoppingListManager listManager)
        {
            shoppingListManager = listManager;
            ActionString = "show me my shopping list";
        }

        public string DoAction(string userAction)
        {
            var answer = String.Empty;

            if (shoppingListManager.GetShoppingList().Length == 0)
                answer = "Your shopping list is empty";
            else
                answer = String.Format("You are currently have: {0}", String.Join(", ", shoppingListManager.GetShoppingList().Select(x=>x.Product.name)));

            return answer;
        }
    }
}
