using RasporedRC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UpdateSoftware.xaml
    /// </summary>
    public partial class UpdateSoftware : Window
    {
        public Software softwareToUpdate
        {
            get;
            set;
        }
        public ObservableCollection<string> OS
        {
            get;
            set;
        }
        public String SelectedOS
        {
            get;
            set;
        }
        public UpdateSoftware()
        {
            this.OS = MainWindow.OS;
            this.softwareToUpdate = MainWindow.softwareToUpdate;
            this.DataContext = this;

            InitializeComponent();

            //this.os.SelectedValue = MainWindow.softwareToUpdate.os;
        }
        private void _DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            // Finding the calendar that is child of stadart WPF DatePicker
            DatePicker datepicker = (DatePicker)sender;
            Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
            System.Windows.Controls.Calendar cal = (System.Windows.Controls.Calendar)popup.Child;
            cal.DisplayMode = System.Windows.Controls.CalendarMode.Decade;
        }

        public void changeSoftware(object sender, RoutedEventArgs e)
        {
            this.softwareToUpdate.yearOfPublishing = this.softwareToUpdate.yearOfPublishing.Split(null)[0];
            MessageBox.Show("Softver uspešno dodat!", "Dodavanje softvera", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
