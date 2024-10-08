using CommunityApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.ViewModel
{
    public class IssueViewModel : ViewModelBase
    {
        private readonly Issue _issue;
        public string Location => _issue.Location;
        public string Category => _issue.Category;
        public string Description => _issue.Description;
        public string MediaPath => _issue.MediaPath;

        public IssueViewModel(Issue issue)
        {
            _issue = issue;
        }
    }
}
