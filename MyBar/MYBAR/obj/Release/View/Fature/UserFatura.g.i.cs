﻿#pragma checksum "..\..\..\..\View\Fature\UserFatura.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81462BFB9790808C85B0F7327B97A817"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYBAR.View.Fature;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace MYBAR.View.Fature {
    
    
    /// <summary>
    /// UserFatura
    /// </summary>
    public partial class UserFatura : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Kalendari;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Kalendari2;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Filtro;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FaturaList;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Totali;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.FlowDocumentReader FaturaShow;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\View\Fature\UserFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Print;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/view/fature/userfatura.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Fature\UserFatura.xaml"
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
            this.Kalendari = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.Kalendari2 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.Filtro = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\View\Fature\UserFatura.xaml"
            this.Filtro.Click += new System.Windows.RoutedEventHandler(this.Filtro_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FaturaList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\..\..\View\Fature\UserFatura.xaml"
            this.FaturaList.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.FaturaList_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Totali = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.FaturaShow = ((System.Windows.Controls.FlowDocumentReader)(target));
            return;
            case 7:
            this.Print = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\View\Fature\UserFatura.xaml"
            this.Print.Click += new System.Windows.RoutedEventHandler(this.Print_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

