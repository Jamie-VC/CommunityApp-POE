using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Command
{
    public class NavigateReportIssueCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        public NavigateReportIssueCommand(User user, NavigationStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ReportIssueViewModel(_user, _navigationStore);
        }
    }
}
