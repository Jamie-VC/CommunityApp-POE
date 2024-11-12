using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Stores;
using CommunityApp.Model;

namespace CommunityApp.ViewModel
{
    public class ServiceRequestViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        //private readonly User _user;
        public ServiceRequestViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
