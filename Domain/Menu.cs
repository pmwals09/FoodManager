using System;
namespace Domain
{
    public class Menu
    {
        public Guid Id { get; set; }
        public DateTime WeekStartingDate { get; set; }
        public int WeekLength { get; set; }
    }
}
