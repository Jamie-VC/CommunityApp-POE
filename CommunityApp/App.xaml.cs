using CommunityApp.Model;
using System.Configuration;
using System.Data;
using System.Windows;
using CommunityApp.ViewModel;
using CommunityApp.Stores;
using CommunityApp.Services;

namespace CommunityApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly User _user;
        private readonly NavigationStore _navigationStore;

        HashSet<string> _interests = new HashSet<string>();
        public App()
        {
            _interests.Add("Music");
            _interests.Add("Sport");
            _user = new User("User", _interests);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_user, _navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
