using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedRC.Model
{
    public class Course: INotifyPropertyChanged
    {
        public String label { get; set; }

        public String description { get; set; }

        public String name { get; set; }
        private String c;
        public String startingYear
        {
            get { return this.c; }
            set
            {
                c = value;
                OnPropertyChanged("startingYear");
            }
        }
        public Course() { }
        public Course(String label, String desc, String name, String year)
        {
            this.label = label;
            this.description = desc;
            this.name = name;
            this.startingYear = year;
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
