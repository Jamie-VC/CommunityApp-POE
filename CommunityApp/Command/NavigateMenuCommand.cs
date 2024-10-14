using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommunityApp.Command
{
    public  class NavigateMenuCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        public NavigateMenuCommand(User user, NavigationStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_user, _navigationStore);
        }
    }
}
