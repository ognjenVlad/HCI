﻿using RasporedRC.Model;
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
    public partial class UpdateSubject : Window { 
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
        public String oldID
        {
            get;
            set;
        }
        public BindingList<Software> SelectedSoftwares
        {
            get;
            set;
        }
        public Subject subjectToUpdate
        {
            get;
            set;
        }
        public UpdateSubject()
        {
        
            OS = MainWindow.OS;
            this.Software = new ObservableCollection<string>();
            this.SelectedSoftwares = new BindingList<Model.Software>();
            this.Courses = new ObservableCollection<string>();

            foreach (Software s in MainWindow.subjectToUpdate.software)
            {

                this.SelectedSoftwares.Add(s);
            }

            foreach (Course s in MainWindow.courses)
            {

                this.Courses.Add(s.label);
            }
            this.subjectToUpdate = MainWindow.subjectToUpdate;
            this.oldID = this.subjectToUpdate.label;
            this.DataContext = this;


            this.ProjectorCheckedT = MainWindow.subjectToUpdate.projector;
            this.ProjectorCheckedF = !MainWindow.subjectToUpdate.projector;

            this.SmartTableCheckedT = MainWindow.subjectToUpdate.smartTable;
            this.SmartTableCheckedF = !MainWindow.subjectToUpdate.smartTable;

            this.TableCheckedT = MainWindow.subjectToUpdate.tableExists;
            this.TableCheckedF = !MainWindow.subjectToUpdate.tableExists;

            this.DataContext = this;
            InitializeComponent();
            Console.WriteLine(MainWindow.subjectToUpdate.os);
            this.os.SelectedValue = MainWindow.subjectToUpdate.os;
            this.course.SelectedValue = MainWindow.subjectToUpdate.course.label;

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
            if (this.SelectedSoftware == null)
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
        public void extractSoftwares()
        {
            this.subjectToUpdate.software.Clear();
            foreach (Software s in this.SelectedSoftwares)
            {
                this.subjectToUpdate.software.Add(s);

            }

        }
        public void ChangeSubject(object sender, RoutedEventArgs e)
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

            this.subjectToUpdate.tableExists = TableCheckedT;
            this.subjectToUpdate.smartTable = SmartTableCheckedT;
            this.subjectToUpdate.projector = ProjectorCheckedT;
            this.subjectToUpdate.os = this.SelectedOS;
            this.subjectToUpdate.course = findCourse(this.SelectedCourse);
            extractSoftwares();
            MainWindow.updateTermBySubject(this.oldID, this.subjectToUpdate);
            MainWindow.checkClassrooms();
            MessageBox.Show("Predmet uspešno promenjnen!", "Izmena učionice", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

        }

        private void os_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Software.Clear();
            if (SelectedOS == "Windows/Linux")
            {
                foreach (var soft in MainWindow.softwares)
                {
                    Software.Add(soft.label);
                }
            }
            else if (SelectedOS == "Windows")
            {
                foreach (var soft in MainWindow.softwares)
                {
                    if (soft.os != "Linux")
                    {
                        Software.Add(soft.label);
                    }
                }
            }
            else
            {
                foreach (var soft in MainWindow.softwares)
                {
                    if (soft.os != "Windows")
                    {
                        Software.Add(soft.label);
                    }
                }
            }

            for (int i = Software.Count - 1; i > -1; i--)
            {
                foreach (var soft in SelectedSoftwares)
                {
                    if (soft.label == Software[i])
                    {
                        Software.RemoveAt(i);
                        break;
                    }
                }
            }
            SelectedSoftware = null;
            return;
        }
    }
}
