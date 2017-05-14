using System;

namespace ShoppingCartBot.Services
{
    public interface IStringHelper
    {
        string SplitQueryByAction(String Action, String ActionString);
    }
}
