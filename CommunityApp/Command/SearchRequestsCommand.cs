﻿using System;
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

        public override void Execute(object? parameter)
        {
            _serviceRequestViewModel.ServiceRequests.Clear();
            
            if(_serviceRequestViewModel.SelectedStatus != null)
            {
                foreach (var request in _serviceRequestViewModel.GetAllRequests())
                {
                    if (request.Status.Equals(_serviceRequestViewModel.SelectedStatus))
                    {
                        _serviceRequestViewModel.ServiceRequests.Add(request);
                    }
                }
            }
            else
            {
                foreach (var request in _serviceRequestViewModel.GetAllRequests())
                {
                    _serviceRequestViewModel.ServiceRequests.Add(request);
                }
            }

            _serviceRequestViewModel.SelectedRequest = null;
        }
    }
}