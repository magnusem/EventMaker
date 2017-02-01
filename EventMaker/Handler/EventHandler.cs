using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.ViewModel;
using EventMaker.Handler;

namespace EventMaker.Handler
{
    class EventHandler
    {
        private EventViewModel evm { get; set; }

        public EventHandler()
        {
        }



        public void CreateEvent()
        {
            Model.Event TempEventInfo = new Model.Event();
            TempEventInfo.Id = evm.Id;
            TempEventInfo.Name = evm.Name;
            TempEventInfo.Place = evm.Place;
            TempEventInfo.Description = evm.Description;
            TempEventInfo.DateTime = Converter.DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(evm.Date, evm.Time);
            Model.EventCatalogSingleton.EventCatalogSingletonInstance.EventListe.Add(TempEventInfo);
        }


    }
}
