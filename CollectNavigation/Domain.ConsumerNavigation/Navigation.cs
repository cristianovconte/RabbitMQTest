using System;

namespace Domain.ConsumerNavigation
{
    public class Navigation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateNavigation { get; set; } = DateTime.Now;
    }
}
