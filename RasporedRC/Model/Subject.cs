using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RasporedRC.Model
{
    public class Subject: INotifyPropertyChanged
    {
        public String label { get; set; }

        public String description { get; set; }

        public String name { get; set; }
        public Course c;
        public Course course
        {
            get { return this.c; }
            set
            {
                c = value;
                OnPropertyChanged("course");
            }
        }
public int groupSize { get; set; }
        public int numberOfClasses { get; set; }
        public int numberOfAppointment { get; set; }
        private bool p;
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
        public bool tableExists
        {
            get { return this.table; }
            set
            {
                table = value;
                OnPropertyChanged("tableExists");
            }
        }
        private bool st;
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
        private List<Software> listSoft;
        public List<Software> software
        {
            get { return this.listSoft; }
            set
            {
                listSoft = value;
                OnPropertyChanged("software");
            }
        }
        public Subject()
        {
            software = new List<Software>();
        }
        public Subject(String l,String n, String d, Course c, int gs, int nc, int na, bool p, bool te, bool st, string os)
        {
            this.label = l;
            this.name = n;
            this.description = d;
            this.course = c;
            this.groupSize = gs;
            this.numberOfClasses = nc;
            this.numberOfAppointment = na;
            this.projector = p;
            this.tableExists = te;
            this.smartTable = st;
            this.os = os;
            this.software = new List<Software>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
