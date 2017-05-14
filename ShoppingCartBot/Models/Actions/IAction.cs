namespace ShoppingCartBot.Models.Actions
{
    public interface IAction
    {
        string DoAction(string userAction);
        string ActionString { get; }
    }
}
