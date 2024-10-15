using CommunityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommunityApp.Command
{
    public class AttachMediaCommand: ICommand
    {
        private readonly ReportIssueViewModel _ReportIssueViewModel;

        public AttachMediaCommand(ReportIssueViewModel viewModel)
        {
            _ReportIssueViewModel = viewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _ReportIssueViewModel.AttachMedia();
        }

        public event EventHandler CanExecuteChanged;
    }
}
