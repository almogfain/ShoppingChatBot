using System;

namespace ShoppingCartBot.Services
{
    public class QueryStringHelper : IStringHelper
    {
        public String SplitQueryByAction(String Action, String ActionString)
        {
            var splittedActionString = Action.ToLower().Split(new string[] { ActionString.ToLower() }, StringSplitOptions.RemoveEmptyEntries);

            if (splittedActionString.Length == 0)
            {
                throw new Exception("Action query incomplete");
            }

            return splittedActionString[0].Trim();
        }
    }
}
