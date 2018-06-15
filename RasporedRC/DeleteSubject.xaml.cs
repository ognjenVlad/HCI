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

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for DeleteSubject.xaml
    /// </summary>
    public partial class DeleteSubject : Window
    {
        public ObservableCollection<Subject> subjects
        {
            get;
            set;
        }
        public ObservableCollection<Classroom> classrooms
        {
            get;
            set;
        }
        public ObservableCollection<Software> softwares
        {
            get;
            set;
        }
        public ObservableCollection<Course> courses
        {
            get;
            set;
        }
        public void updateClassroom(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Classroom sub = button.DataContext as Classroom;
            foreach (Classroom s in MainWindow.classrooms)
            {
                if (s.label.Equals(sub.label))
                {
                    MainWindow.classroomToUpdate = s;
                    UpdateClassroom u = new UpdateClassroom();
                    
                    u.ShowDialog();
                    s.OnPropertyChanged("software");
                }
            }


        }

        public void updateSubject(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Subject sub = button.DataContext as Subject;
            foreach (Subject s in MainWindow.subjects)
            {
                if (s.label.Equals(sub.label))
                {
                    MainWindow.subjectToUpdate = s;
                    UpdateSubject u = new UpdateSubject();

                    u.ShowDialog();
                    s.OnPropertyChanged("software");
                    s.OnPropertyChanged("course");
                }
            }


        }
        public void updateSoftware(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Software sub = button.DataContext as Software;
            foreach (Software s in MainWindow.softwares)
            {
                if (s.label.Equals(sub.label))
                {
                    MainWindow.softwareToUpdate = s;
                    UpdateSoftware u = new UpdateSoftware();

                    u.ShowDialog();
                }
            }


        }
        public void updateCourse(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Course sub = button.DataContext as Course;
            foreach (Course s in MainWindow.courses)
            {
                if (s.label.Equals(sub.label))
                {
                    MainWindow.courseToUpdate = s;
                    UpdateCourse u = new UpdateCourse();

                    u.ShowDialog();
                }
            }


        }
        public void deleteSubject(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Subject sub = button.DataContext as Subject;
            foreach (Subject s in MainWindow.subjects)
            {
                if (s.label.Equals(sub.label))
                {
                    sub = s;
                }
            }
            MainWindow.subjects.Remove(sub);
            MainWindow.removeTermBySubject(sub.label);
        }
        public void deleteClassroom(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Classroom sub = button.DataContext as Classroom;
            foreach (Classroom s in MainWindow.classrooms)
            {
                if (s.label.Equals(sub.label))
                {
                    sub = s;
                }
            }
            MainWindow.classrooms.Remove(sub);
            MainWindow.removeClassroom(sub.label);

        }
        public void deleteSoftware(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Software sub = button.DataContext as Software;
            if (findSoftware(sub))
            {
                MessageBox.Show("Nije moguće izbrisati softver koji je u upotrebi! Molim Vas prvo " +
                    "izbrišite/izmenite učionicu/predmet koji ga koristi.", "Brisanje softvera", MessageBoxButton.OK,MessageBoxImage.Error);
                return;

            }
            foreach (Software s in MainWindow.softwares)
            {
                if (s.label.Equals(sub.label))
                {
                    sub = s;
                }
            }
            MainWindow.softwares.Remove(sub);

        }
        public void deleteCourse(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Course sub = button.DataContext as Course;
            if (findCourse(sub))
            {
                MessageBox.Show("Nije moguće izbrisati smer koji je u upotrebi! Molim Vas prvo "+
                    "izbrišite/izmenite predmet koji ga koristi.", "Brisanje smera",MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            foreach (Course s in MainWindow.courses)
            {
                if (s.label.Equals(sub.label))
                {
                    sub = s;
                }
            }
            MainWindow.courses.Remove(sub);

        }
        public Boolean findCourse(Course c)
        {
            foreach (Subject s in MainWindow.subjects)
            {
                if (s.course.label.Equals(c.label))
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean findSoftware(Software c)
        {
            foreach (Subject s in MainWindow.subjects)
            {
                foreach (Software software in s.software)
                {
                    if (software.label.Equals(c.label))
                    {
                        return true;
                    }
                }

            }
            foreach (Classroom s in MainWindow.classrooms)
            {
                foreach (Software software in s.software)
                {
                    if (software.label.Equals(c.label))
                    {
                        return true;
                    }
                }

            }

            return false;
        }
        public Boolean findClassroom(Classroom c)
        {
            return false;
        }
        public Boolean findSubject(Subject c)
        {
            return false;
        }

        public DeleteSubject()
        {
            this.subjects = MainWindow.subjects;
            this.classrooms = MainWindow.classrooms;

            this.softwares = MainWindow.softwares;
            this.courses = MainWindow.courses;

            Console.WriteLine(this.subjects.Count);
            this.DataContext = this;
            InitializeComponent();
        }
    }
}
