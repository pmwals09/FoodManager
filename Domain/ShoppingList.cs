using System;
namespace Domain
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }
        public DateTime WeekStartingDate { get; set; }
        public int WeekLength { get; set; }
        public Guid MenuId { get; set; }
    }
}
