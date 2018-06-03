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
        public void AddItem(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.Year);
            Course c = new Course();
            c.label = this.Label;
            c.name = this.CourseName;
            c.startingYear = this.Year;
            c.description = this.Description;
            MainWindow.courses.Add(c);

            this.Close();
        }
    }
}
