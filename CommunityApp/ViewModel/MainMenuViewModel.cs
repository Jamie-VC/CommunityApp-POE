using CommunityApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityApp.Services;
using CommunityApp.Command;
using CommunityApp.Stores;

namespace CommunityApp.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        private readonly User _user;
        public ICommand ReportCommand { get; }
        public ICommand LocalEventsCommand { get; }
        public ICommand ServiceRequestCommand { get; }
        public MainMenuViewModel(User user, NavigationStore navigationStore)
        {
            _user = user;
            ReportCommand = new NavigateIssueListCommand(_user, navigationStore);
            LocalEventsCommand = new NavigateLocalEventsCommand(_user, navigationStore);
            ServiceRequestCommand = new NavigateServiceRequestCommand(navigationStore);
        }
    }
}
