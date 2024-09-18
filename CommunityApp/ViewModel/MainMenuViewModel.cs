using CommunityApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityApp.Services;
using CommunityApp.Command;

namespace CommunityApp.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        private readonly User _user;
        public ICommand ReportCommand { get; }
        public MainMenuViewModel(User user, NavigationService reportIssueNavigationService)
        {
            _user = user;
            ReportCommand = new NavigateCommand(reportIssueNavigationService);
        }
    }
}
