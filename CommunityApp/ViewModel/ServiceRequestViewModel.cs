﻿using System;
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

        BinarySearchTree bst;
        ServiceRequestGraph graph;

        //Collection
        public ObservableCollection<ServiceRequest> ServiceRequests { get; set; }
        public ObservableCollection<string> Dependencies { get; set; }
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
        private string searchId;
        public string SearchId
        {
            get => searchId;
            set
            {
                searchId = value;
                OnPropertyChanged(nameof(SearchId));
            }
        }

        //Command
        public ICommand SearchRequestsCommmand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ServiceRequestViewModel(User user, NavigationStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;

            bst = new BinarySearchTree();
            graph = new ServiceRequestGraph(bst);


            ServiceRequests = new ObservableCollection<ServiceRequest>();
            Dependencies = new ObservableCollection<string>();  
            Statuses = new ObservableCollection<string>
            {
                new string ("Pending"),
                new string ("Ongoing"),
                new string ("Done")
            };
            Initialize();

            SearchRequestsCommmand = new SearchRequestsCommand(this, user, navigationStore, graph);
            ChangeStatusCommand = new ChangeStatusCommand(this);
            BackCommand = new NavigateMenuCommand(user, navigationStore);
        }
        public void Initialize()
        {
            // Add some sample service requests
            var request1 = new ServiceRequest(1, "Pending", DateTime.Now.AddDays(-5), "Install new internet connection");
            var request2 = new ServiceRequest(2, "Pending", DateTime.Now.AddDays(-3), "Repair street light");
            var request3 = new ServiceRequest(3, "Pending", DateTime.Now.AddDays(-1), "Fix water leakage");

            graph.AddRequest(request1);
            graph.AddRequest(request2);
            graph.AddRequest(request3);

            // Set dependencies (request 2 depends on 1, and request 3 depends on 2)
            graph.AddDependency(1, 2);
            graph.AddDependency(2, 3);
        }
        // Retrieve all service requests (in-order traversal)
        public ObservableCollection<ServiceRequest> GetAllRequests()
        {
            var list = new ObservableCollection<ServiceRequest>();
            bst.InOrderTraversal(bst.GetRoot(), (request) => list.Add(request));
            return list;
        }

        // Update a service request's status
        public void UpdateStatus(int requestId, string newStatus)
        {
            if (graph.UpdateRequestStatus(requestId, newStatus))
            {
                var request = ServiceRequests.FirstOrDefault(r => r.ID == requestId);
                if (request != null)
                {
                    request.Status = newStatus;
                }
            }
        }

        // Display dependencies for a selected request
        public void ShowDependencies(int requestId)
        {
            Dependencies.Clear();
            if (graph.dependencies.TryGetValue(requestId, out var dependentIds))
            {
                foreach (var id in dependentIds)
                {
                    var depRequest = bst.Search(id);
                    if (depRequest != null)
                    {
                        Dependencies.Add($"Depends on Request ID: {depRequest.ID} - {depRequest.Description} (Status: {depRequest.Status})");
                    }
                }
            }
        }
        public void UpdateStatus(string newStatus)
        {
            if (SelectedRequest != null)
            {
                SelectedRequest.Status = newStatus;
                graph.UpdateRequestStatus(SelectedRequest.ID, newStatus);
                //OnPropertyChanged(nameof(ServiceRequests)); // Notify UI of change
            }
        }
    }
}
