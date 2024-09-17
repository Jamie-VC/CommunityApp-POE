using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Model
{
    public class IssueList
    {
        private readonly List<Issue> _issues;

        public IssueList()
        {
            _issues = new List<Issue>(); 
        }
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issues;
        }
        public void AddIssue(Issue issue)
        {
            _issues.Add(issue);
        }
        public string IssuesToString()
        {
            string message = "";

            foreach (var issue in _issues)
            {
                message += issue.Location.ToString() + "\n";
            }
            return message;
        }
    }
}
