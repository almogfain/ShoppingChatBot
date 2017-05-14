using ShoppingCartBot.Services;
using System;
using System.Linq;

namespace ShoppingCartBot.Models.Actions
{
    public class AddItemAction : IAction
    {
        private readonly IDataProvider<Product> dataProvider;
        private readonly IShoppingListManager shoppingListManager;
        private readonly IStringHelper actionsHelper;

        public string ActionString { get; }

        public AddItemAction(IShoppingListManager listManager, IDataProvider<Product> dataProvider, IStringHelper actionsHelper)
        {
            this.dataProvider = dataProvider;
            this.actionsHelper = actionsHelper;
            shoppingListManager = listManager;
            ActionString = "add item";
        }

        public string DoAction(string userAction)
        {
            int itemNumber;
            var answer = "Item added to the list";

            try
            {
                var searchString = actionsHelper.SplitQueryByAction(userAction, ActionString);

                var num = actionsHelper.SplitQueryByAction(searchString, "to");

                if (Int32.TryParse(num, out itemNumber))
                {
                    var itemToAdd = dataProvider.Data.Products.ElementAt(itemNumber - 1);
                    shoppingListManager.AddItem(itemToAdd);
                }
            }
            catch (Exception e)
            {
                answer = e.Message;
            }

            return answer;
        }
    }
}
