﻿using RasporedRC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point startPoint;
        public static ObservableCollection<Classroom> classrooms;
        public static ObservableCollection<Course> courses;
        public static ObservableCollection<Subject> subjects;
        public static ObservableCollection<Software> softwares;

        public static ObservableCollection<string> OS;
        public static Classroom classroomToUpdate;

        public static Subject subjectToUpdate;
        public static Course courseToUpdate;
        public static Software softwareToUpdate;

        public void AddClassroom(object sender, RoutedEventArgs e)
        {

            var dialog = new AddClassroom();
            dialog.ShowDialog();
        }
        public void AddCourse(object sender, RoutedEventArgs e)
        {

            var dialog = new AddCourse();
            dialog.ShowDialog();
        }
        public void AddSoftware(object sender, RoutedEventArgs e)
        {

            var dialog = new AddSoftware();
            dialog.ShowDialog();
        }
        public void AddSubject(object sender, RoutedEventArgs e)
        {

            var dialog = new AddSubject();
            dialog.ShowDialog();
        }
        public void DeleteSubject(object sender, RoutedEventArgs e)
        {

            var dialog = new DeleteSubject();
            dialog.ShowDialog();
        }


        public ObservableCollection<TestOutput> MainListPon
        {
            get;
            set;
        }
        public ObservableCollection<TestOutput> MainListUto
        {
            get;
            set;
        }
        public ObservableCollection<TestOutput> MainListSre
        {
            get;
            set;
        }
        public ObservableCollection<TestOutput> MainListCet
        {
            get;
            set;
        }
        public ObservableCollection<TestOutput> MainListPet
        {
            get;
            set;
        }
        public ObservableCollection<TestOutput> MainListSub
        {
            get;
            set;
        }

        public ObservableCollection<TestOutput> SideList
        {
            get;
            set;
        }

        List<ObservableCollection<TestOutput>> currentClassroom;
        Dictionary<string, List<ObservableCollection<TestOutput>>> classroomsWeek;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            InitStyles();

            classroomsWeek = new Dictionary<string, List<ObservableCollection<TestOutput>>>();

            addClassroom("myclass");
            displayClassroom("myclass");


            List<TestOutput> list = new List<TestOutput>();
            list.Add(new TestOutput("Predmet1",32));
            list.Add(new TestOutput("Predmet2", 32));
            list.Add(new TestOutput("Predmet3", 32));
            list.Add(new TestOutput("Predmet4", 32));
            list.Add(new TestOutput("Predmet5", 32));
            list.Add(new TestOutput("Predmet6", 32));

            SideList = new ObservableCollection<TestOutput>(list);


        
            softwares = new ObservableCollection<Software>();
            classrooms = new ObservableCollection<Classroom>();
            subjects = new ObservableCollection<Subject>();
            courses = new ObservableCollection<Course>();
            OS = new ObservableCollection<string>();

            OS.Add("Windows");
            OS.Add("Linux");
            OS.Add("Windows/Linux");


            Software s = new Software();
            s.name = "Ime";
            s.price = 100;
            s.manofacturer = "Man";
            s.label = "Label";
            s.os = "Windows";
            s.description = "Opis";
            softwares.Add(s);
            Software s1 = new Software();
            s1.name = "Imeaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            s1.price = 100;
            s1.manofacturer = "Man";
            s1.label = "Labedasl";
            s1.os = "Windows";
            s1.description = "Opis";

            s1.website = "Opis";
            s1.yearOfPublishing = "1999";
            softwares.Add(s1);

            Classroom c = new Classroom("ucionica1", "opis1", 12,true,true,true,"Windows");
            c.label = "ucionica1";
            c.software.Add(s1);
            c.software.Add(s);
            classrooms.Add(c);


            Course cc = new Course();
            cc.label = "smer1";
            cc.name = "sw";
            courses.Add(cc);

            Course cc1 = new Course();
            cc1.label = "smer2";
            cc.name = "sw1";
            courses.Add(cc1);

            Subject sub = new Subject();
            sub.course = cc1;

            sub.os = "Windows";
            sub.description = "opis";
            sub.label = "aaaa";

            Subject sub1 = new Subject();
            sub1.course = cc1;
            sub1.description = "l";
            sub1.label = "labela";
            sub1.os = "Windows";
            sub1.software.Add(s1);
            sub1.software.Add(s);

            sub1.software.Add(s1);
            sub1.software.Add(s);

            sub1.software.Add(s1);
            sub1.software.Add(s);

            sub1.software.Add(s1);
            sub1.software.Add(s);
            subjects.Add(sub);
            subjects.Add(sub1);
            InitializeComponent();
        

    }

        private void InitStyles()
        {
            var styleSchedule = new Style(typeof(ListBoxItem));
            styleSchedule.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));

            styleSchedule.Setters.Add(
                new EventSetter(
                    ListBoxItem.PreviewMouseLeftButtonDownEvent,
                    new MouseButtonEventHandler(MainWindow_PreviewMouseLeftButtonDown)));

            styleSchedule.Setters.Add(
                new EventSetter(
                    ListBoxItem.DropEvent,
                    new DragEventHandler(MainWindow_Drop)));


            Style styleSide = new Style(typeof(ListBoxItem));
            styleSide.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));

            styleSide.Setters.Add(
                new EventSetter(
                    ListBoxItem.PreviewMouseLeftButtonDownEvent,
                    new MouseButtonEventHandler(MainWindow_PreviewMouseLeftButtonDown)));

            styleSide.Setters.Add(
                new EventSetter(
                    ListBoxItem.DropEvent,
                    new DragEventHandler(SideWindowElem_Drop)));

            LbSide.ItemContainerStyle = styleSide;
            LbSchedulePon.ItemContainerStyle = styleSchedule;
            LbScheduleUto.ItemContainerStyle = styleSchedule;
            LbScheduleSre.ItemContainerStyle = styleSchedule;
            LbScheduleCet.ItemContainerStyle = styleSchedule;
            LbSchedulePet.ItemContainerStyle = styleSchedule;
            LbScheduleSub.ItemContainerStyle = styleSchedule;
        }

        private void displayClassroom(string id)
        {
            MainListPon = classroomsWeek[id][0];
            MainListUto = classroomsWeek[id][1];
            MainListSre = classroomsWeek[id][2];
            MainListCet = classroomsWeek[id][3];
            MainListPet = classroomsWeek[id][4];
            MainListSub = classroomsWeek[id][5];
        }

        private void addClassroom(string id)
        {
            classroomsWeek.Add(id,new List<ObservableCollection<TestOutput>>());
            for(int i = 0; i < 6; i++)
            {
                classroomsWeek[id].Add(new ObservableCollection<TestOutput>());

                for(int j = 0; j < 64; j++)
                {
                    classroomsWeek[id][i].Add(new TestOutput("", 10));
                }
            }
        }

        private void MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListBox listView = sender as ListBox;
                ListBoxItem listViewItem =
                    FindAncestor<ListBoxItem>((DependencyObject)e.OriginalSource);

                if(listViewItem == null)
                {
                    return;
                }

                DragDrop.DoDragDrop(listViewItem, listViewItem.DataContext, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MainWindow_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {

                TestOutput source = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;
                var target_parent = getParentOC(target);
                var source_parent = getParentOC(source);

                int sourceIndex = source_parent.IndexOf(source);
                int targetIndex = target_parent.IndexOf(target);

                if (source_parent.Equals(target_parent))
                {
                    source_parent.RemoveAt(sourceIndex);
                    source_parent.Insert(targetIndex, source);
                } else if( source_parent.Equals(SideList))
                {
                    sourceIndex = SideList.IndexOf(source);

                    if (target_parent[targetIndex].Text == "" && target_parent[targetIndex + 1].Text == "" && target_parent[targetIndex+1].Text == "")
                    {
                        target_parent.RemoveAt(targetIndex);
                        target_parent.RemoveAt(targetIndex);
                        target_parent.RemoveAt(targetIndex);
                        target_parent.Insert(targetIndex, source);
                        SideList.RemoveAt(sourceIndex);
                    }
                }
                else
                {
                    if(source.Text == "")
                    {
                        Console.WriteLine("Only Subjcest are allowed to be draged inbetween days");
                    }else
                    {
                        if (target_parent[targetIndex].Text == "" && target_parent[targetIndex + 1].Text == "" && target_parent[targetIndex + 1].Text == "")
                        {
                            target_parent.RemoveAt(targetIndex);
                            target_parent.RemoveAt(targetIndex);
                            target_parent.RemoveAt(targetIndex);
                            target_parent.Insert(targetIndex, source);
                            source_parent.RemoveAt(sourceIndex);
                            source_parent.Insert(sourceIndex, new TestOutput("", 10));
                            source_parent.Insert(sourceIndex, new TestOutput("", 10));
                            source_parent.Insert(sourceIndex, new TestOutput("", 10));
                        }

                    }
                }
            }
        }

        private ObservableCollection<TestOutput> getParentOC(TestOutput to)
        {
            if (MainListPon.Contains(to))
            {
                return MainListPon;
            }else if (MainListUto.Contains(to))
            {
                return MainListUto;
            }else if (MainListSre.Contains(to))
            {
                return MainListSre;
            }
            else if (MainListCet.Contains(to))
            {
                return MainListCet;
            }
            else if (MainListPet.Contains(to))
            {
                return MainListPet;
            }
            else if(MainListSub.Contains(to))
            {
                return MainListSub;
            }else
            {
                return SideList;
            }
        }

        private void SideWindowElem_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                TestOutput source = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;

                var source_parent = getParentOC(source);
                var target_parent = getParentOC(target);

                int sourceIndex = SideList.IndexOf(source);
                int targetIndex = SideList.IndexOf(target);

                if(source_parent.Equals(target_parent))
                {
                    SideList.RemoveAt(sourceIndex);
                    SideList.Insert(targetIndex, source);
                }else
                {
                    sourceIndex = source_parent.IndexOf(source);
                    source_parent.RemoveAt(sourceIndex);
                    source_parent.Insert(sourceIndex, new Model.TestOutput("", 10));
                    source_parent.Insert(sourceIndex, new Model.TestOutput("", 10));
                    source_parent.Insert(sourceIndex, new Model.TestOutput("", 10));
                    SideList.Insert(targetIndex, source);
                }
            }
        }

        private void SideWindow_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                TestOutput student = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;

                int sourceIndex = currentClassroom[0].IndexOf(student);
                int targetIndex = currentClassroom[0].IndexOf(target);

            }
        }

        private void Expand_Window(object sender, MouseEventArgs e)
        {
            LbSide.Width = 130;
        }

        private void Shrink_Window(object sender, MouseEventArgs e)
        {
            LbSide.Width = 5;
        }

        private void LbSide_DragEnter(object sender, DragEventArgs e)
        {
            LbSide.Width = 130;
        }

        private void LbSide_DragLeave(object sender, DragEventArgs e)
        {
            LbSide.Width = 5;
        }

    }

}
