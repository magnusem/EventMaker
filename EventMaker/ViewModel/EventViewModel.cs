using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.ViewModel
{
    public class EventViewModel
    {
        private Model.EventCatalogSingleton minEventCataLogSingleton = Model.EventCatalogSingleton.EventCatalogSingletonInstance;

        public Model.EventCatalogSingleton MinEventCataLogSingleton { get { return minEventCataLogSingleton; } }
    }
}
