﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class IssueListViewModel : ViewModelBase
    {
        private readonly User _user;
        private readonly ObservableCollection<IssueViewModel> _issues;
        public IEnumerable<IssueViewModel> Issues => _issues;
       public ICommand ReportIssueCommand { get; }
        public ICommand BackCommand { get; }

        public IssueListViewModel(User user, NavigationStore navigationStore)
        {
            _user = user;
            _issues = new ObservableCollection<IssueViewModel>();
            ReportIssueCommand = new NavigateReportIssueCommand(user, navigationStore);
            BackCommand = new NavigateMenuCommand(user, navigationStore);

            UpdateIssues();
        }

        private void UpdateIssues()
        {
            _issues.Clear();
            foreach (Issue issue in _user.GetAllIssues())
            {
                IssueViewModel issueViewModel = new IssueViewModel(issue);
                _issues.Add(issueViewModel);
            }
        }
    }
}
