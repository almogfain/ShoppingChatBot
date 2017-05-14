namespace ShoppingCartBot.Models
{
    public class ShoppingListItem
    {
        public ShoppingListItem(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }

        public int Amount { get; set; }
        public Product Product { get; set; }
    }
}
