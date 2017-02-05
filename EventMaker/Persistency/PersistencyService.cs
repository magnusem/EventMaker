using EventMaker.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using System.ComponentModel;


namespace EventMaker.Persistency
{
    public class PersistencyService
    {
        private readonly Task<StorageFile> localfolder;
        private object filnavn;

        public ObservableCollection<Event> EventListe { get; set; }


        const String fileName = "filNavn.json";

        public static async void SaveEventAsJsonAsync()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(EventCatalogSingleton.EventCatalogSingletonInstance.EventListe);
            await FileIO.WriteTextAsync(localFile, JsonData);

        }

        
        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            String jsonData = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonData);
        }

        //metode til at tage "serialized" og smide den ind på en "nyliste" via foreach
        public void IndsætJson(string filnavn)
        {
            List<Event> nyListe = JsonConvert.DeserializeObject<List<Event>>(filnavn);
            foreach (var i in nyListe)
            {
                Model.EventCatalogSingleton.EventCatalogSingletonInstance.EventListe.Add(i);
            }
        }

    }
}
