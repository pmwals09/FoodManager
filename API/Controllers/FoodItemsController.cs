using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class FoodItemsController : ApiControllerBase
    {
        private readonly DataContext _context;
        public FoodItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodItem>>> GetFoodItems()
        {
            return await _context.FoodItems.ToListAsync();
        }

    }
}
