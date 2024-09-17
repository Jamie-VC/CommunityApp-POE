using CommunityApp.Stores;
using CommunityApp.ViewModel;
using CommunityApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Services;

namespace CommunityApp.Command
{
    public class NavigateCommand : CommandBase
    {
        private NavigationService _navigationService;
        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
