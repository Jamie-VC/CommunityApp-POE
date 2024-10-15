using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class User
    {
        public string Name { get; set; }
        public HashSet<string> Interests { get; set; }
        private readonly IssueList _issueList;

        public User(string name, HashSet<string> interests)
        {
            Name = name;
            Interests = interests;
            _issueList = new IssueList();
        }

        public IEnumerable<Issue> GetAllIssues()
        {
            return _issueList.GetAllIssues();
        }
        public void ReportIssue(Issue issue)
        {
            _issueList.AddIssue(issue);
        }
    }
}
