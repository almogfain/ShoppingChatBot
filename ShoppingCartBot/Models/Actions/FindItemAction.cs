using ShoppingCartBot.Services;
using System;
using System.Linq;

namespace ShoppingCartBot.Models.Actions
{
    public class FindItemAction : IAction
    {
        private readonly IDataProvider<Product> dataProvider;
        private readonly IStringHelper actionsHelper;

        public string ActionString { get;}

        public FindItemAction(IDataProvider<Product> idataProvider, IStringHelper actionsHelper)
        {
            this.actionsHelper = actionsHelper;
            dataProvider = idataProvider;
            ActionString = "I want to buy";
        }

        public string DoAction(string userAction)
        {
            var searchString = actionsHelper.SplitQueryByAction(userAction, ActionString);

            string answer;

            try
            {
                IResponseData<Product> data = (ShopYourWayApiResponseData)dataProvider.Fetch(searchString);
                
                answer = GetAnswerString(data);
            }
            catch (Exception e)
            {
                answer = "Something went wrong: " + e.Message;
            }

            return answer;
        }

        private string GetAnswerString(IResponseData<Product> data)
        {
            var answerString = data.Count == 0 ?
                "No items found" :
                String.Format("I found you these {0} items: {1}", data.Count, String.Join(", ", data.Products.Select(x => x.name)));

            return answerString;
        }
    }
}
