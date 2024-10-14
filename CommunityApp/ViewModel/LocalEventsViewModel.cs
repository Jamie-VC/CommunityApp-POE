using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Model;
using CommunityApp.Stores;

namespace CommunityApp.ViewModel
{
    public class LocalEventsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        public LocalEventsViewModel(User userr, NavigationStore navigationStore)
        {
            _user = userr;
            _navigationStore = navigationStore;
        }
    }
}
