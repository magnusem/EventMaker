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

        #region

        //{
        //    static private readonly string filename = "EventFile.json";
        //    static StorageFolder localfolder = null;

        //    public static async void SaveEventAsJsonAsync(ObservableCollection<Event> events)
        //    {
        //        string jsonText = JsonConvert.SerializeObject(events);
        //        SerializeEventsFileAsync(jsonText, filename);
        //    }

        //    public static async Task<List<Event>> LoadEventsFromJsonAsync()
        //    {
        //        Model.EventCatalogSingleton.EventCatalogSingletonInstance.EventListe.Clear();

        //        Task<string> jsonTaskText = DeSerializeEventsFileAsync(filename);
        //        List<Event> newList = JsonConvert.DeserializeObject<List<Event>>(jsonTaskText.ToString());
        //        foreach (var i in newList)
        //        {
        //            newList.Add(i);
        //        }
        //        //Model.EventCatalogSingleton.Instance.EventListe
        //        return newList;
        //    }


        //    private static async void SerializeEventsFileAsync(string eventsString, string filename)
        //    {
        //        StorageFile file = await localfolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
        //        await FileIO.WriteTextAsync(file, eventsString);
        //    }


        //    private static async Task<string> DeSerializeEventsFileAsync(string filename)
        //    {
        //        StorageFile file = await localfolder.GetFileAsync(filename);
        //        string jsonText = await FileIO.ReadTextAsync(file);
        //        return jsonText;
        //    }
        //}
        #endregion

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


    }
}
