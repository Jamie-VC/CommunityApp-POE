using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityApp.Model;
using CommunityApp.ViewModel;


namespace CommunityApp.Command
{
    public class ChangeStatusCommand : CommandBase
    {
        private readonly ServiceRequestViewModel _vm;
        private readonly ServiceRequestGraph _graph;
        public ChangeStatusCommand(ServiceRequestViewModel vm, ServiceRequestGraph graph)
        {
            _vm = vm;
            _graph = graph;
        }
        public override void Execute(object? parameter)
        {
            if (_vm.SelectedRequest != null)
            {
                var newStatus = PromptForNewStatus();
                if (newStatus != null)
                {
                    _vm.SelectedRequest.Status = newStatus;
                    _graph.GetNode(newStatus).AddRequest(_vm.SelectedRequest);
                    //_graph.MoveRequest(_vm.SelectedRequest.ID, _vm.SelectedRequest.Status, newStatus);
                }
            }
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
                    // Update the selected request's status
                    _vm.SelectedRequest.Status = newStatus;
                }
                return newStatus;
            }
            else return null;
        }
    }
}
