using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class ShoppingListsController : ApiControllerBase
    {
        private readonly DataContext _context;
        public ShoppingListsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingList>> MakeShoppingList()
        {
            ShoppingList shoppingList = new ShoppingList
            {
                Notes = "",
                WeekStartingDate = DateTime.Now,
                WeekLength = 7
            };
            await _context.ShoppingLists.AddAsync(shoppingList);
            return Ok(shoppingList);
        }

        [HttpPut]
        public async Task<ActionResult<ShoppingList>> UpdateShoppingList([FromBody] ShoppingList shoppingList)
        {
            ShoppingList entity;
            try
            {
                entity = await _context.ShoppingLists.FindAsync(shoppingList.Id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            try
            {
                entity.Notes = shoppingList.Notes;
                entity.WeekStartingDate = shoppingList.WeekStartingDate;
                entity.WeekLength = shoppingList.WeekLength;
                entity.MenuId = shoppingList.MenuId;

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
