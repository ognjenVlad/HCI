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

        public ObservableCollection<TestOutput> MainList
        {
            get;
            set;
        }

        public ObservableCollection<TestOutput> SideList
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


            Style styleSide = new Style(typeof(ListBoxItem));
            styleSide.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));

            styleSide.Setters.Add(
                new EventSetter(
                    ListBoxItem.PreviewMouseLeftButtonDownEvent,
                    new MouseButtonEventHandler(MainWindow_PreviewMouseLeftButtonDown)));

            styleSide.Setters.Add(
                new EventSetter(
                    ListBoxItem.DropEvent,
                    new DragEventHandler(SideWindowElem_Drop)));

            LbSide.ItemContainerStyle = styleSide;
            LbSchedule.ItemContainerStyle = styleSchedule;
            
            List<TestOutput> Tests = new List<TestOutput>();

            /*Tests.Add(new TestOutput("Predmet1", 60));
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
            */

            for(int i = 0; i < 60; i++)
            {
                Tests.Add(new TestOutput("", 10));
            }
            List<TestOutput> Tests2 = new List<TestOutput>();
            Tests2.Add(new TestOutput("Predmet1", 30));
            Tests2.Add(new TestOutput("Predmet2", 60));
            Tests2.Add(new TestOutput("Predmet4", 60));
            Tests2.Add(new TestOutput("Predmet3", 60));
            Tests2.Add(new TestOutput("Predmet6", 60));
            Tests2.Add(new TestOutput("Predmet1", 60));
            Tests2.Add(new TestOutput("Predmet2", 60));
            Tests2.Add(new TestOutput("Predmet4", 60));
            Tests2.Add(new TestOutput("Predmet3", 60));

            SideList = new ObservableCollection<TestOutput>(Tests2);

            MainList = new ObservableCollection<TestOutput>(Tests);
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
                TestOutput source = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;

                int sourceIndex = MainList.IndexOf(source);
                int targetIndex = MainList.IndexOf(target);

                if (sourceIndex != -1)
                {
                    MainList.RemoveAt(sourceIndex);
                    MainList.Insert(targetIndex, source);
                } else
                {
                    sourceIndex = SideList.IndexOf(source);

                    if (MainList.ElementAt(targetIndex).Text == "" && MainList[targetIndex + 1].Text == "" && MainList[targetIndex+1].Text == "")
                    {
                        MainList.RemoveAt(targetIndex);
                        MainList.RemoveAt(targetIndex);
                        MainList.RemoveAt(targetIndex);
                        MainList.Insert(targetIndex, source);
                        SideList.RemoveAt(sourceIndex);
                    }
                    {

                    }
                }
            }
        }

        private void SideWindowElem_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                TestOutput source = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;

                int sourceIndex = SideList.IndexOf(source);
                int targetIndex = SideList.IndexOf(target);

                if(sourceIndex != -1)
                {
                    SideList.RemoveAt(sourceIndex);
                    SideList.Insert(targetIndex, source);
                }else
                {
                    sourceIndex = MainList.IndexOf(source);
                    MainList.RemoveAt(sourceIndex);
                    MainList.Insert(sourceIndex, new Model.TestOutput("", 20));
                    MainList.Insert(sourceIndex, new Model.TestOutput("", 20));
                    MainList.Insert(sourceIndex, new Model.TestOutput("", 20));
                    SideList.Insert(targetIndex, source);
                }
            }
        }

        private void SideWindow_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                TestOutput student = e.Data.GetData(typeof(TestOutput)) as TestOutput;
                TestOutput target = ((ListBoxItem)sender).DataContext as TestOutput;

                int sourceIndex = MainList.IndexOf(student);
                int targetIndex = MainList.IndexOf(target);

            }
        }

        private void Expand_Window(object sender, MouseEventArgs e)
        {
            LbSide.Width = 130;
        }

        private void Shrink_Window(object sender, MouseEventArgs e)
        {
            LbSide.Width = 5;
        }

        private void LbSide_DragEnter(object sender, DragEventArgs e)
        {
            LbSide.Width = 130;
        }

        private void LbSide_DragLeave(object sender, DragEventArgs e)
        {
            LbSide.Width = 5;
        }

    }

}
