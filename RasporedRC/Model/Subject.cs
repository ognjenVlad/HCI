using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RasporedRC.Model
{
    public class Subject
    {
        public String label { get; set; }

        public String description { get; set; }

        public String name { get; set; }

        public Course course { get; set; }
        public int grupSize { get; set; }
        public int numberOfClasses { get; set; }
        public int numberOfAppointment { get; set; }
        public bool projector { get; set; }
        public bool tableExists { get; set; }
        public bool smartTable { get; set; }
        public String os { get; set; }
        public List<Software> software { get; set; }
    }
}
