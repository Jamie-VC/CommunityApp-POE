using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityApp.Command;
using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.Services;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace CommunityApp.ViewModel
{
    public class ReportIssueViewModel : ViewModelBase
    {
        private string _location;
        private string _category;
        private string _description;
        private string _mediaPath;
        //private List<Issue> _issueList;

        public ObservableCollection<string> Categories { get; }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string MediaPath
        {
            get => _mediaPath;
            set
            {
                _mediaPath = value;
                OnPropertyChanged(nameof(MediaPath));
            }
        }
        public ICommand AttachMediaCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ReportIssueViewModel(User user, NavigationStore navigationStore)
        {
            Categories = new ObservableCollection<string>
            {
                "Sanitation",
                "Roads",
                "Utilities"
            };

            AttachMediaCommand = new AttachMediaCommand(this);
            SubmitCommand = new ReportIssueCommand(this, user, navigationStore);
            CancelCommand = new NavigateIssueListCommand(user, navigationStore);
        }
        public void AttachMedia()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                MediaPath = openFileDialog.FileName;
            }
        }
    }
}
