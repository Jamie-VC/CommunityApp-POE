using CommunityApp.Model;
using CommunityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Services;

namespace CommunityApp.Command
{
    public class ReportIssueCommand : CommandBase
    {
        private readonly ReportIssueViewModel _reportIssueViewModel;
        private readonly User _user;
        private readonly NavigationService _issueViewNavigationService;

        public ReportIssueCommand(ReportIssueViewModel reportIssueViewModel, User user, NavigationService issueViewNavigationService)
        {
            _reportIssueViewModel = reportIssueViewModel;
            _user = user;
            _issueViewNavigationService = issueViewNavigationService;
        }
        public override void Execute(object? parameter)
        {
            Issue issue = new Issue(
                _reportIssueViewModel.Location, 
                _reportIssueViewModel.Category, 
                _reportIssueViewModel.Description,
                _reportIssueViewModel.MediaPath);
            
            _user.ReportIssue(issue);

            _issueViewNavigationService.Navigate();
        }
    }
}
