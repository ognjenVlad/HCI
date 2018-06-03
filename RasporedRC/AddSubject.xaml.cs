using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Window
    {
        public ObservableCollection<string> OS
        {
            get;
            set;
        }
        public ObservableCollection<string> Courses
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
        public String SubjectName
        {
            get;
            set;
        }
        public Course Course
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }
        public String GroupSize
        {
            get;
            set;
        }
        public String NumberOfClasses
        {
            get;
            set;
        }
        public String NumberOfAppointment
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
        public String SelectedCourse
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
        public AddSubject()
        {
            OS = new ObservableCollection<string>();
            this.Software = new ObservableCollection<string>();
            this.SelectedSoftwares = new BindingList<Model.Software>();
            this.Courses = new ObservableCollection<string>();
            OS.Add("Windows");
            OS.Add("Linux");
            OS.Add("Windows/Linux");
            foreach (Software s in MainWindow.softwares)
            {

                this.Software.Add(s.label);
            }
            foreach (Course s in MainWindow.courses)
            {

                this.Courses.Add(s.label);
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
            foreach (Software s in sof)
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
            foreach (Software soft in MainWindow.softwares)
            {
                if (soft.label == s)
                {
                    return soft;
                }
            }
            return null;
        }
        public Course findCourse(String s)
        {
            foreach (Course c in MainWindow.courses)
            {
                if (c.label == s)
                {
                    return c;
                }
            }
            return null;
        }
        public void AddItem(object sender, RoutedEventArgs e)
        {
            if (this.ProjectorCheckedT == false && this.ProjectorCheckedF == false)
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
            Subject subject = new Subject();
            subject.os = this.SelectedOS;
            if (this.ProjectorCheckedT)
            {
                subject.projector = true;
            }
            else
            {
                subject.projector = false;
            }
            if (this.TableCheckedT)
            {
                subject.tableExists = true;
            }
            else
            {
                subject.tableExists = false;
            }
            if (this.SmartTableCheckedT)
            {
                subject.smartTable = true;
            }
            else
            {
                subject.smartTable = false;
            }
            subject.label = this.Label;
            subject.description = this.Description;
            subject.grupSize = int.Parse(this.GroupSize);
            subject.software = new List<Model.Software>();
            subject.numberOfAppointment = int.Parse(this.NumberOfAppointment);
            subject.numberOfClasses = int.Parse(this.NumberOfClasses);
            subject.name = this.Name;
            subject.course = findCourse(this.SelectedCourse);

            foreach (Software s in this.SelectedSoftwares)
            {

                subject.software.Add(s);
            }
            Console.WriteLine(subject.smartTable);
            Console.WriteLine(subject.label);
            MainWindow.subjects.Add(subject);

            this.Close();

        }
    }
}
