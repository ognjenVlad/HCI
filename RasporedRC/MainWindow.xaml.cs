using RasporedRC.Model;
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
        public static List<Classroom> classrooms;
        public static List<Course> courses;
        public static List<Subject> subjects;
        public static List<Software> softwares;
        private ListBoxItem draggedItem;

        public void AddClassroom(object sender, RoutedEventArgs e)
        {

            var dialog = new AddClassroom();
            dialog.Show();
        }
        public void AddCourse(object sender, RoutedEventArgs e)
        {

            var dialog = new AddCourse();
            dialog.Show();
        }
        public void AddSoftware(object sender, RoutedEventArgs e)
        {

            var dialog = new AddSoftware();
            dialog.Show();
        }
        public void AddSubject(object sender, RoutedEventArgs e)
        {

            var dialog = new AddSubject();
            dialog.Show();
        }


        public ObservableCollection<Term> MainListPon
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListUto
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListSre
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListCet
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListPet
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListSub
        {
            get;
            set;
        }

        public ObservableCollection<Term> SideList
        {
            get;
            set;
        }

        private List<ObservableCollection<Term>> weekDisplay = new List<ObservableCollection<Term>>();
        Dictionary<string, List<ObservableCollection<Term>>> classroomsWeek;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            InitStyles();

            classroomsWeek = new Dictionary<string, List<ObservableCollection<Term>>>();

            weekDisplay.Add(new ObservableCollection<Term>());
            weekDisplay.Add(new ObservableCollection<Term>());
            weekDisplay.Add(new ObservableCollection<Term>());
            weekDisplay.Add(new ObservableCollection<Term>());
            weekDisplay.Add(new ObservableCollection<Term>());
            weekDisplay.Add(new ObservableCollection<Term>());

            addClassroom("myclass");
            displayClassroom("myclass");



            List<Term> list = new List<Term>();
            list.Add(new Term("Ovo je jedan jako dobar predmet", 1, "SW"));
            list.Add(new Term("Predmet2", 2, "SW"));
            list.Add(new Term("Predmet3", 3, "SW"));
            list.Add(new Term("Predmet4", 4, "SW"));
            list.Add(new Term("Predmet5", 5, "SW"));
            list.Add(new Term("Predmet6", 6, "SW"));

            SideList = new ObservableCollection<Term>(list);



            softwares = new List<Software>();
            classrooms = new List<Classroom>();
            subjects = new List<Subject>();
            courses = new List<Course>();

            Software s = new Software();
            s.name = "Ime";
            s.price = 100;
            s.manofacturer = "Man";
            s.label = "Label";
            s.os = "Windows";
            s.description = "Opis";
            softwares.Add(s);
            Software s1 = new Software();
            s.name = "Imeaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            s.price = 100;
            s.manofacturer = "Man";
            s1.label = "Labedasl";
            s.os = "Windows";
            s.description = "Opis";
            softwares.Add(s1);

            Classroom c = new Classroom();
            c.label = "ucionica1";
            classrooms.Add(c);


            Course cc = new Course();
            cc.label = "smer1";
            courses.Add(cc);

            Course cc1 = new Course();
            cc1.label = "smer2";
            courses.Add(cc1);
            InitializeComponent();


        }
        public void DodajUcionicu(Object sender,RoutedEventArgs e)
        {
            addClassroom("UCIONICA2");
            displayClassroom("UCIONICA2");
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
                    ListBoxItem.PreviewMouseLeftButtonUpEvent,
                    new MouseButtonEventHandler(MainWindow_PreviewMouseLeftButtonUp)));

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
                    ListBoxItem.PreviewMouseLeftButtonUpEvent,
                    new MouseButtonEventHandler(MainWindow_PreviewMouseLeftButtonUp)));

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

            LbSchedulePon.ItemsSource = MainListPon;
            LbScheduleUto.ItemsSource = MainListUto;
            LbScheduleSre.ItemsSource = MainListSre;
            LbScheduleCet.ItemsSource = MainListCet;
            LbSchedulePet.ItemsSource = MainListPet;
            LbScheduleSub.ItemsSource = MainListSub;

            weekDisplay[0] = classroomsWeek[id][0];
            weekDisplay[1] = classroomsWeek[id][1];
            weekDisplay[2] = classroomsWeek[id][2];
            weekDisplay[3] = classroomsWeek[id][3];
            weekDisplay[4] = classroomsWeek[id][4];
            weekDisplay[5] = classroomsWeek[id][5];
        }

        private void addClassroom(string id)
        {
            classroomsWeek.Add(id,new List<ObservableCollection<Term>>());
            for(int i = 0; i < 6; i++)
            {
                classroomsWeek[id].Add(new ObservableCollection<Term>());

                for(int j = 0; j < 64; j++)
                {
                    classroomsWeek[id][i].Add(new Term("",0,""));
                }
            }
        }

        private void MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            ListBoxItem listBoxItem =
                FindAncestor<ListBoxItem>((DependencyObject)e.OriginalSource);
            colorGoodDrop(listBoxItem);
            draggedItem = listBoxItem;
        }

        private void MainWindow_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            resetColors();
        }

        private void ResetColor_MouseMove(object sender, MouseEventArgs e)
        {
            resetColors();
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
            if(draggedItem is ListBoxItem)
                colorGoodDrop(draggedItem);
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MainWindow_DragLeave(object sender, DragEventArgs e)
        {
            resetColors();
        }

        private void MainWindow_Drop(object sender, DragEventArgs e)
        {
            resetColors();
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

                    if (target_parent[targetIndex].SubjectId == "" && target_parent[targetIndex + 1].SubjectId == "" && target_parent[targetIndex+1].SubjectId == "")
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
                    if(source.SubjectId == "")
                    {
                        Console.WriteLine("Only Subjcest are allowed to be draged inbetween days");
                    }else
                    {
                        if (target_parent[targetIndex].SubjectId == "" && target_parent[targetIndex + 1].SubjectId == "" && target_parent[targetIndex + 1].SubjectId == "")
                        {
                            target_parent.RemoveAt(targetIndex);
                            target_parent.RemoveAt(targetIndex);
                            target_parent.RemoveAt(targetIndex);
                            target_parent.Insert(targetIndex, source);
                            source_parent.RemoveAt(sourceIndex);
                            source_parent.Insert(sourceIndex, new Term("", 0, ""));
                            source_parent.Insert(sourceIndex, new Term("", 0, ""));
                            source_parent.Insert(sourceIndex, new Term("", 0, ""));
                        }
                    }
                }
            }
        }

        private ObservableCollection<Term> getParentOC(Term to)
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
            resetColors();
            if (sender is ListBoxItem)
            {
                Term source = e.Data.GetData(typeof(Term)) as Term;
                Term target = ((ListBoxItem)sender).DataContext as Term;

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
                    source_parent.Insert(sourceIndex, new Term("", 0, ""));
                    source_parent.Insert(sourceIndex, new Term("", 0, ""));
                    source_parent.Insert(sourceIndex, new Term("", 0, ""));
                    SideList.Insert(targetIndex, source);
                }
            }
        }

        private void SideWindow_Drop(object sender, DragEventArgs e)
        {
            resetColors();
            if (sender is ListBox)
            {
                Term source = e.Data.GetData(typeof(Term)) as Term;

                if(source.SubjectId == "")
                {
                    e.Handled = true;
                    resetColors();
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
                source_parent.Insert(sourceIndex, new Term("", 0, ""));
                source_parent.Insert(sourceIndex, new Term("", 0, ""));
                source_parent.Insert(sourceIndex, new Term("", 0, ""));
                SideList.Add(source);
            }
        }

        private void resetColors()
        {
            foreach(var dayModel in weekDisplay)
            {
                foreach (Term to in dayModel)
                {
                    if (to.SubjectId.Equals(""))
                    {
                        to.BgColor = new SolidColorBrush(Colors.LightGray);
                    }
                    else
                    {
                        to.BgColor = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private List<List<bool>> createAllowsPerDays(string courseId)
        {
            List<List<bool>> allowedPerDay = new List<List<bool>>();

            for (int k = 0; k < 6; k++)
            {
                allowedPerDay.Add(new List<bool>());
                for (int h = 0; h < 64; h++)
                {
                    allowedPerDay[k].Add(true);
                }
            }

            int i, j;
            bool term_matching;

            foreach (var classroom in classroomsWeek)
            {
                foreach (var dayModel in classroom.Value)
                {
                    i = 0;
                    foreach (var term in dayModel)
                    {
                        term_matching = term.CourseId == courseId;
                        j = term.DisplayText.Equals("") ? 1 : 3;
                        if (term_matching)
                        {
                            for (int k = 0; k < j; k++)
                                allowedPerDay[classroom.Value.IndexOf(dayModel)][i + k] = false;
                        }
                        i += j;
                    }
                }
            }
            return allowedPerDay;
        }

        private void colorGoodDrop(ListBoxItem lvi)
        {
            var lvi_content = lvi.DataContext as Term;

            if (lvi_content.CourseId.Equals(""))
                return;

            List<List<bool>> allowedPerDay = createAllowsPerDays(lvi_content.CourseId);

            int k;

            for(int i = 0; i < 6; i++)
            {
                k = 0;
                for(int j = 0; j < weekDisplay[i].Count; j++)
                {
                    if (weekDisplay[i][j].DisplayText.Equals(""))
                    {
                        if (!allowedPerDay[i][k])
                        {
                            weekDisplay[i][j].BgColor = new SolidColorBrush(Colors.Red);
                        }
                        k += 1;
                    }
                    else
                    {
                        if (!allowedPerDay[i][k] || !allowedPerDay[i][k+1] || !allowedPerDay[i][k+2])
                        {
                            Console.WriteLine("BEEN HERE -> " + k);
                            weekDisplay[i][j].BgColor = new SolidColorBrush(Colors.Red);
                        }
                        k += 3;
                    }
                }
            }
        }

        private void colorTerms()
        {
            // uradi petlju za smer sve smerove po danima vektor od 64 elem

            foreach(var dayModel in weekDisplay)
            {
                foreach(Term to in dayModel)
                {
                    // to.IsAllowed( USLOV IZ PROVERE );
                    continue;
                }
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
            resetColors();
        }

    }

}
