using ShoppingCartBot.Models.Actions;
using ShoppingCartBot.Services;

namespace ShoppingCartBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataProvider = new ShopYourWayDataProvider();
            var listManager = new ShoppingListManager();
            var actionsHelper = new QueryStringHelper();
            var actions = new IAction[] { new AddItemAction(listManager, dataProvider, actionsHelper),
                                          new FindItemAction(dataProvider, actionsHelper),
                                          new ShowShoppingListAction(listManager) };
            var bot = new BotManager(new ActionResolver(actions));
            bot.RunBot();
        }
    }
}
