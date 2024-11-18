using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.ViewModel;

namespace CommunityApp.Command
{
    public class SearchRequestsCommand : CommandBase
    {
        private readonly User _user;
        private readonly NavigationStore _navigationStore;
        private readonly ServiceRequestViewModel _serviceRequestViewModel;
        private readonly ServiceRequestGraph _serviceRequestGraph;

        

        //private readonly ObservableCollection<ServiceRequest> _serviceRequests;
        public SearchRequestsCommand(ServiceRequestViewModel srVM, User user, NavigationStore navigationStore, ServiceRequestGraph graph)
        {
            _serviceRequestViewModel = srVM;
            _user = user;
            _navigationStore = navigationStore;
            _serviceRequestGraph = graph;
        }

        //public override void Execute(object? parameter)
        //{
        //    _serviceRequestViewModel.ServiceRequests.Clear();

        //    if (_serviceRequestViewModel.SelectedStatus != null)
        //    {
        //        foreach (var request in _serviceRequestViewModel.GetAllRequests())
        //        {
        //            if (request.Status.Equals(_serviceRequestViewModel.SelectedStatus))
        //            {
        //                _serviceRequestViewModel.ServiceRequests.Add(request);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (var request in _serviceRequestViewModel.GetAllRequests())
        //        {
        //            _serviceRequestViewModel.ServiceRequests.Add(request);
        //        }
        //    }

        //    _serviceRequestViewModel.SelectedRequest = null;
        //}
        public override void Execute(object? parameter)
        {
            // Clear the current list of displayed requests
            _serviceRequestViewModel.ServiceRequests.Clear();

            // Declare the variable with an initial null value
            //ServiceRequest? request = null;

            //// Check if a valid ID is provided in the TextBox
            //if (!string.IsNullOrWhiteSpace(_serviceRequestViewModel.SearchId) && int.TryParse(_serviceRequestViewModel.SearchId, out int searchId))
            //{
            //    // Search for the request by ID
            //    request = _serviceRequestGraph.bst.Search(searchId); // Use the BST's search method
            //    if (request != null)
            //    {
            //        _serviceRequestViewModel.ServiceRequests.Add(request); // Add the found request to the list
            //        ResetFields();
            //        return; // Exit after handling ID search
            //    }
            //}

            // If no ID is provided or the ID search fails, filter by status if selected
            if (!string.IsNullOrWhiteSpace(_serviceRequestViewModel.SelectedStatus))
            {
                var allRequests = new List<ServiceRequest>();
                _serviceRequestGraph.bst.InOrderTraversal(_serviceRequestGraph.bst.GetRoot(), allRequests.Add); // Traverse the BST

                foreach (var req in allRequests)
                {
                    if (req.Status.Equals(_serviceRequestViewModel.SelectedStatus, StringComparison.OrdinalIgnoreCase))
                    {
                        _serviceRequestViewModel.ServiceRequests.Add(req); // Add requests matching the selected status
                    }
                }
            }
            else
            {
                // If no search criteria are provided, display all requests
                var allRequests = new List<ServiceRequest>();
                _serviceRequestGraph.bst.InOrderTraversal(_serviceRequestGraph.bst.GetRoot(), allRequests.Add); // Traverse the BST

                foreach (var req in allRequests)
                {
                    _serviceRequestViewModel.ServiceRequests.Add(req);
                }
            }

            ResetFields();
        }

        // Helper method to reset fields after execution
        private void ResetFields()
        {
            _serviceRequestViewModel.SelectedStatus = null;
            _serviceRequestViewModel.SearchId = string.Empty;
            _serviceRequestViewModel.SelectedRequest = null;
        }




    }
}
