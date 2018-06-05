using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedRC.Model
{
    public class Classroom: INotifyPropertyChanged
    {
        public String label { get; set; }

        public String description { get; set; }

        public int slots { get; set; }
        private bool p;
        private bool st;
        public bool projector
        {
            get { return this.p; }
            set
            {
                p = value;
                OnPropertyChanged("projector");
            }
        }
        private bool table;
        public bool tableExists {
            get { return this.table; }
            set {
                table = value;
                OnPropertyChanged("tableExists"); } }
        public bool smartTable
        {
            get { return this.st; }
            set
            {
                st = value;
                OnPropertyChanged("smartTable");
            }
        }
        public String os { get; set; }
        public List<Software> listSoft;
        public List<Software> software
        {
            get { return this.listSoft; }
            set
            {
                listSoft = value;
                OnPropertyChanged("software");
            }
        }
        public Classroom() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public Classroom(string label, string d, int s, bool p, bool te, bool st, string os)
        {
            this.label = label;
            this.description = d;
            this.slots = s;
            this.projector = p;
            this.tableExists = te;
            this.smartTable = st;
            this.os = os;
            this.software = new List<Software>();
        }
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
