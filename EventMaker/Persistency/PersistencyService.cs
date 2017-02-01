using EventMaker.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace EventMaker.Persistency
{
    class PersistencyService
    {

        static private readonly string filename = "EventFile.json";
        static StorageFolder localfolder = null;
        public static async void SaveEventsAsJasonAsync(ObservableCollection<Event> events)
        {
            string jsontext = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(jsontext, filename);
        }


        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            Model.EventCatalogSingleton.EventCatalogSingletonInstance.EventListe.Clear();
            Task<string> jsonTaskText = DeSerializeEventsFileAsync(filename);

            List<Event> newList = JsonConvert.DeserializeObject<List<Event>>(jsonTaskText.ToString());
            foreach (var i in newList)
            {
                newList.Add(i);
            }
            return newList;
        }




        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {

        }


        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            List<Event> nyListe = JsonConvert.DeserializeObject<List<Event>>(fileName);
            foreach (var e in nyListe)
            {
                EventCatalogSingleton.EventCatalogSingletonInstance.EventListe.Add(e);
            }
        }
    }
}
