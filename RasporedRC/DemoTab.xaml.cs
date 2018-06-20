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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using RasporedRC.Model;
using System.Globalization;
using System.Collections.ObjectModel;

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for DemoTab.xaml
    /// </summary>
    public partial class DemoTab : UserControl
    {
        private int korak;
        private DispatcherTimer timer;
        private AddCourse add_course;
        private Brush boja;
        private Course kurs;
        private Tables tables;
        private AddSubject add_subj;
        private Subject predmet;
        private Subject predmet2;
        private Term term;
        private Software software;
        private Classroom classroom;
        private DeleteSubject del_subj;

        public DemoTab()
        {
            InitializeComponent();

            MainListPonDemo = new ObservableCollection<Term>();
            MainListUtoDemo = new ObservableCollection<Term>();
            MainListSreDemo = new ObservableCollection<Term>();
            MainListCetDemo = new ObservableCollection<Term>();
            MainListPetDemo = new ObservableCollection<Term>();
            MainListSubDemo = new ObservableCollection<Term>();
            SideListDemo = new ObservableCollection<Term>();
            classrooms_display = new ObservableCollection<string>();

            fillLists();

            LbSchedulePon.ItemsSource = MainListPonDemo;
            LbScheduleUto.ItemsSource = MainListUtoDemo;
            LbScheduleSre.ItemsSource = MainListSreDemo;
            LbScheduleCet.ItemsSource = MainListCetDemo;
            LbSchedulePet.ItemsSource = MainListPetDemo;
            LbScheduleSub.ItemsSource = MainListSubDemo;
            LbSide.ItemsSource = SideListDemo;

            korak = 0;
            timer = new DispatcherTimer();
            timer.Tick += startDemoTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1200);

            this.MouseUp += Grid_MouseUp;

            boja = this.DodajMeni.Background;
            add_course = new AddCourse();
            add_course.MouseUp += Grid_MouseUp;


            software = new Software("vs", "VisualStudio", "Make c# apps and more!", "Microsoft", "www.microsoft.com", "10/11/2012", "Windows", 230);
            MainWindow.softwares.Add(software);
            classroom = new Classroom("L4", "Ucionica neka.", 15, true, true, false, "Windows");
            MainWindow.classrooms.Add(classroom);
            ucionicaPrikaz.Items.Add(classroom.label);
            ucionicaPrikaz.Items.Add("L5");
            kurs = new Course("sw", "Ucimo mlade inzenjere", "Softversko inzenjerstvo i informacione tehnologije", "11/11/2014");


            tables = new Tables();
            tables.MouseUp += Grid_MouseUp;

            add_subj = new AddSubject();
            add_subj.MouseUp += Grid_MouseUp;
            predmet = new Subject("pr1", "Predmet 1", "opis predmeta 1", kurs, 20, 4, 2, true, true, false, "Windows");
            predmet2 = new Subject("pr2", "Predmet 2", "opis predmeta 2", kurs, 12, 3, 3, true, true, false, "Windows");
            MainWindow.subjects.Add(predmet2);
            term = new Term("HCI", "Human computer interaction", "pr1", "Predmet 1",4);
            for (int i = 0; i < predmet.numberOfClasses; i++ )
                SideListDemo.Add(new Term("HCI", "Human computer interaction", "pr1", "Predmet 1",4));

            del_subj = new DeleteSubject();

            timer.Start();

        }

        private void startDemoTick(object sender, EventArgs e)
        {
            // DEMO DIJALOG DODAVANJE SMERA
            if (korak == 0)
            {
                this.ucionicaPrikaz.SelectedValue = classroom.label;
                korak++;
            }
            else if (korak == 1)
            {
                this.DodajMeni.IsSubmenuOpen = true;
                korak++;
            }
            else if (korak == 2)
            {
                this.DodajSmer.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 3)
            {
                this.DodajMeni.IsSubmenuOpen = false;
                this.DodajSmer.Background = boja;
                add_course.Show();
                boja = add_course.oznaka.Background;
                add_course.oznaka.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 4)
            {
                add_course.oznaka.Background = boja;
                add_course.oznaka.Text = kurs.label;
                korak++;
            }
            else if (korak == 5)
            {
                boja = add_course.opis.Background;
                add_course.opis.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 6)
            {
                add_course.opis.Background = boja;
                add_course.opis.Text = kurs.description;
                korak++;
            }
            else if (korak == 7)
            {
                boja = add_course.year.Background;
                add_course.year.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 8)
            {
                add_course.year.Background = boja;
                add_course.year.SelectedDate = DateTime.ParseExact(kurs.startingYear, "d/M/yyyy", CultureInfo.InvariantCulture);
                korak++;
            }
            else if (korak == 9)
            {
                boja = add_course.ime.Background;
                add_course.ime.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 10)
            {
                add_course.ime.Background = boja;
                add_course.ime.Text = kurs.name;
                add_course.add.IsHitTestVisible = false;
                korak++;
            }
            else if (korak == 11)
            {
                boja = add_course.add.Background;
                add_course.add.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 12)
            {
                add_course.ime.Background = boja;
                add_course.Close();
                MainWindow.courses.Add(kurs);
                add_course.add.IsHitTestVisible = true;
                korak++;
            }
            // DEMO PREGLED DODATOG SMERA
            else if (korak == 13)
            {
                boja = this.PregledOpcija.Background;
                this.PregledOpcija.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 14)
            {
                this.PregledOpcija.Background = boja;
                tables.Show();
                korak++;
            }
            else if (korak == 15)
            {
                tables.SmeroviTab.Focus();
                korak++;
            }
            else if (korak == 16)
            {
                korak++;
            }
            else if (korak == 17)
            {
                tables.Close();
                korak++;
            }
            // DEMO DIJALOG DODAVANJA PREDMETA
            else if (korak == 18)
            {
                this.DodajMeni.IsSubmenuOpen = true;
                korak++;
            }
            else if (korak == 19)
            {
                this.DodajPredmet.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 20)
            {
                this.DodajMeni.IsSubmenuOpen = false;
                this.DodajPredmet.Background = boja;
                add_subj.Show();
                boja = add_subj.predmet.Background;
                add_subj.predmet.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 21)
            {
                add_subj.predmet.Background = boja;
                add_subj.predmet.Text = predmet.label;
                korak++;
            }
            else if (korak == 22)
            {
                boja = add_subj.opis.Background;
                add_subj.opis.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 23)
            {
                add_subj.opis.Background = boja;
                add_subj.opis.Text = predmet.description;
                korak++;
            }
            else if (korak == 24)
            {
                boja = add_subj.naziv.Background;
                add_subj.naziv.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 25)
            {
                add_subj.naziv.Background = boja;
                add_subj.naziv.Text = predmet.name;
                korak++;
            }
            else if (korak == 26)
            {
                boja = add_subj.size.Background;
                add_subj.size.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 27)
            {
                add_subj.size.Background = boja;
                add_subj.size.Text = predmet.groupSize.ToString();
                korak++;
            }
            else if (korak == 28)
            {
                boja = add_subj.termini.Background;
                add_subj.termini.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 29)
            {
                add_subj.termini.Background = boja;
                add_subj.termini.Text = predmet.numberOfClasses.ToString();
                korak++;
            }
            else if (korak == 30)
            {
                boja = add_subj.duzina.Background;
                add_subj.duzina.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 31)
            {
                add_subj.duzina.Background = boja;
                add_subj.duzina.Text = predmet.numberOfAppointment.ToString();
                korak++;
            }
            else if (korak == 32)
            {
                add_subj.tabla1.IsChecked = true;
                korak++;
            }
            else if (korak == 33)
            {
                add_subj.pametna2.IsChecked = true;
                korak++;
            }
            else if (korak == 34)
            {
                add_subj.projektor1.IsChecked = true;
                add_subj.addSubjScroll.ScrollToEnd();
                korak++;
            }
            else if (korak == 35)
            {
                add_subj.os.IsDropDownOpen = true;
                korak++;
            }
            else if (korak == 36)
            {
                add_subj.os.SelectedValue = predmet.os;
                add_subj.os.IsDropDownOpen = false;
                add_subj.Courses.Add(kurs.label);
                korak++;
            }
            else if (korak == 37)
            {
                add_subj.course.IsDropDownOpen = true;
                korak++;
            }
            else if (korak == 38)
            {
                add_subj.course.SelectedValue = kurs.label;
                add_subj.course.IsDropDownOpen = false;
                korak++;
            }
            else if (korak == 39)
            {
                add_subj.soft.IsDropDownOpen = true;
                korak++;
            }
            else if (korak == 40)
            {
                add_subj.soft.SelectedValue = software.label;
                add_subj.soft.IsDropDownOpen = false;
                korak++;
            }
            else if (korak == 41)
            {
                boja = add_subj.Add_Software.Background;
                add_subj.Add_Software.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 42)
            {
                add_subj.SelectedSoftwares.Add(software);
                add_subj.Add_Software.Background = boja;
                korak++;
            }
            else if (korak == 43)
            {
                boja = add_subj.add.Background;
                add_subj.add.Background = Brushes.Gray;
                add_subj.add.IsHitTestVisible = false;
                korak++;
            }
            else if (korak == 44)
            {
                add_subj.add.Background = boja;
                korak++;
            }
            else if (korak == 45)
            {
                add_subj.Close();
                add_subj.add.IsHitTestVisible = true;
                MainWindow.subjects.Add(predmet);
                korak++;
            }
            // DEMO ZA DRAG N DROP
            else if (korak == 46)
            {
                korak++;
            }
            else if (korak == 47)
            {
                LbSide.Width = 194;
                korak++;
            }
            else if (korak == 48)
            {

                MainListPonDemo.RemoveAt(4);
                MainListPonDemo.RemoveAt(4);
                MainListPonDemo.RemoveAt(4);
                MainListPonDemo.Insert(4,term);
                SideListDemo.RemoveAt(0);
                korak++;
            }
            else if (korak == 49)
            {
                LbSide.Width = 8; 
                korak++;
            }
            else if (korak == 50)
            {
                MainListPonDemo.RemoveAt(4);
                MainListPonDemo.Insert(4, new Term("", "", "", "",0));
                MainListPonDemo.Insert(4, new Term("", "", "", "",0));
                MainListPonDemo.Insert(4, new Term("", "", "", "",0));
                MainListSreDemo.RemoveAt(12);
                MainListSreDemo.RemoveAt(12);
                MainListSreDemo.RemoveAt(12);
                MainListSreDemo.Insert(12, term);
                korak++;
            }
            else if (korak == 51)
            {
                this.ucionicaPrikaz.IsDropDownOpen = true;
                korak++;
            }
            else if (korak == 52)
            {
                
                this.ucionicaPrikaz.SelectedValue = "L5";
                this.ucionicaPrikaz.IsDropDownOpen = false;
                emptyLists();
                fillLists();
                MainListCetDemo.RemoveAt(2);
                MainListCetDemo.RemoveAt(2);
                MainListCetDemo.RemoveAt(2);
                MainListCetDemo.Insert(2, new Term(kurs.label,kurs.name,predmet2.label, predmet2.name,predmet2.numberOfClasses));
                MainListCetDemo.RemoveAt(6);
                MainListCetDemo.RemoveAt(6);
                MainListCetDemo.RemoveAt(6);
                MainListCetDemo.Insert(6, new Term(kurs.label,kurs.name,predmet2.label, predmet2.name, predmet2.numberOfClasses));
                MainListUtoDemo.RemoveAt(17);
                MainListUtoDemo.RemoveAt(17);
                MainListUtoDemo.RemoveAt(17);
                MainListUtoDemo.Insert(17, new Term(kurs.label, kurs.name, predmet2.label, predmet2.name, predmet2.numberOfClasses));
                korak++;
            }
            else if (korak == 53)
            {
                LbSide.Width = 194;
                korak++;
            }
            else if (korak == 54)
            {
                MainListSreDemo.RemoveAt(15);
                MainListSreDemo.RemoveAt(15);
                MainListSreDemo.RemoveAt(15);
                MainListSreDemo.Insert(15, term);
                SideListDemo.RemoveAt(0);
                korak++;
            }
            else if (korak == 55)
            {
                MainListSreDemo.RemoveAt(18);
                MainListSreDemo.RemoveAt(18);
                MainListSreDemo.RemoveAt(18);
                MainListSreDemo.Insert(18, term);
                SideListDemo.RemoveAt(0);
                korak++;
            }
            else if (korak == 56)
            {
                LbSide.Width = 8;
                korak++;
            }
            else if (korak == 57)
            {
                boja = brisanje.Background;
                brisanje.Background = Brushes.Gray;
                korak++;
            }
            else if (korak == 58)
            {
                brisanje.Background = boja;
                del_subj.Show();
                korak++;
            }
            else if (korak == 59)
            {
                var test = del_subj.subj_listbox.Items.IndexOf(predmet2);
                //del_subj.subj_listbox.Template.
                korak++;
            }
            else if (korak == 60)
            {
                del_subj.Close();
                MainListCetDemo.RemoveAt(2);
                MainListCetDemo.Insert(2, new Term("", "", "", "",0));
                MainListCetDemo.Insert(2, new Term("", "", "", "",0));
                MainListCetDemo.Insert(2, new Term("", "", "", "",0));
                MainListCetDemo.RemoveAt(8);
                MainListCetDemo.Insert(8, new Term("", "", "", "",0));
                MainListCetDemo.Insert(8, new Term("", "", "", "",0));
                MainListCetDemo.Insert(8, new Term("", "", "", "",0));
                MainListUtoDemo.RemoveAt(17);
                MainListUtoDemo.Insert(17, new Term("", "", "", "",0));
                MainListUtoDemo.Insert(17, new Term("", "", "", "",0));
                MainListUtoDemo.Insert(17, new Term("", "", "", "",0));
                korak++;
            }
            else if (korak == 61)
            {

                korak++;
            }
            else
            {
                timer.Stop();
                deleteUsedEntities();
                MessageBox.Show("Demo je prekinut ili je završio sa izvršavanjem.");

            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            add_course.Close();
            tables.Close();
            add_subj.Close();
            //zce.Close();
            deleteUsedEntities();
            MessageBox.Show("Demo je prekinut ili je završio sa izvršavanjem.");
            //this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void deleteUsedEntities()
        {
            MainWindow.subjects.Remove(predmet);
            MainWindow.subjects.Remove(predmet2);
            MainWindow.courses.Remove(kurs);
            MainWindow.classrooms.Remove(classroom);
            MainWindow.softwares.Remove(software);
        }
        
        private void fillLists()
        {
            for (int i = 0; i < 64; i++)
            {
                MainListPonDemo.Add(new Term("", "", "", "",0));
                MainListUtoDemo.Add(new Term("", "", "", "",0));
                MainListSreDemo.Add(new Term("", "", "", "",0));
                MainListCetDemo.Add(new Term("", "", "", "",0));
                MainListPetDemo.Add(new Term("", "", "", "",0));
                MainListSubDemo.Add(new Term("", "", "", "",0));

            }
        }

        private void emptyLists()
        {
            MainListPonDemo.Clear();
            MainListUtoDemo.Clear();
            MainListSreDemo.Clear();
            MainListCetDemo.Clear();
            MainListPetDemo.Clear();
            MainListSubDemo.Clear();
        }

        public void abortDemo()
        {
            timer.Stop();
            add_course.Close();
            tables.Close();
            add_subj.Close();
            deleteUsedEntities();
        }

        public ObservableCollection<Term> MainListPonDemo
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListUtoDemo
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListSreDemo
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListCetDemo
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListPetDemo
        {
            get;
            set;
        }
        public ObservableCollection<Term> MainListSubDemo
        {
            get;
            set;
        }

        public static ObservableCollection<Term> SideListDemo
        {
            get;
            set;
        }

        public static ObservableCollection<string> classrooms_display
        {
            get;
            set;
        }
    }
}
