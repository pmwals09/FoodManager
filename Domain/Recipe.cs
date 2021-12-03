using System;
using System.Collections.Generic;

namespace Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Servings { get; set; }
        public string Description { get; set; }
        public string Directions { get; set; }
        public Guid MenuId { get; set; }
    }
}