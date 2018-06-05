using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedRC.Model
{
    public class Software: INotifyPropertyChanged
    {
        public String label { get; set; }
        public String name { get; set; }
        public String description { get; set; }

       
        public String manofacturer { get; set; }
        public String website { get; set; }
        private String c;
        public String yearOfPublishing
        {
            get { return this.c; }
            set
            {
                c = value;
                OnPropertyChanged("yearOfPublishing");
            }
        }
        public String os { get; set; }
        public double price { get; set; }
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
