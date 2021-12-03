using System;
namespace Domain
{
    public class ShoppingListItem
    {
        public Guid Id { get; set; }
        public Guid ShoppingListId { get; set; }
        public Guid FoodItemId { get; set; }
        public double Quantity { get; set; }
    }
}
