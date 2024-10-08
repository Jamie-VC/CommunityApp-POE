using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string? MediaPath { get; set; }

        public Issue(string location, string category, string description, string mediaPath)
        {
            Location = location;
            Category = category;
            Description = description;
            MediaPath = mediaPath;
        }
    }
}
