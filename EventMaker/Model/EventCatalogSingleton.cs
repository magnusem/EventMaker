using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
   public class EventCatalogSingleton
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
        private EventCatalogSingleton()
        {
            EventListe = new ObservableCollection<Event>();
            //event 1
            EventListe.Add(new Event() { Id = 0001, Description = "Fodbold for alle er et hygge arangement for alle mellem 6-50", Name = "Fodbold for alle", Place = "Roskilde Stadion" });

            //event2
            EventListe.Add(new Event() { Id = 0002, Description = "Arrangement for pensionister i Roskilde Komune", Name = "Pensionist Bowling", Place = "Roskilde Bowlingcenter" });

           
        }


        //tilføjer addEvent - gør det muligt at tilføje til vores observablecollection
        public void AddEvent(Event NewEvent)
        {
            EventListe.Add(NewEvent);
           
        }

        //public void SletElev()
        //{
        //    PListe.Remove(SelectedElev);
        //}
        public void RemoveEvent(Event EventRemove)
        {
            EventListe.Remove(EventRemove);
        }

        
    }
}
