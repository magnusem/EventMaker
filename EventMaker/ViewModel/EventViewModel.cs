using EventMaker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eh = EventMaker.Handler;

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
        private Event SelectedEvent;

        public Event selectedEvent
        {
            get { return SelectedEvent; }
            set { selectedEvent = value;
                OnPropertyChanged(nameof(selectedEvent));
                    }
        }

        #region vores PropertyChangedEventHandler 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public ICommand CreateEventCommand { get; set; }
        public Common.RelayCommand DeleteEventCommand { get; set; }
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
            DeleteEventCommand = new Common.RelayCommand(eh.DeleteEvent);

         }



    }
}
