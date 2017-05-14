using ShoppingCartBot.Models.Actions;

namespace ShoppingCartBot.Services
{
    public interface IActionResolver
    {
        IAction GetAction(string userInput);
    }
}