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
        public App()
        {
            _user = new User("User");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //_navigationStore.CurrentViewModel = CreateIssueViewModel();
            _navigationStore.CurrentViewModel = CreateMainMenuViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private ReportIssueViewModel CreateReportIssueViewModel()
        {
            return new ReportIssueViewModel(_user, new NavigationService(_navigationStore, CreateIssueViewModel));
        }

        private IssueListViewModel CreateIssueViewModel()
        {
            return new IssueListViewModel(_user, new NavigationService(_navigationStore, CreateReportIssueViewModel));
        }

        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(_user, new NavigationService(_navigationStore, CreateIssueViewModel));
        }
    }

}
