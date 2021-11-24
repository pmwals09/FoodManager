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
            if(context.Recipes.Any()) return;

            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "PB&J",
                    Ingredients = "White Bread, Peanut Butter, Jelly",
                    Servings = 1,
                    Description = "A delicious lunch from younger days",
                    Directions = "Spread peanut butter on one slice of bread. Spread jelly on the other. Put slices of bread together and enjoy."
                }
            };

            await context.Recipes.AddRangeAsync(recipes);
            await context.SaveChangesAsync();
        }
    }
}