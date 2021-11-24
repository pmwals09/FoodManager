using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;

namespace API.Controllers
{
  public class RecipesController : ApiControllerBase
  {
    private readonly DataContext _context;
    public RecipesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Recipe>>> GetRecipes()
    {
      return await _context.Recipes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetActivity(Guid id)
    {
      return await _context.Recipes.FindAsync(id);
    }
  }
}