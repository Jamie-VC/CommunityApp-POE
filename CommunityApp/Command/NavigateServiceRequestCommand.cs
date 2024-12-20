﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.ViewModel;
using CommunityApp.Model;

namespace CommunityApp.Command
{
    public class NavigateServiceRequestCommand: CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        public NavigateServiceRequestCommand(User user, NavigationStore navigationStore) 
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ServiceRequestViewModel(_user, _navigationStore);
        }
    }
}
