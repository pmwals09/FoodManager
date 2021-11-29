using System;
namespace Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid FoodItemId { get; set; }
        public decimal Servings { get; set; }
    }
}
