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

        #region Select event prop & instance field

        private Event selectedEvent;
        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        #endregion


        #region vores PropertyChangedEventHandler 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            eh.EventHandler eh = new eh.EventHandler(this);

            DeleteEventCommand = new Common.RelayCommand(eh.DeleteEvent);
            CreateEventCommand = new Common.RelayCommand(eh.CreateEvent);

         }



    }
}
