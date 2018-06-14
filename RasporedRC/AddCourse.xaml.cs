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
using System.Windows.Controls.Primitives;

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        public String Label
        {
            get;
            set;
        }
        public String CourseName
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }
        public String Year
        {
            get;
            set;
        }

        public AddCourse()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        private void _DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            // Finding the calendar that is child of stadart WPF DatePicker
            DatePicker datepicker = (DatePicker)sender;
            Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
            System.Windows.Controls.Calendar cal = (System.Windows.Controls.Calendar)popup.Child;
            cal.DisplayMode = System.Windows.Controls.CalendarMode.Decade;
        }
        public void AddItem(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.Year);
            Course c = new Course();
            c.label = this.Label;
            c.name = this.CourseName;
            c.startingYear = this.Year.Split(null)[0];
            c.description = this.Description;
            Console.WriteLine(c.name);
            MainWindow.courses.Add(c);

            MessageBox.Show("Smer uspešno dodat!", "Dodavanje smera", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
