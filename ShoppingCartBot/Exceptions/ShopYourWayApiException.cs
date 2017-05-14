using System;

namespace ShoppingCartBot.Exceptions
{
    public class ShopYourWayApiException : Exception
    {
        public ShopYourWayApiException() :base()
        {

        }

        public ShopYourWayApiException(string message)
          : base(message)
        {

        }

        public ShopYourWayApiException(string message, Exception e)
          : base(message, e)
        {

        }
    }
}
