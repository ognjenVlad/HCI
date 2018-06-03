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

        public ObservableCollection<TestOutput> ListData
        {
            get;
            set;
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

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

            LbSchedule.ItemContainerStyle = styleSchedule;


            List<TestOutput> Tests = new List<TestOutput>();
            Tests.Add(new TestOutput("Predmet1", 60));
            Tests.Add(new TestOutput("", 20));
            Tests.Add(new TestOutput("Predmet2", 60));
            Tests.Add(new TestOutput("", 20));
            Tests.Add(new TestOutput("Predmet4", 60));
            Tests.Add(new TestOutput("Predmet3", 60));
            Tests.Add(new TestOutput("", 20));
            Tests.Add(new TestOutput("Predmet6", 60));
            Tests.Add(new TestOutput("Predmet1", 60));
            Tests.Add(new TestOutput("", 20));
            Tests.Add(new TestOutput("Predmet2", 60));
            Tests.Add(new TestOutput("", 20));
            Tests.Add(new TestOutput("Predmet4", 60));
            Tests.Add(new TestOutput("Predmet3", 60));

            ListData = new ObservableCollection<TestOutput>(Tests);
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
                TestOutput student = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;

                int sourceIndex = ListData.IndexOf(student);
                int targetIndex = ListData.IndexOf(target);

                if (sourceIndex != -1 && targetIndex != -1)
                {
                    if (sourceIndex < targetIndex)
                        Swap(sourceIndex, targetIndex);
                    else
                        Swap(targetIndex, sourceIndex);
                }
            }
        }

        private void Swap(int firstIndex,int secondIndex)
        {
            TestOutput first = ListData[firstIndex];
            TestOutput second = ListData[secondIndex];

            ListData.RemoveAt(secondIndex);
            ListData.RemoveAt(firstIndex);
            ListData.Insert(firstIndex, second);
            ListData.Insert(secondIndex, first);
        }

        private void Expand_Window(object sender, MouseEventArgs e)
        {
            rect.Width = 130;
        }

        private void Shrink_Window(object sender, MouseEventArgs e)
        {
            rect.Width = 5;
        }

        private void rect_DragEnter(object sender, DragEventArgs e)
        {
            rect.Width = 130;
        }

        private void rect_DragLeave(object sender, DragEventArgs e)
        {
            rect.Width = 5;
        }

    }

}
