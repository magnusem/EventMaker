using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
   public class EventCatalogSingleton : ObservableCollection<Event>
    {

        //props
        public ObservableCollection<Event> EventListe { get; set; }
        public Event NewEvent { get; set; }


        //laver en singleton
        private static EventCatalogSingleton eventCatalogSingletonInstance = new EventCatalogSingleton();

        public static EventCatalogSingleton EventCatalogSingletonInstance
        {
            get { return eventCatalogSingletonInstance; }
        }


        //private ctor pga singleton
        private EventCatalogSingleton() : base()
        {
            //event 1
            EventCatalogSingletonInstance.Add(new Event() { Id = 420, Description = "James Bond", Name = "Yamez Blunt", Place = "UK" });

            //event2
            EventCatalogSingletonInstance.Add(new Event() { Id = 008, Description = "Bind SemaJ", Name = "Blazer Max", Place = "KU" });
        }

        //tilføjer addEvent - gør det muligt at tilføje til vores observablecollection
        public void AddEvent()
        {
            Event TempEventInfo = new Event();
            TempEventInfo.Id = NewEvent.Id;
            TempEventInfo.Name = NewEvent.Name;
            TempEventInfo.Place = NewEvent.Place;
            TempEventInfo.Description = NewEvent.Description;
            TempEventInfo.DateTime = NewEvent.DateTime;

            EventListe.Add(TempEventInfo);
        }

    }
}
