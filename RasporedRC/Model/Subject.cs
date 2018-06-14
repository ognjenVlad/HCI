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
        private String Label;
        public String label
        {
            get { return this.Label; }
            set
            {
                Label = value;
                OnPropertyChanged("label");
            }
        }

        private String Description;
        public String description
        {
            get { return this.Description; }
            set
            {
                Description = value;
                OnPropertyChanged("description");
            }
        }
        private String Name;
        public String name
        {
            get { return this.Name; }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }
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
       
        private int gs;
        public int groupSize
        {
            get { return this.gs; }
            set
            {
                gs = value;
                OnPropertyChanged("groupSize");
            }
        }
        private int noc;
        public int numberOfClasses
        {
            get { return this.noc; }
            set
            {
                noc = value;
                OnPropertyChanged("numberOfClasses");
            }
        }
        private int noa;
        public int numberOfAppointment
        {
            get { return this.noa; }
            set
            {
                noa = value;
                OnPropertyChanged("numberOfAppointment");
            }
        }
        
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
        private string OS;
        public string os
        {
            get { return this.OS; }
            set
            {
                OS = value;
                OnPropertyChanged("os");
            }
        }
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
