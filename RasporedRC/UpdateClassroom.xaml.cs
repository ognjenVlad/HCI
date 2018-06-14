using RasporedRC.Model;
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

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for UpdateClassroom.xaml
    /// </summary>
    public partial class UpdateClassroom : Window
    {
        public ObservableCollection<string> Software
        {
            get;
            set;
        }
        public ObservableCollection<string> OS
        {
            get;
            set;
        }
        public Boolean TableCheckedT
        {
            get;
            set;
        }
        public Classroom classroomToUpdate
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
        public String SelectedSoftware
        {
            get;
            set;
        }
        public String SelectedOS
        {
            get;
            set;
        }
        public BindingList<Software> SelectedSoftwares
        {
            get;
            set;
        }
        public UpdateClassroom()
        {

           
            this.Software = new ObservableCollection<string>();
            this.SelectedSoftwares = new BindingList<Model.Software>();
            this.OS = MainWindow.OS;
            foreach (Software s in MainWindow.softwares)
            {

                this.Software.Add(s.label);
            }
            foreach (Software s in MainWindow.classroomToUpdate.software)
            {

                this.SelectedSoftwares.Add(s);
            }

            this.classroomToUpdate = MainWindow.classroomToUpdate;
            this.DataContext = this;
            

            this.ProjectorCheckedT = MainWindow.classroomToUpdate.projector;
            this.ProjectorCheckedF = !MainWindow.classroomToUpdate.projector;

            this.SmartTableCheckedT = MainWindow.classroomToUpdate.smartTable;
            this.SmartTableCheckedF = !MainWindow.classroomToUpdate.smartTable;

            this.TableCheckedT = MainWindow.classroomToUpdate.tableExists;
            this.TableCheckedF = !MainWindow.classroomToUpdate.tableExists;
            InitializeComponent();

           

            this.os.SelectedValue = MainWindow.classroomToUpdate.os;
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
                this.Software.Add(s.label);

            }
        }

        //Koristi se za tabelu
        public void AddSoftware(object sender, RoutedEventArgs e)
        {
            if(this.SelectedSoftware == null)
            {
                return;
            }
            this.SelectedSoftwares.Add(findSoftware(this.SelectedSoftware));
            this.Software.Remove(this.SelectedSoftware);
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
        public void extractSoftwares()
        {
            this.classroomToUpdate.software.Clear();
            foreach(Software s in this.SelectedSoftwares)
            {
                this.classroomToUpdate.software.Add(s);
                
            }

        }
        public void ChangeItem(object sender, RoutedEventArgs e)
        {
            MainWindow.classroomToUpdate.tableExists = TableCheckedT;
            this.classroomToUpdate.smartTable = SmartTableCheckedT;
            this.classroomToUpdate.projector = ProjectorCheckedT;
            extractSoftwares();
            MainWindow.checkClassrooms();
            MessageBox.Show("Učionica uspešno promenjna!", "Izmena učionice", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
   
}
