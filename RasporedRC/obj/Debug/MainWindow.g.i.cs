﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "700415B5CFBFFAF95A74B7F830B3058DDC8072EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RasporedRC;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RasporedRC {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl mainTabControl;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbSide;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbSchedulePon;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbScheduleUto;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbScheduleSre;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbScheduleCet;
        
        #line default
        #line hidden
        
        
        #line 273 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbSchedulePet;
        
        #line default
        #line hidden
        
        
        #line 288 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbScheduleSub;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RasporedRC;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainTabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            
            #line 51 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddSubject);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 59 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCourse);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 65 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddSoftware);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 70 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddClassroom);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 76 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteSubject);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 79 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Tables);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 80 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RunDemo);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 81 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.clearScreen);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 83 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowHelp);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 89 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.LbSide = ((System.Windows.Controls.ListBox)(target));
            
            #line 128 "..\..\MainWindow.xaml"
            this.LbSide.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 129 "..\..\MainWindow.xaml"
            this.LbSide.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Expand_Window);
            
            #line default
            #line hidden
            
            #line 130 "..\..\MainWindow.xaml"
            this.LbSide.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Shrink_Window);
            
            #line default
            #line hidden
            
            #line 132 "..\..\MainWindow.xaml"
            this.LbSide.PreviewDragEnter += new System.Windows.DragEventHandler(this.LbSide_DragEnter);
            
            #line default
            #line hidden
            
            #line 133 "..\..\MainWindow.xaml"
            this.LbSide.PreviewDragLeave += new System.Windows.DragEventHandler(this.LbSide_DragLeave);
            
            #line default
            #line hidden
            
            #line 134 "..\..\MainWindow.xaml"
            this.LbSide.Drop += new System.Windows.DragEventHandler(this.SideWindow_Drop);
            
            #line default
            #line hidden
            return;
            case 14:
            this.LbSchedulePon = ((System.Windows.Controls.ListBox)(target));
            
            #line 214 "..\..\MainWindow.xaml"
            this.LbSchedulePon.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 215 "..\..\MainWindow.xaml"
            this.LbSchedulePon.DragEnter += new System.Windows.DragEventHandler(this.MainWindow_DragEnter);
            
            #line default
            #line hidden
            return;
            case 15:
            this.LbScheduleUto = ((System.Windows.Controls.ListBox)(target));
            
            #line 229 "..\..\MainWindow.xaml"
            this.LbScheduleUto.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 230 "..\..\MainWindow.xaml"
            this.LbScheduleUto.DragEnter += new System.Windows.DragEventHandler(this.MainWindow_DragEnter);
            
            #line default
            #line hidden
            return;
            case 16:
            this.LbScheduleSre = ((System.Windows.Controls.ListBox)(target));
            
            #line 244 "..\..\MainWindow.xaml"
            this.LbScheduleSre.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 245 "..\..\MainWindow.xaml"
            this.LbScheduleSre.DragEnter += new System.Windows.DragEventHandler(this.MainWindow_DragEnter);
            
            #line default
            #line hidden
            return;
            case 17:
            this.LbScheduleCet = ((System.Windows.Controls.ListBox)(target));
            
            #line 260 "..\..\MainWindow.xaml"
            this.LbScheduleCet.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 261 "..\..\MainWindow.xaml"
            this.LbScheduleCet.DragEnter += new System.Windows.DragEventHandler(this.MainWindow_DragEnter);
            
            #line default
            #line hidden
            return;
            case 18:
            this.LbSchedulePet = ((System.Windows.Controls.ListBox)(target));
            
            #line 275 "..\..\MainWindow.xaml"
            this.LbSchedulePet.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 276 "..\..\MainWindow.xaml"
            this.LbSchedulePet.DragEnter += new System.Windows.DragEventHandler(this.MainWindow_DragEnter);
            
            #line default
            #line hidden
            return;
            case 19:
            this.LbScheduleSub = ((System.Windows.Controls.ListBox)(target));
            
            #line 290 "..\..\MainWindow.xaml"
            this.LbScheduleSub.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainWindow_MouseMove);
            
            #line default
            #line hidden
            
            #line 291 "..\..\MainWindow.xaml"
            this.LbScheduleSub.DragEnter += new System.Windows.DragEventHandler(this.MainWindow_DragEnter);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

