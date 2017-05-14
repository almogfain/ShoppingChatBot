using ShoppingCartBot.Models.Actions;
using System;

namespace ShoppingCartBot.Services
{
    public class BotManager
    {
        private readonly ActionResolver actionResolver;

        public BotManager(ActionResolver resolver)
        {
            actionResolver = resolver;
        }

        public void RunBot()
        {
            Console.WriteLine("Hi, welcome to Shopping list bot. Please enter you action");
            var action = Console.ReadLine();

            while (action.ToLower() != "exit")
            {
                HandleUserAction(action);
                Console.WriteLine("Enter your next action");
                action = Console.ReadLine();
            }
        }

        public void HandleUserAction(string userAction)
        {
            try
            {
                IAction action = actionResolver.GetAction(userAction);
                Console.WriteLine(action.DoAction(userAction));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
