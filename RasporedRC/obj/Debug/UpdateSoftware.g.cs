﻿#pragma checksum "..\..\UpdateSoftware.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6EDDA22AF6569EEF4C0F5884C2389E8E55A053F1"
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
    /// UpdateSoftware
    /// </summary>
    public partial class UpdateSoftware : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox oznaka;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox opis;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker godina;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ime;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox proizvodjac;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sajt;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cena;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox os;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\UpdateSoftware.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;
        
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
            System.Uri resourceLocater = new System.Uri("/RasporedRC;component/updatesoftware.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateSoftware.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.oznaka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.opis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.godina = ((System.Windows.Controls.DatePicker)(target));
            
            #line 92 "..\..\UpdateSoftware.xaml"
            this.godina.CalendarOpened += new System.Windows.RoutedEventHandler(this._DatePicker_CalendarOpened);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.proizvodjac = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.sajt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.os = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.add = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\UpdateSoftware.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.changeSoftware);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

