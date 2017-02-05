using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
  public  class Event
    {
        //instance field


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime DateTime { get; set; }

        //ctor
        public Event()
        {
        }


        //overskrive to string
        public override string ToString()
        {
            return Id + " " +
                Name + " " +
                Description + " " +
                Place + " " +
                DateTime + " ";
        }


    }
}
