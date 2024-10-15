using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class Event
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateOnly Date { get; set; }

        public Event(string name, string category, DateOnly date)
        {
            Name = name;
            Category = category;
            Date = date;
        }
    }
}
