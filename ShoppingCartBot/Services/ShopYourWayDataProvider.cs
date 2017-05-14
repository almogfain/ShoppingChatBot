using ShoppingCartBot.Exceptions;
using ShoppingCartBot.Models;
using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace ShoppingCartBot.Services
{
    public class ShopYourWayDataProvider : IDataProvider<Product>
    {
        private string UriString = "https://platform.shopyourway.com/products/search?q={0}&token=0_18401_253402300799_1_c78a591a5ecaf201c77c315dae461f0647bbbe90bc5f999d782de90e6b5bdb6f&hash=b8b5adaf022fcbc2f70476b3d0181bd2a12b859d440cc40aa9638aa2513eaebe";

        public IResponseData<Product> Data { get; private set; }

        public IResponseData<Product> Fetch(string userSearchString)
        {
            var request = (HttpWebRequest)WebRequest.Create(String.Format(UriString, userSearchString));
            ShopYourWayApiResponseData responseData = new ShopYourWayApiResponseData();

            try
            {
                using (var shopYourWayResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(shopYourWayResponse.GetResponseStream()))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();

                        if (!objText.Equals("null"))
                        {
                            responseData = (ShopYourWayApiResponseData)js.Deserialize(objText, typeof(ShopYourWayApiResponseData));
                            Data = responseData;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ShopYourWayApiException("An error occurred in ShopYourWay api", e);
            }

            return responseData;
        }
    }
}
