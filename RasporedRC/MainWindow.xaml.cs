﻿using RasporedRC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;

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
        public void Tables(object sender, RoutedEventArgs e)
        {

            var dialog = new Tables();
            dialog.ShowDialog();
        }

        public void RunDemo(object sender, RoutedEventArgs e)
        {
            if (demoTab.Visibility == Visibility.Visible)
            {
                return;
            }
            else
            {
                var demoContent = new DemoTab();
                demoTab.Content = demoContent;
                if (helpTab.Visibility == Visibility.Hidden && mainTabControl.Items.IndexOf(helpTab) == 1)
                {
                    mainTabControl.Items.RemoveAt(2);
                    mainTabControl.Items.Insert(1, demoTab);
                }
                demoTab.Visibility = Visibility.Visible;
                demoTab.Focus();
            }
            
        }

        public void CloseDemo(object sender, RoutedEventArgs e)
        {
            if (demoTab.Visibility == Visibility.Visible)
            {
                DemoTab dt = (DemoTab)demoTab.Content;
                dt.abortDemo();
                demoTab.Content = null;
                demoTab.Visibility = Visibility.Hidden;
                glavniTab.Focus();
                if (helpTab.Visibility == Visibility.Visible && mainTabControl.Items.IndexOf(helpTab) == 2)
                {
                    mainTabControl.Items.RemoveAt(1);
                    mainTabControl.Items.Insert(2, demoTab);
                    helpTab.Focus();
                }
            }
            else
            {
                return;
            }
        }

        public void ShowHelp(object sender, RoutedEventArgs e)
        {
            if (helpTab.Visibility == Visibility.Visible)
            {
                return;
            }
            else
            {
                var helpContent = new HelpTab("index", this);
                helpTab.Content = helpContent;
                if (demoTab.Visibility == Visibility.Hidden && mainTabControl.Items.IndexOf(demoTab) == 1)
                {
                    mainTabControl.Items.RemoveAt(2);
                    mainTabControl.Items.Insert(1, helpTab);
                }
                helpTab.Visibility = Visibility.Visible;
                helpTab.Focus();
            }
            
        }

        public void CloseHelp(object sender, RoutedEventArgs e)
        {
            if (helpTab.Visibility == Visibility.Visible)
            {
                helpTab.Content = null;
                helpTab.Visibility = Visibility.Hidden;
                glavniTab.Focus();
                if (demoTab.Visibility == Visibility.Visible && mainTabControl.Items.IndexOf(demoTab) == 2)
                {
                    mainTabControl.Items.RemoveAt(1);
                    mainTabControl.Items.Insert(2, helpTab);
                    demoTab.Focus();
                }
            }
            else
            {
                return;
            }
        }

        public ObservableCollection<Term> MainListPon
        {
            get;
            set;
        }
        public static ObservableCollection<Term> MainListUto
        {
            get;
            set;
        }
        public static ObservableCollection<Term> MainListSre
        {
            get;
            set;
        }
        public static ObservableCollection<Term> MainListCet
        {
            get;
            set;
        }
        public static ObservableCollection<Term> MainListPet
        {
            get;
            set;
        }
        public static ObservableCollection<Term> MainListSub
        {
            get;
            set;
        }

        public static ObservableCollection<Term> SideList
        {
            get;
            set;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            ShowHelp(sender, e);
        }

        public static String SelectedClassroom
        {
            get;
            set;
        }
        public static ObservableCollection<string> classrooms_display
        {
            get;
            set;
        }

        public static string current_classroom;
        private static List<Term> unassignedTerms = new List<Term>();
        private static Dictionary<string, List<ObservableCollection<Term>>> classroomsWeek;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;


            loadData();
            Closing += WindowClosed;
            //classroomsWeek = new Dictionary<string, List<ObservableCollection<Term>>>();
            InitStyles();

            foreach(Classroom cr in classrooms)
            {
                Console.WriteLine("ASD -> " + cr.listSoft.Count);
            }

            //SideList = new ObservableCollection<Term>(unassignedTerms);

            SideList = new ObservableCollection<Term>();

            classrooms_display = new ObservableCollection<string>();
            foreach (var cr in classroomsWeek)
            {
                classrooms_display.Add(cr.Key);
            }

            OS = new ObservableCollection<string>();

            OS.Add("Windows");
            OS.Add("Linux");
            OS.Add("Windows/Linux");

            /*
            classrooms.Add(new Model.Classroom("l1", "desc", 15, true, false, false, "Windows/Linux"));
            subjects.Add(new Subject("hci", "human computer interaction", "desc", new Course(), 14, 3, 3, false, false, false,"Windows")); //True
            subjects.Add(new Subject("hci1", "human computer interaction", "desc", new Course(), 14, 3, 3, true, false, false, "Linux")); //True
            subjects.Add(new Subject("hci2", "human computer interaction", "desc", new Course(), 14, 3, 3, false, true, false, "Windows")); //False

            Console.WriteLine("True -> " + checkTermClassroom(new Term("", "", "hci", ""), "l1"));
            Console.WriteLine("True -> " + checkTermClassroom(new Term("", "", "hci1", ""), "l1"));
            Console.WriteLine("False -> " + checkTermClassroom(new Term("", "", "hci2", ""), "l1"));

            classrooms[0].tableExists = true;
            classrooms[0].os = "Linux";

            subjects.Add(new Subject("hci3", "human computer interaction", "desc", new Course(), 14, 3, 3, false, false, false, "Windows")); //False
            subjects.Add(new Subject("hci4", "human computer interaction", "desc", new Course(), 14, 3, 3, false, false, true, "Linux")); //False
            subjects.Add(new Subject("hci5", "human computer interaction", "desc", new Course(), 14, 3, 3, false, true, false, "Linux")); //True

            Console.WriteLine("False -> " + checkTermClassroom(new Term("", "", "hci3", ""), "l1"));
            Console.WriteLine("False -> " + checkTermClassroom(new Term("", "", "hci4", ""), "l1"));
            Console.WriteLine("True -> " + checkTermClassroom(new Term("", "", "hci5", ""), "l1"));
            
            softwares = new ObservableCollection<Software>();
            classrooms = new ObservableCollection<Classroom>();
            subjects = new ObservableCollection<Subject>();
            courses = new ObservableCollection<Course>();

            Software s = new Software();
            s.name = "Ime";
            s.price = 1001;
            s.manofacturer = "Man";
            s.label = "Labeaaaaaaaaaaaaaaaaaaaaaaaaal";
            s.os = "Windows/Linux";
            s.description = "Opis";
            s.yearOfPublishing = "2000";
            softwares.Add(s);
            Software s1 = new Software();
            s1.name = "Imeaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            s1.price = 1000000000000;
            s1.manofacturer = "Man";
            s1.label = "Labsadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaedasl";
            s1.os = "Windows";
            s1.description = "Opis";

            s1.website = "Opis";
            s1.yearOfPublishing = "1999";
            softwares.Add(s1);

            Classroom c = new Classroom("ucionica1", "opisdadsadsadasdasdsadsadsopissssssssssssssssssssssssssssssssssssadasdsadsadasdasdasdasdadsadsdsadasds1", 12,true,true,true,"Windows");
            c.software.Add(s1);
            c.software.Add(s);


            Classroom c1 = new Classroom("ucionicadsa1", "opis", 12, true, true, true, "Windows/Linux");
            c1.software.Add(s1);
            c1.software.Add(s);

            classrooms.Add(c1);

            classrooms.Add(c);


            Course cc = new Course();
            cc.label = "smer1";
            cc.name = "sw";
            courses.Add(cc);

            Course cc1 = new Course();
            cc1.label = "smer2";
            cc.name = "sw1";
            cc1.description = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            courses.Add(cc1);

            Subject sub = new Subject();
            sub.course = cc1;

            sub.os = "Windows/Linux";
            sub.description = "opis";
            sub.label = "aaaa";
            sub.name = "WAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAT";

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
            */

            InitializeComponent();
    }

        private void InitStyles()
        {
            var styleSchedule = new Style(typeof(ListBoxItem));
            styleSchedule.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            styleSchedule.Setters.Add(new Setter(ListBoxItem.FocusableProperty, false));

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
            styleSide.Setters.Add(new Setter(ListBoxItem.FocusableProperty, false));

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

        public static void checkClassrooms()
        {
            List<int> remove_elements = new List<int>();
            foreach(var week in classroomsWeek)
            {
                foreach(var dayModel in week.Value)
                {
                    remove_elements.Clear();
                    foreach(Term t in dayModel)
                    {
                        if(t.SubjectId != "")
                        {
                            if (!checkTermClassroom(t, week.Key))
                            {
                                int index = dayModel.IndexOf(t);
                                remove_elements.Add(index);
                                unassignedTerms.Add(t);
                            }
                        }
                    }
                    for(int i = remove_elements.Count-1;i>-1;i--)
                    {
                        dayModel.RemoveAt(remove_elements[i]);
                        dayModel.Insert(remove_elements[i], new Term("", "", "", "",0));
                        dayModel.Insert(remove_elements[i], new Term("", "", "", "", 0));
                        dayModel.Insert(remove_elements[i], new Term("", "", "", "", 0));
                    }
                }
            }
            fillSideList(current_classroom);
        }

        public static void updateTermBySubject(string old_id,Subject sub)
        {
            int old_noc = countTermsOfSubject(old_id);
            if(old_noc != sub.numberOfAppointment * sub.numberOfClasses)
            {
                removeTermBySubject(old_id);
                addTermsFromSubject(sub);
                return;
            }
            foreach (var week in classroomsWeek)
            {
                foreach (var dayModel in week.Value)
                {
                    foreach (Term t in dayModel)
                    {
                        if (t.SubjectId == old_id)
                        {
                            t.SubjectId = sub.label;
                            t.SubjectName = sub.name;
                            t.NumberOfClasses = sub.numberOfClasses;
                            t.update();
                        }
                    }
                }
            }
            foreach (Term t in unassignedTerms)
            {
                if (t.SubjectId == old_id)
                {
                    t.SubjectId = sub.label;
                    t.SubjectName = sub.name;
                    t.NumberOfClasses = sub.numberOfClasses;
                    t.update();
                }
            }
        }

        public static int countTermsOfSubject(string sub_id)
        {
            int counter = 0;
            foreach (var week in classroomsWeek)
            {
                foreach (var dayModel in week.Value)
                {
                    foreach (Term t in dayModel)
                    {
                        if (t.SubjectId == sub_id)
                        {
                            counter++;
                        }
                    }
                }
            }
            foreach (Term t in unassignedTerms)
            {
                if (t.SubjectId == sub_id)
                {
                    counter++;
                }
            }
            return counter;
        }

        public static void updateTermByCourse(string old_id, Course cour)
        {
            foreach (var week in classroomsWeek)
            {
                foreach (var dayModel in week.Value)
                {
                    foreach (Term t in dayModel)
                    {
                        if (t.CourseId == old_id)
                        {
                            t.CourseId = cour.label;
                            t.CourseName = cour.name;
                            t.update();
                        }
                    }
                }
            }
            foreach (Term t in unassignedTerms)
            {
                if (t.CourseId == old_id)
                {
                    t.CourseId = cour.label;
                    t.CourseName = cour.name;
                    t.update();
                }
            }
        }

        public static void removeTermBySubject(string sub_id)
        {
            List<int> remove_elements = new List<int>();
            foreach (var week in classroomsWeek)
            {
                foreach (var dayModel in week.Value)
                {
                    remove_elements.Clear();
                    foreach (Term t in dayModel)
                    {
                        if (t.SubjectId == sub_id)
                        {
                            int index = dayModel.IndexOf(t);
                            remove_elements.Add(index);
                        }
                    }
                    for (int i = remove_elements.Count - 1; i > -1; i--)
                    {
                        dayModel.RemoveAt(remove_elements[i]);
                        dayModel.Insert(remove_elements[i], new Term("", "", "", "", 0));
                        dayModel.Insert(remove_elements[i], new Term("", "", "", "", 0));
                        dayModel.Insert(remove_elements[i], new Term("", "", "", "", 0));
                    }
                }
            }
            for (int i = SideList.Count - 1; i > -1; i--)
            {
                if (SideList[i].SubjectId == sub_id)
                {
                    SideList.RemoveAt(i);
                }
            }
        }

        public static void addTermsFromSubject(Subject s)
        {
            for (int i = 0; i < s.numberOfAppointment * s.numberOfClasses; i++)
            {
                unassignedTerms.Add(new Term(s.c.label, s.c.name, s.label, s.name,s.numberOfClasses));
            }
            if (current_classroom == null)
            {
                return;
            }
            fillSideList(current_classroom);
        }

        private void displayClassroom(string id)
        {
            if (id == null)
            {
                MainListPon = new ObservableCollection<Term>();
                MainListUto = new ObservableCollection<Term>();
                MainListSre = new ObservableCollection<Term>();
                MainListCet = new ObservableCollection<Term>();
                MainListPet = new ObservableCollection<Term>();
                MainListSub = new ObservableCollection<Term>();
            }
            else
            {
                MainListPon = classroomsWeek[id][0];
                MainListUto = classroomsWeek[id][1];
                MainListSre = classroomsWeek[id][2];
                MainListCet = classroomsWeek[id][3];
                MainListPet = classroomsWeek[id][4];
                MainListSub = classroomsWeek[id][5];
            }

            LbSchedulePon.ItemsSource = MainListPon;
            LbScheduleUto.ItemsSource = MainListUto;
            LbScheduleSre.ItemsSource = MainListSre;
            LbScheduleCet.ItemsSource = MainListCet;
            LbSchedulePet.ItemsSource = MainListPet;
            LbScheduleSub.ItemsSource = MainListSub;

            current_classroom = id;
            fillSideList(id);
        }

        public static void fillSideList(string classroomId)
        {
            SideList.Clear();
            if (classroomId == null)
            {
                return;
            }
            foreach (var term in unassignedTerms)
            {
                if (checkTermClassroom(term, classroomId))
                {
                    SideList.Add(term);
                }
            }
        }

        private static bool checkTermClassroom(Term term,string classroomId)
        {
            Subject sub = null;
            Classroom croom = null;
            foreach(Subject s in subjects)
            {
                if(s.label == term.SubjectId)
                {
                    sub = s;
                    break;
                }
            }
            foreach (Classroom cr in classrooms)
            {
                if (cr.label == classroomId)
                {
                    croom = cr;
                    break;
                }
            }

            if(sub == null || croom == null)
            {
                return false;
            }

            if (sub.os != "Windows/Linux" && croom.os != "Windows/Linux")
            {
                if(sub.os != croom.os)
                    return false;
            }
            if (sub.projector == true && croom.projector == false)
            {
                return false;
            }
            if (sub.tableExists == true && croom.tableExists == false)
            {
                return false;
            }
            if (sub.smartTable == true && croom.smartTable == false)
            {
                return false;
            }
            if (sub.groupSize > croom.slots)
            {
                return false;
            }

            bool contains;
            foreach (Software soft in sub.software)
            {
                contains = false;
                foreach (Software cr_soft in croom.listSoft)
                {
                    if (soft.label == cr_soft.label)
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    return false;
                }
            }

            return true;
        }

        public static void addClassroom(string id)
        {
            classroomsWeek.Add(id,new List<ObservableCollection<Term>>());
            for(int i = 0; i < 6; i++)
            {
                classroomsWeek[id].Add(new ObservableCollection<Term>());

                for(int j = 0; j < 64; j++)
                {
                    classroomsWeek[id][i].Add(new Term("", "", "", "", 0));
                }
            }
            classrooms_display.Add(id);
        }

        public static void removeClassroom(string id)
        {
            classroomsWeek.Remove(id);
            classrooms_display.Remove(id);

            if (current_classroom == id)
            {
                current_classroom = null;
                fillSideList(current_classroom);
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

                Term source = e.Data.GetData(typeof(Term)) as Term;
                Term target = ((ListBoxItem)sender).DataContext as Term;
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

                    if ((targetIndex = getStartIndex(target_parent, targetIndex)) != -1)
                    {
                        target_parent.RemoveAt(targetIndex);
                        target_parent.RemoveAt(targetIndex);
                        target_parent.RemoveAt(targetIndex);
                        target_parent.Insert(targetIndex, source);
                        unassignedTerms.RemoveAt(unassignedTerms.IndexOf(source));
                        SideList.RemoveAt(sourceIndex);
                    }
                    else
                    {
                        MessageBox.Show("Moguće je premeštanje samo na 3 spojena polja od 15 minuta!", "Greška", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    if(source.SubjectId == "")
                    {
                        MessageBox.Show("Premeštanje pauza između dana nije moguce!", "Greška", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if ( (targetIndex = getStartIndex(target_parent,targetIndex)) != -1)
                        {
                            target_parent.RemoveAt(targetIndex);
                            target_parent.RemoveAt(targetIndex);
                            target_parent.RemoveAt(targetIndex);
                            target_parent.Insert(targetIndex, source);
                            source_parent.RemoveAt(sourceIndex);
                            source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                            source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                            source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                        }

                    }
                }
            }
        }

        private int getStartIndex(ObservableCollection<Term> list,int targetIndex)
        {
            try
            {
                if(list[targetIndex].SubjectId == "" && list[targetIndex + 1].SubjectId == "" && list[targetIndex+2].SubjectId == "")
                {
                    return targetIndex;
                }
            }
            catch
            {
                Console.WriteLine("Wrong index vol.1");
            }
            try
            {
                if (list[targetIndex].SubjectId == "" && list[targetIndex + 1].SubjectId == "" && list[targetIndex - 1].SubjectId == "")
                {
                    return targetIndex - 1;
                }
            }
            catch
            {
                Console.WriteLine("Wrong index vol.2");
            }
            try
            {
                if (list[targetIndex].SubjectId == "" && list[targetIndex - 2].SubjectId == "" && list[targetIndex - 1].SubjectId == "")
                {
                    return targetIndex - 2;
                }
            }
            catch
            {
                Console.WriteLine("Wrong index vol.3");
            }
            return -1;
        }

        private static ObservableCollection<Term> getParentOC(Term to)
        {
            foreach(var week in classroomsWeek)
            {
                foreach(var dayModel in week.Value)
                {
                    if (dayModel.Contains(to))
                    {
                        return dayModel;
                    }
                }
            }
            return SideList;
        }

        private void SideWindowElem_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                Term source = e.Data.GetData(typeof(Term)) as Term;
                Term target = ((ListBoxItem)sender).DataContext as Term;

                var source_parent = getParentOC(source);
                var target_parent = getParentOC(target);

                int sourceIndex = SideList.IndexOf(source);
                int targetIndex = SideList.IndexOf(target);

                if (source_parent.Equals(target_parent))
                {
                    SideList.RemoveAt(sourceIndex);
                    SideList.Insert(targetIndex, source);
                }
                else
                {
                    sourceIndex = source_parent.IndexOf(source);
                    source_parent.RemoveAt(sourceIndex);
                    source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                    source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                    source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                    SideList.Insert(targetIndex, source);
                    unassignedTerms.Add(source);
                }
            }
        }

        private void SideWindow_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBox)
            {
                Term source = e.Data.GetData(typeof(Term)) as Term;

                if (source.SubjectId == "")
                {
                    e.Handled = true;
                    return;
                }
                var source_parent = getParentOC(source);

                if (source_parent.Equals(SideList))
                {
                    e.Handled = true;
                    return;
                }

                int sourceIndex = source_parent.IndexOf(source);

                source_parent.RemoveAt(sourceIndex);
                source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                source_parent.Insert(sourceIndex, new Term("", "", "", "", 0));
                SideList.Add(source);
                unassignedTerms.Add(source);
            }
        }

        private void Expand_Window(object sender, MouseEventArgs e)
        {
            LbSide.Width = 194;
        }

        private void Shrink_Window(object sender, MouseEventArgs e)
        {
            LbSide.Width = 8;
        }

        private void LbSide_DragEnter(object sender, DragEventArgs e)
        {
            LbSide.Width = 194;
        }

        private void LbSide_DragLeave(object sender, DragEventArgs e)
        {
            LbSide.Width = 8;
        }

        private void loadData()
        {
            string path = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
            var serializer = new XmlSerializer(typeof(DataWrapper));
            var dataWrapper = new DataWrapper();
            try
            {
                using (var reader = XmlReader.Create(path + "\\dataSet.xml"))
                {
                    dataWrapper = (DataWrapper)serializer.Deserialize(reader);
                }


                subjects = dataWrapper.Subs;
                courses = dataWrapper.Cours;
                classrooms = dataWrapper.Classrms;
                softwares = dataWrapper.Softs;
                unassignedTerms = dataWrapper.Unassigned;

                classroomsWeek = dataWrapper.generateScheduleDict();

                foreach(var cr in classroomsWeek)
                {
                    foreach(var day in cr.Value)
                    {
                        foreach(var term in day)
                        {
                            term.updateColor();
                        }
                    }
                }

                bool soft_in_cr = false;
                bool soft_in_sub = false;
                List<Software> new_list = new List<Software>();
                foreach(var cr in classrooms)
                {
                    foreach (var soft in softwares)
                    {
                        foreach(var soft2 in cr.listSoft)
                        {
                            if(soft.label == soft2.label)
                            {
                                new_list.Add(soft);
                                break;
                            }
                        }

                    }
                    cr.listSoft = new_list;
                    new_list = new List<Software>();
                }

                foreach (var cr in subjects)
                {
                    foreach (var soft in softwares)
                    {
                        foreach (var soft2 in cr.software)
                        {
                            if (soft.label == soft2.label)
                            {
                                new_list.Add(soft);
                                break;
                            }
                        }

                    }
                    cr.software = new_list;
                    new_list = new List<Software>();
                }
            }
            catch
            {
                subjects = new ObservableCollection<Subject>();
                courses = new ObservableCollection<Course>();
                classrooms = new ObservableCollection<Classroom>();
                softwares = new ObservableCollection<Software>();
                unassignedTerms = new List<Term>();

                classroomsWeek = new Dictionary<string, List<ObservableCollection<Term>>>();
                return;
            }
        }
        public void WindowClosed(object sender, CancelEventArgs e)
        {
            string path = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
            var serializer = new XmlSerializer(typeof(DataWrapper));
            var dataWrapper = new DataWrapper();

            dataWrapper.Subs = subjects;

            dataWrapper.Cours = courses;
            dataWrapper.Classrms = classrooms;
            dataWrapper.Softs = softwares;
            dataWrapper.Unassigned = unassignedTerms;

            dataWrapper.loadDictionary(classroomsWeek);


            StreamWriter sw = new StreamWriter(path + "\\dataSet.xml");
            sw.Close();

            using (var writer = XmlWriter.Create(path + "\\dataSet.xml"))
            {
                serializer.Serialize(writer, dataWrapper);
            }
        }

        public void clearScreen(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ovim gubite sve podatke, da li želite da nastavite?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                courses = new ObservableCollection<Course>();
                subjects = new ObservableCollection<Subject>();
                classrooms = new ObservableCollection<Classroom>();
                softwares = new ObservableCollection<Software>();

                current_classroom = null;

                SideList = new ObservableCollection<Term>();
                LbSide.ItemsSource = SideList;
                unassignedTerms = new List<Term>();
                classroomsWeek = new Dictionary<string, List<ObservableCollection<Term>>>();
                classrooms_display.Clear();
                fillSideList(current_classroom);
                displayClassroom(current_classroom);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayClassroom(SelectedClassroom);
        }

        private void Window_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DemoTab dt = null;
            if (demoTab.Content != null)
            {
                dt = (DemoTab)demoTab.Content;
                dt.abortDemo();
            }
            
        }

    }

}
