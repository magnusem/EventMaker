﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eh=EventMaker.Handler;

namespace EventMaker.ViewModel
{
    public class EventViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date  { get; set; }
        public TimeSpan Time { get; set; }
        private eh.EventHandler EventHandler { get; set; }

        public ICommand CreateEventCommand { get; set; }
        public Common.RelayCommand MyRelayCommand { get; set; }


        private Model.EventCatalogSingleton minEventCataLogSingleton = Model.EventCatalogSingleton.EventCatalogSingletonInstance;
        public Model.EventCatalogSingleton MinEventCataLogSingleton { get { return minEventCataLogSingleton; } }

        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            eh.EventHandler eh = new eh.EventHandler();
            MyRelayCommand = new Common.RelayCommand(eh.CreateEvent);
         }
    }
}