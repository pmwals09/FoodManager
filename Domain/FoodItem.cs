using System;
namespace Domain
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double ServingSize { get; set; }
        public string ServingUnitOfMeasure { get; set; }
        public int KCalPerServing { get; set; }
        public int GramsFatPerServing { get; set; }
        public int GramsCarbsPerServing { get; set; }
        public int GramsSugarPerServing{ get; set; }
        public int GramsProteinPerServing { get; set; }
        public string CollectionName { get; set; }
        public double ServingsPerCollection { get; set; }
    }
}
