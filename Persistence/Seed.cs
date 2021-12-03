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
            if(!context.Menus.Any())
            {
                List<Menu> menus = new()
                {
                    new Menu
                    {
                        WeekStartingDate = System.DateTime.Now,
                        WeekLength = 7
                    }
                };

                await context.Menus.AddRangeAsync(menus);
                await context.SaveChangesAsync();
            }
            if(!context.Recipes.Any())
            {
                Menu menu = context.Menus.ToList()[0];
                List<Recipe> recipes = new()
                {
                    new Recipe
                    {
                        Name = "PB&J",
                        Servings = 1,
                        Description = "A delicious lunch from younger days",
                        Directions = "Spread peanut butter on one slice of bread. Spread jelly on the other. Put slices of bread together and enjoy.",
                        MenuId = menu.Id
                    }
                };

                await context.Recipes.AddRangeAsync(recipes);
                await context.SaveChangesAsync();
            }

            if (!context.FoodItems.Any())
            {
                List<FoodItem> foodItems = new()
                {
                    new FoodItem
                    {
                        Name = "Peanut Butter",
                        ServingSize = 2.0,
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
                        ServingSize = 2.0,
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
                        ServingSize = 2.0,
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
                Recipe pbjRecipe = context.Recipes.Single(r => r.Name == "PB&J");
                List<FoodItem> foodItems = context.FoodItems.ToList();
                List<Ingredient> ingredients = new();

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

            if(!context.ShoppingLists.Any())
            {
                Menu menu = context.Menus.ToList()[0];
                List<ShoppingList> shoppingLists = new()
                {
                    new ShoppingList
                    {
                        Notes = "First shopping list, just PB&Js",
                        WeekStartingDate = menu.WeekStartingDate,
                        WeekLength = menu.WeekLength,
                        MenuId = menu.Id
                    }
                };

                await context.ShoppingLists.AddRangeAsync(shoppingLists);
                await context.SaveChangesAsync();
            }

            if(!context.ShoppingListItems.Any())
            {
                List<ShoppingListItem> shoppingListItems = new();
                List<FoodItem> foodItems = context.FoodItems.ToList();
                ShoppingList shoppingList = context.ShoppingLists.ToList()[0];

                foreach (FoodItem foodItem in foodItems)
                {
                    shoppingListItems.Add(new ShoppingListItem
                    {
                        ShoppingListId = shoppingList.Id,
                        FoodItemId = foodItem.Id,
                        Quantity = 1
                    });
                }

                await context.ShoppingListItems.AddRangeAsync(shoppingListItems);
                await context.SaveChangesAsync();
            }
        }
    }
}