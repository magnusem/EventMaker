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
        public ViewModel.EventViewModel Minslected { get; set; }

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
            EventListe.Add(new Event() { Id = 420, Description = "James Bond", Name = "Yamez Blunt", Place = "UK" });

            //event2
            EventListe.Add(new Event() { Id = 008, Description = "Bind Semaj", Name = "Blazer Max", Place = "KU" });

            Minslected = new ViewModel.EventViewModel();
        }


        //tilføjer addEvent - gør det muligt at tilføje til vores observablecollection
        public void AddEvent()
        {
            EventListe.Add(NewEvent);
           
        }

        //public void SletElev()
        //{
        //    PListe.Remove(SelectedElev);
        //}
        public void RemoveEvent()
        {
            EventListe.Remove(Minslected.selectedEvent);
        }

        
    }
}
