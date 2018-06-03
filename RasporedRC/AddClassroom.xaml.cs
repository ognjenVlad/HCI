using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RasporedRC.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.ComponentModel;
namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for AddClassroom.xaml
    /// </summary>
    public partial class AddClassroom : Window
    {
        public ObservableCollection<string> OS
        {
            get;
            set;
        }
        public ObservableCollection<string> Software
        {
            get;
            set;
        }
        public String Label
        {
            get;
            set;
        }
        public String Slots
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }
        public Boolean TableCheckedT
        {
            get;
            set;
        }
        public Boolean TableCheckedF
        {
            get;
            set;
        }
        public Boolean SmartTableCheckedT
        {
            get;
            set;
        }
        public Boolean SmartTableCheckedF
        {
            get;
            set;
        }
        public Boolean ProjectorCheckedT
        {
            get;
            set;
        }
        public Boolean ProjectorCheckedF
        {
            get;
            set;
        }
        
        public String SelectedOS
        {
            get;
            set;
        }
        public String SelectedSoftware
        {
            get;
            set;
        }
        public BindingList<Software> SelectedSoftwares
        {
            get;
            set;
        }
        public AddClassroom()
        {
            
            OS = new ObservableCollection<string>();
            this.Software = new ObservableCollection<string>();
            this.SelectedSoftwares = new BindingList<Model.Software>();
            OS.Add("Windows");
            OS.Add("Linux");
            OS.Add("Windows/Linux");
            foreach(Software s in MainWindow.softwares) {

                this.Software.Add(s.label);
            }
             
            this.DataContext = this;
            InitializeComponent();

        }

        public void deleteSoftware(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(listView1.SelectedItems.Count);
            List<Software> sof = new List<Model.Software>();
            foreach (Software s in listView1.SelectedItems)
            {
                Console.WriteLine(s);
                sof.Add(s);
            }
            foreach(Software s in sof)
            {
                this.SelectedSoftwares.Remove(s);
                    
                
            }
        }

        //Koristi se za tabelu
        public void AddSoftware(object sender, RoutedEventArgs e)
        {
            
            this.SelectedSoftwares.Add(findSoftware(this.SelectedSoftware));
        }

        public Software findSoftware(String s)
        {
            foreach(Software soft in MainWindow.softwares)
            {
                if (soft.label == s)
                {
                    return soft;
                }
            }
            return null;
        }
        public void AddItem(object sender, RoutedEventArgs e)
        {
            if(this.ProjectorCheckedT == false && this.ProjectorCheckedF == false)
            {
                return;
            }
            if (this.TableCheckedT == false && this.TableCheckedF == false)
            {
                return;
            }
            if (this.SmartTableCheckedT == false && this.SmartTableCheckedF == false)
            {
                return;
            }
            Classroom classroom = new Classroom();
            classroom.os = this.SelectedOS;
            if (this.ProjectorCheckedT)
            {
                classroom.projector = true;
            }
            else
            {
                classroom.projector = false;
            }
            if (this.TableCheckedT)
            {
                classroom.tableExists = true;
            }
            else
            {
                classroom.tableExists = false;
            }
            if (this.SmartTableCheckedT)
            {
                classroom.smartTable = true;
            }
            else
            {
                classroom.smartTable = false;
            }
            classroom.label = this.Label;
            classroom.description = this.Description;
            classroom.slots = int.Parse(this.Slots);
            classroom.software = new List<Model.Software>();

            foreach (Software s in this.SelectedSoftwares)
            {
                
                classroom.software.Add(s);
            }
            Console.WriteLine(classroom.smartTable);
            Console.WriteLine(classroom.label);
            MainWindow.classrooms.Add(classroom);

            this.Close();
        }
        
    }
    
}
