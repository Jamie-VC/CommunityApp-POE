using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityApp.Command;
using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.Services;

namespace CommunityApp.ViewModel
{
    public class ReportIssueViewModel : ViewModelBase
    {
        private string _location;
        private string _category;
        private string _description;
        //private string _mediaAttachment;
        //private List<Issue> _issueList;

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ReportIssueViewModel(User user, NavigationService issueViewNavigationService)
        {
            SubmitCommand = new ReportIssueCommand(this, user, issueViewNavigationService);
            CancelCommand = new NavigateCommand(issueViewNavigationService);
        }
    }
}
