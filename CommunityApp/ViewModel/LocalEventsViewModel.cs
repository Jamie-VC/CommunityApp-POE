using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.Command;
using System.Collections.ObjectModel;

namespace CommunityApp.ViewModel
{
    public class LocalEventsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly User _user;

        //Data structures
        public ObservableCollection<Event> Events { get; set; }  //set the contents of this in the searchCommand
        private Queue<Event> _eventsQueue;
        private SortedDictionary<string, List<Event>> eventsByCategory;
        private SortedDictionary<DateOnly, List<Event>> eventsByDate;
        private HashSet<string> uniqueCategories;

        //Commands
        public ICommand BackCommand { get; }
        public ICommand SearchCommand { get; }

        public LocalEventsViewModel(User user, NavigationStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;

            Events = new ObservableCollection<Event>();
            _eventsQueue = new Queue<Event>();

            BackCommand = new NavigateMenuCommand(user, navigationStore);
            SearchCommand =new SearchEventsCommand(this, navigationStore, _eventsQueue, Events);

            LoadSampleData();
        }

        public void LoadSampleData()
        {
            _eventsQueue.Enqueue(new Event("37 Reasons", "Music", new DateOnly(2024, 10, 23)));
            _eventsQueue.Enqueue(new Event("Wildsfees", "Music", new DateOnly(2024, 6, 7)));
            _eventsQueue.Enqueue(new Event("Schalk Besuidenhoud", "Comedy", new DateOnly(2024, 11, 20)));
            _eventsQueue.Enqueue(new Event("Springbok Trophy Tour", "Sport", new DateOnly(2024, 1, 23)));
            _eventsQueue.Enqueue(new Event("Dricus du Plesis belt tour", "Sport", new DateOnly(2024, 2, 18)));
            _eventsQueue.Enqueue(new Event("Trevor Noah", "Comedy", new DateOnly(2024, 12, 23)));
            _eventsQueue.Enqueue(new Event("Leon Schushter", "Comedy", new DateOnly(2024, 07, 28)));
            _eventsQueue.Enqueue(new Event("Classic car run", "Cars", new DateOnly(2024, 10, 9)));
            _eventsQueue.Enqueue(new Event("Go Skate Day competition", "Sport", new DateOnly(2024, 6, 16)));
            _eventsQueue.Enqueue(new Event("Election Day", "Politics", new DateOnly(2024, 7, 19)));
            _eventsQueue.Enqueue(new Event("Beach Clean up", "Community", new DateOnly(2024, 4, 20)));
            _eventsQueue.Enqueue(new Event("Tyla concert", "Music", new DateOnly(2024, 12, 5)));
            _eventsQueue.Enqueue(new Event("Chris Brown concert", "Music", new DateOnly(2025, 1, 23)));

            //Adds Categories to Dictionary
            //foreach (var e in _eventsQueue)
            //{
            //    if (!eventsByCategory.ContainsKey(e.Category))
            //    {
            //        eventsByCategory[e.Category] = new List<Event>();
            //    }
            //    eventsByCategory[e.Category].Add(e);
            //}

            ////Adds dates to dicionary
            //foreach (var e in _eventsQueue)
            //{
            //    if (!eventsByDate.ContainsKey(e.Date))
            //    {
            //        eventsByDate[e.Date] = new List<Event>();
            //    }
            //    eventsByDate[e.Date].Add(e);
            //}

        }
    }
}
