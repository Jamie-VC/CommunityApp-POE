using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Stores;
using CommunityApp.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityApp.Command;
using System.Windows.Controls;
using System.Windows;

namespace CommunityApp.ViewModel
{
    public class ServiceRequestViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;

        private ServiceRequestGraph serviceRequestGraph;
       //private ServiceRequestTree serviceRequestTree;

        //Collection
        public ObservableCollection<ServiceRequest> ServiceRequests { get; set; }
        public ObservableCollection<string> Statuses { get; set; }

        //Properties
        private string _selectedStatus;
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }
        private ServiceRequest _selectedRequest;
        public ServiceRequest SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }

        //Command
        public ICommand SearchRequestsCommmand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ServiceRequestViewModel(User user, NavigationStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;

            Statuses = new ObservableCollection<string>
            {
                new string ("Pending"),
                new string ("Ongoing"),
                new string ("Done")
            };

            Initialize();

            ServiceRequests = new ObservableCollection<ServiceRequest>();

            SearchRequestsCommmand = new SearchRequestsCommand(this, user, navigationStore, serviceRequestGraph);
            ChangeStatusCommand = new ChangeStatusCommand(this, serviceRequestGraph);
        }

        private void Initialize()
        {
            serviceRequestGraph = new ServiceRequestGraph();

            // Add mock data for graph
            var request1 = new ServiceRequest { ID = "SR001", Description = "Fix printer", Status = "Pending", Date = DateTime.Now.AddDays(-5) };
            var request2 = new ServiceRequest { ID = "SR002", Description = "Setup PC", Status = "Ongoing", Date = DateTime.Now.AddDays(-2) };
            var request3 = new ServiceRequest { ID = "SR003", Description = "Update payroll", Status = "Done", Date = DateTime.Now };

            serviceRequestGraph.GetNode("Pending").AddRequest(request1);
            serviceRequestGraph.GetNode("Ongoing").AddRequest(request2);
            serviceRequestGraph.GetNode("Done").AddRequest(request3);

            // Data for tree
            //serviceRequestTree = new ServiceRequestTree();
            //serviceRequestTree.
        }

        public void DisplayServiceRequests(string status)
        {
            var node = serviceRequestGraph.GetNode(status);
            if (node != null)
            {
                node.RequestsTree.GetAllRequests().ForEach(request =>
                {
                    ServiceRequests.Add(request);
                });

                //foreach (var serviceRequest in node.GetAllRequests())
                //{
                //    ServiceRequests.Add(serviceRequest);
                //}
            }
        }

        //public void move()
        //{
        //    var requestId = RequestIdBox.Text;
        //    var fromStatus = (FromStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
        //    var toStatus = (ToStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

        //    if (!string.IsNullOrEmpty(requestId) && !string.IsNullOrEmpty(fromStatus) && !string.IsNullOrEmpty(toStatus))
        //    {
        //        serviceRequestGraph.MoveRequest(requestId, fromStatus, toStatus);
        //        MessageBox.Show($"Request {requestId} moved from {fromStatus} to {toStatus}.");
        //    }
        //}
    }
}
