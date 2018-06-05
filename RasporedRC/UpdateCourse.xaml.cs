using RasporedRC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for UpdateCourse.xaml
    /// </summary>
    public partial class UpdateCourse : Window
    {
        public Course courseToUpdate
        {
            get;
            set;
        }
        private void _DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            // Finding the calendar that is child of stadart WPF DatePicker
            DatePicker datepicker = (DatePicker)sender;
            Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
            System.Windows.Controls.Calendar cal = (System.Windows.Controls.Calendar)popup.Child;
            cal.DisplayMode = System.Windows.Controls.CalendarMode.Decade;
        }
        public void changeCourse(object sender, RoutedEventArgs e)
        {

            this.courseToUpdate.startingYear = this.courseToUpdate.startingYear.Split(null)[0];
            MessageBox.Show("Smer uspešno promenjen!", "Izmena smera", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        public UpdateCourse()
        {
            this.courseToUpdate = MainWindow.courseToUpdate;
            this.DataContext = this;
            InitializeComponent();
        }
    }
}
