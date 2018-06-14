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
