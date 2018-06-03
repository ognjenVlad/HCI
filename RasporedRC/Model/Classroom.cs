using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedRC.Model
{
    public class Classroom
    {
        public String label { get; set; }

        public String description { get; set; }

        public int slots { get; set; }
        public bool projector { get; set; }
        public bool tableExists { get; set; }
        public bool smartTable { get; set; }
        public String os { get; set; }
        public List<Software> software { get; set; }
        

    }
}
