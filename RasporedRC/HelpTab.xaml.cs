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
using System.IO;

namespace RasporedRC
{
    /// <summary>
    /// Interaction logic for HelpTab.xaml
    /// </summary>
    public partial class HelpTab : UserControl
    {
        //private JavaScriptControlHelper ch;

        private Uri u;

        public HelpTab(string key, MainWindow originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("{0}/../../Help/{1}.htm", curDir, key);
            
            if (!File.Exists(path))
            {
                key = "error";
            }
            u = new Uri(String.Format("file:///{0}/../../Help/{1}.htm", curDir, key));
            //ch = new JavaScriptControlHelper(originator);
            //wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);

        }

        private void BrowseBack(object sender, RoutedEventArgs e)
        {
            if (wbHelp.CanGoBack)
            {
                wbHelp.GoBack();
            }
        }

        private void BrowseForward(object sender, RoutedEventArgs e)
        {
            if (wbHelp.CanGoForward) 
            { 
                wbHelp.GoForward();
            }
        }


        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            
            
        }
    }
}

