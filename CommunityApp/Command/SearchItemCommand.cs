using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityApp.Stores;
using CommunityApp.ViewModel;
using CommunityApp.Model;
using System.Collections.ObjectModel;

namespace CommunityApp.Command
{
    public class SearchItemCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly LocalEventsViewModel _localEventsViewModel;
        private readonly Queue<Event> _queue;
        private readonly User _user;
        private readonly ObservableCollection<Event> _recommendations;

        public List<string> searches = new List<string>();
        public List<string> recCat = new List<string>();

        public SearchItemCommand(LocalEventsViewModel localEventsViewModel, NavigationStore navigationStore, Queue<Event> eventQueue, ObservableCollection<Event> recommendedEvents, User user)
        { 
            _localEventsViewModel = localEventsViewModel;
            _navigationStore = navigationStore;
            _queue = eventQueue;
            _recommendations = recommendedEvents;
            _user = user;
        }

        public override void Execute(object? parameter)
        {
            searches.Add(_localEventsViewModel.SearchItem);

                foreach (var item in _queue)
                {
                    if (item.Name.Equals(_localEventsViewModel.SearchItem)
                        && _user.Interests.Contains(item.Category))
                    {
                        recCat.Add(item.Category);
                    }
                }
                foreach (var item in _queue)
                {
                    if(recCat.Contains(item.Category))
                    {
                        _recommendations.Add(item);
                    }
                }

            _localEventsViewModel.Events.Clear();

            var p = _queue.Where(e => e.Name.Equals(_localEventsViewModel.SearchItem)).ToList();
            foreach (var i in p)
            {
                _localEventsViewModel.Events.Add(i);
            }
            _localEventsViewModel.SearchItem = null;        //take note
        }
    }
}
