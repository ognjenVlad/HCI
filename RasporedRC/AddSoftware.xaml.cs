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
using System.Windows.Shapes;
using RasporedRC.Model;
using System.Windows.Controls.Primitives;

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for AddSoftware.xaml
    /// </summary>
    public partial class AddSoftware : Window
    {
        public ObservableCollection<string> operatingSys
        {
            get;
            set;
        }
        public String Label
        {
            get;
            set;
        }
        public String Namee
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
        public Double Price
        {
            get;
            set;
        }
        public String Manofacturer
        {
            get;
            set;
        }
        public String Website
        {
            get;
            set;
        }
        public String OS
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
        public AddSoftware()
        {
            operatingSys = new ObservableCollection<string>(); 
            operatingSys.Add("Windows");
            operatingSys.Add("Linux");
            operatingSys.Add("Windows/Linux");
            this.DataContext = this;
            InitializeComponent();
        }
        public void AddItem(object sender, RoutedEventArgs e)
        {
            Software s = new Software();
            s.description = this.Description;
            s.price = this.Price;
            s.label = this.Label;
            s.manofacturer = this.Manofacturer;
            s.name = this.Name;
            s.os = this.OS;
            s.yearOfPublishing = this.Year.Split(null)[0];
            s.website = this.Website;
            MainWindow.softwares.Add(s);

            MessageBox.Show("Softver uspešno dodat!", "Dodavanje softvera", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
