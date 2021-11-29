using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(!context.Recipes.Any())
            {
                var recipes = new List<Recipe>
                {
                    new Recipe
                    {
                        Name = "PB&J",
                        Servings = 1,
                        Description = "A delicious lunch from younger days",
                        Directions = "Spread peanut butter on one slice of bread. Spread jelly on the other. Put slices of bread together and enjoy."
                    }
                };

                await context.Recipes.AddRangeAsync(recipes);
                await context.SaveChangesAsync();
            }

            if (!context.FoodItems.Any())
            {
                var foodItems = new List<FoodItem>
                {
                    new FoodItem
                    {
                        Name = "Peanut Butter",
                        ServingSize = 2.0f,
                        ServingUnitOfMeasure = "Tbsp",
                        KCalPerServing = 190,
                        GramsCarbsPerServing = 8,
                        GramsFatPerServing = 16,
                        GramsProteinPerServing = 7,
                        GramsSugarPerServing = 3
                    },
                    new FoodItem
                    {
                        Name = "Jelly",
                        ServingSize = 2.0f,
                        ServingUnitOfMeasure = "Tbsp",
                        KCalPerServing = 100,
                        GramsCarbsPerServing = 26,
                        GramsFatPerServing = 0,
                        GramsProteinPerServing = 0,
                        GramsSugarPerServing = 20
                    },
                    new FoodItem
                    {
                        Name = "White Bread",
                        ServingSize = 2.0f,
                        ServingUnitOfMeasure = "Slices",
                        KCalPerServing = 140,
                        GramsCarbsPerServing = 26,
                        GramsFatPerServing = 2,
                        GramsProteinPerServing = 4,
                        GramsSugarPerServing = 4
                    }
                };

                await context.FoodItems.AddRangeAsync(foodItems);
                await context.SaveChangesAsync();
            }

            if (!context.Ingredients.Any())
            {
                var pbjRecipe = context.Recipes.Single(r => r.Name == "PB&J");
                var foodItems = context.FoodItems.ToList();
                var ingredients = new List<Ingredient> ();
                foreach(FoodItem foodItem in foodItems)
                {
                    ingredients.Add(new Ingredient
                    {
                        RecipeId = pbjRecipe.Id,
                        FoodItemId = foodItem.Id,
                        Servings = 1
                    });
                }

                await context.Ingredients.AddRangeAsync(ingredients);
                await context.SaveChangesAsync();
            }
        }
    }
}