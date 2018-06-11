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
    /// Interaction logic for Tables.xaml
    /// </summary>
    /// 

    public partial class Tables : Window
    {
        public ObservableCollection<Classroom> classrooms
        {
            get;
            set;
        }
        public ObservableCollection<Subject> subjects
        {
            get;
            set;
        }
        public ObservableCollection<Course> courses
        {
            get;
            set;
        }
        public ObservableCollection<Software> software
        {
            get;
            set;
        }
        public ObservableCollection<String> classroomsChoice
        {
            get;
            set;
        }
        public ObservableCollection<String> subjectsChoice
        {
            get;
            set;
        }
        public ObservableCollection<String> softwaresChoice
        {
            get;
            set;
        }
        public ObservableCollection<String> coursesChoice
        {
            get;
            set;
        }
        public Tables()
        {


            createChoices();
            this.classrooms = MainWindow.classrooms;
            this.software = MainWindow.softwares;
            this.courses = MainWindow.courses;
            this.subjects = MainWindow.subjects;
            this.DataContext = this;
            InitializeComponent();
        }
        private void createChoices()
        {
            this.classroomsChoice = new ObservableCollection<String>();
            classroomsChoice.Add("Po oznaci");
            classroomsChoice.Add("Po broju mesta");
            classroomsChoice.Add("Prisutvo projektora(da/ne)");
            classroomsChoice.Add("Prisutvo table(da/ne)");
            classroomsChoice.Add("Prisutvo pametne table(da/ne)");
            classroomsChoice.Add("Po operativnom sistemu");
            classroomsChoice.Add("Po oznaci prisutnog softvera");

            this.subjectsChoice = this.classroomsChoice;

            subjectsChoice.Add("Po imenu");
            subjectsChoice.Add("Po smeru");

            this.coursesChoice = new ObservableCollection<String>();
            coursesChoice.Add("Po oznaci");
            coursesChoice.Add("Po imenu");
            coursesChoice.Add("Po godini uvođenja");

            this.softwaresChoice = new ObservableCollection<String>();

            softwaresChoice.Add("Po оznaci");
            softwaresChoice.Add("Po imenu");
            softwaresChoice.Add("Po opisu");
            softwaresChoice.Add("Po proivođaču");
            softwaresChoice.Add("Po godini izdavanja");
            softwaresChoice.Add("Po operativnom sistemu");
            softwaresChoice.Add("Po ceni");
        }
        private void classroomFilter(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            string filterType = filterClassroomsType.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(ucionice.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Classroom p = o as Classroom;
                    if (filterType.Equals("Po oznaci"))
                    {

                        return (p.label.ToUpper().Contains(filter.ToUpper()));
                    }
                    else if (filterType.Equals("Po broju mesta"))
                    {
                        int x;
                        Int32.TryParse(filter, out x);
                        return (p.slots.Equals(x));

                    }
                    else if (filterType.Equals("Prisutvo projektora(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.projector.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.projector.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.tableExists.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.tableExists.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo pametne table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.smartTable.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.smartTable.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Po operativnom sistemu"))
                    {

                        return (p.os.ToUpper().Contains(filter.ToUpper()));

                    }
                    else if (filterType.Equals("Po oznaci prisutnog softvera"))
                    {
                        foreach (Software s in p.software)
                        {
                            if (s.label.ToUpper().Contains(filter.ToUpper()))
                            {
                                return true;
                            }

                        }
                        return false;

                    }
                    return true;


                };
            }

        }

        private void subjectsFilter(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            string filterType = filterSubjectsType.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(predmeti.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Subject p = o as Subject;
                    if (filterType.Equals("Po oznaci"))
                    {

                        return (p.label.ToUpper().Contains(filter.ToUpper()));
                    }
                    else if (filterType.Equals("Po imenu"))
                    {

                        return (p.name.Equals(int.Parse(filter)));

                    }
                    else if (filterType.Equals("Prisutvo projektora(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.projector.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.projector.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.tableExists.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.tableExists.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo pametne table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.smartTable.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.smartTable.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Po operativnom sistemu"))
                    {

                        return (p.os.ToUpper().Contains(filter.ToUpper()));

                    }
                    else if (filterType.Equals("Po oznaci prisutnog softvera"))
                    {
                        foreach (Software s in p.software)
                        {
                            if (s.label.ToUpper().Contains(filter.ToUpper()))
                            {
                                return true;
                            }

                        }
                        return false;

                    }
                    else if (filterType.Equals("Po smeru"))
                    {

                        return (p.course.label.ToUpper().Contains(filter.ToUpper()));

                    }
                    return true;


                };
            }


        }
        private void softwareFilter(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            string filterType = filterSubjectsType.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(predmeti.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Subject p = o as Subject;
                    if (filterType.Equals("Po oznaci"))
                    {

                        return (p.label.ToUpper().Contains(filter.ToUpper()));
                    }
                    else if (filterType.Equals("Po imenu"))
                    {

                        return (p.name.Equals(int.Parse(filter)));

                    }
                    else if (filterType.Equals("Prisutvo projektora(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.projector.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.projector.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.tableExists.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.tableExists.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo pametne table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.smartTable.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.smartTable.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Po operativnom sistemu"))
                    {

                        return (p.os.ToUpper().Contains(filter.ToUpper()));

                    }
                    else if (filterType.Equals("Po oznaci prisutnog softvera"))
                    {
                        foreach (Software s in p.software)
                        {
                            if (s.label.ToUpper().Contains(filter.ToUpper()))
                            {
                                return true;
                            }

                        }
                        return false;

                    }
                    else if (filterType.Equals("Po smeru"))
                    {

                        return (p.course.label.ToUpper().Contains(filter.ToUpper()));

                    }
                    return true;


                };
            }

        }
        private void coursesFilter(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            string filterType = filterSubjectsType.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(predmeti.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Subject p = o as Subject;
                    if (filterType.Equals("Po oznaci"))
                    {

                        return (p.label.ToUpper().Contains(filter.ToUpper()));
                    }
                    else if (filterType.Equals("Po imenu"))
                    {

                        return (p.name.Equals(int.Parse(filter)));

                    }
                    else if (filterType.Equals("Prisutvo projektora(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.projector.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.projector.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.tableExists.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.tableExists.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Prisutvo pametne table(da/ne)"))
                    {
                        if (filter.ToUpper().Equals("DA"))
                        {

                            return (p.smartTable.Equals(true));
                        }
                        else if (filter.ToUpper().Equals("NE"))
                        {
                            return (p.smartTable.Equals(false));
                        }
                        return false;

                    }
                    else if (filterType.Equals("Po operativnom sistemu"))
                    {

                        return (p.os.ToUpper().Contains(filter.ToUpper()));

                    }
                    else if (filterType.Equals("Po oznaci prisutnog softvera"))
                    {
                        foreach (Software s in p.software)
                        {
                            if (s.label.ToUpper().Contains(filter.ToUpper()))
                            {
                                return true;
                            }

                        }
                        return false;

                    }
                    else if (filterType.Equals("Po smeru"))
                    {

                        return (p.course.label.ToUpper().Contains(filter.ToUpper()));

                    }
                    return true;


                };
            }


        }

    }
}

