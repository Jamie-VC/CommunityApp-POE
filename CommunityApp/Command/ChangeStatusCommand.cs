using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityApp.Model;
using CommunityApp.ViewModel;
using CommunityApp.Stores;


namespace CommunityApp.Command
{
    public class ChangeStatusCommand : CommandBase
    {
        private readonly ServiceRequestViewModel _vm;
        private readonly ServiceRequestGraph _graph;

        private readonly User _user;
        private readonly NavigationStore _navigationStore;
        public ChangeStatusCommand(ServiceRequestViewModel vm)
        {
            _vm = vm;
            //_graph = graph;
        }
        public override void Execute(object? parameter)
        {
            PromptForNewStatus();
        }

        public string PromptForNewStatus()
        {
            var dialog = new ChangeStatusDialog(); // Open the status change dialog
            var result = dialog.ShowDialog(); // Show the dialog as a modal

            if (result == true) // If the user clicked OK
            {
                string newStatus = dialog.NewStatus;
                if (!string.IsNullOrEmpty(newStatus))
                {
                    _vm.UpdateStatus(newStatus);
                }
                return newStatus;
            }
            else return null;
        }
    }
}
