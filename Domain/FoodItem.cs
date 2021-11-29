using System;
namespace Domain
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float ServingSize { get; set; }
        public string ServingUnitOfMeasure { get; set; }
        public int KCalPerServing { get; set; }
        public int GramsFatPerServing { get; set; }
        public int GramsCarbsPerServing { get; set; }
        public int GramsSugarPerServing{ get; set; }
        public int GramsProteinPerServing { get; set; }
    }
}
