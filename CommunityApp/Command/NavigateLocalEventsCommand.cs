using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Command
{
    public class NavigateLocalEventsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        public NavigateLocalEventsCommand(User user, NavigationStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new LocalEventsViewModel(_user, _navigationStore);
        }
    }
}
