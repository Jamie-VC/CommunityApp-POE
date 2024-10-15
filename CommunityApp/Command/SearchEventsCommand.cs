﻿using CommunityApp.Model;
using CommunityApp.Stores;
using CommunityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp.Command
{
    public class SearchEventsCommand : CommandBase
    {
        private readonly LocalEventsViewModel _localEventsViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly Queue<Event> _events;
        public SearchEventsCommand(LocalEventsViewModel localEventsViewModel, NavigationStore navigationStore, 
            Queue<Event> eventQueue, ObservableCollection<Event> eventsCollection)
        {
            _localEventsViewModel = localEventsViewModel;
            _navigationStore = navigationStore;
            _events = eventQueue;
            _localEventsViewModel.Events = eventsCollection;
        }
        public override void Execute(object? parameter)
        {
           _localEventsViewModel.Events.Clear();
            //_localEventsViewModel.LoadSampleData();
            if (_localEventsViewModel.SelectedCategory ==null && _localEventsViewModel.SelectedDate == null)
            {
                foreach (var e in _events)
                {
                    _localEventsViewModel.Events.Add(e);
                }
            }
            else if (_localEventsViewModel.SelectedDate ==null)
            {
                var filter = _events.Where(e => e.Category == _localEventsViewModel.SelectedCategory).ToList();

                foreach (var e in filter)
                {
                    _localEventsViewModel.Events.Add(e);
                }
            }
            else if(_localEventsViewModel.SelectedCategory == null)
            {
                var filter = _events.Where(e => e.Date == DateOnly.Parse(_localEventsViewModel.SelectedDate)).ToList();

                foreach (var e in filter)
                {
                    _localEventsViewModel.Events.Add(e);
                }
            }
            else if (_localEventsViewModel.SelectedCategory != null && _localEventsViewModel.SelectedDate != null)
            {
                var filter = _events.Where(e => e.Category == _localEventsViewModel.SelectedCategory
                && e.Date == DateOnly.Parse(_localEventsViewModel.SelectedDate)).ToList();

                foreach(var e in filter)
                {
                    _localEventsViewModel.Events.Add(e);
                }
            }
        }
    }
}
