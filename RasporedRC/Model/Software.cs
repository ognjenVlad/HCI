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


        private String Manofacturer;
        public String manofacturer
        {
            get { return this.Manofacturer; }
            set
            {
                Manofacturer = value;
                OnPropertyChanged("manofacturer");
            }
        }
        private String Website;
        public String website
        {
            get { return this.Website; }
            set
            {
                Website = value;
                OnPropertyChanged("website");
            }
        }
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
        private double Price;
        public double price
        {
            get { return this.Price; }
            set
            {
                Price = value;
                OnPropertyChanged("price");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public Software() { }

        public Software(string label, string name, string descr, string manofacturer, string website, string year, 
            string os, double price)
        {
            this.label = label;
            this.name = name;
            this.description = descr;
            this.manofacturer = manofacturer;
            this.website = website;
            this.yearOfPublishing = year;
            this.os = os;
            this.price = price;
        }

    }
}
