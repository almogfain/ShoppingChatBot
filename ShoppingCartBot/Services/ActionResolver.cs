using ShoppingCartBot.Models.Actions;
using System;
using System.Linq;

namespace ShoppingCartBot.Services
{
    public class ActionResolver : IActionResolver
    {
        private readonly IAction[] actionsList;

        public ActionResolver(IAction[] list)
        {
            actionsList = list;
        }

        public IAction GetAction(string userInput)
        {
            var action = actionsList.FirstOrDefault(a => userInput.ToLower().StartsWith(a.ActionString.ToLower()));

            if (action == null)
                throw new Exception("Action not found");

            return action;
        }
    }
}
