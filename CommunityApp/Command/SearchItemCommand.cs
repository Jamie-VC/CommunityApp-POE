﻿using System;
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
        public Dictionary<string, int> searchDic = new Dictionary<string, int>();
        //public List<Event> events = new List<Event>();
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
                        _recommendations.Add(item);
                    }
                    //for (int i = 0; i < searches.Count; i++)
                    //{
                    //    if (searches[i].Equals(item.Name))
                    //    {
                    //        //events.Add(item);
                    //        if (!_recommendations.Contains(item))
                    //        {
                    //            if (item.Category.Count() > 2)
                    //            {
                    //                _recommendations.Add(item);
                    //            }

                    //        }

                    //    }
                    //}
                }

            _localEventsViewModel.Events.Clear();
            //_localEventsViewModel.Events
            var p = _queue.Where(e => e.Name.Equals(_localEventsViewModel.SearchItem)).ToList();
            foreach (var i in p)
            {
                _localEventsViewModel.Events.Add(i);
            }   
        }
    }
}
