﻿#pragma checksum "..\..\..\View\MyFatura.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D3DD01A560C67A9FB6843F8140B23BD2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYBAR.View;
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


namespace MYBAR.View {
    
    
    /// <summary>
    /// MyFatura
    /// </summary>
    public partial class MyFatura : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl FilterGUI;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Filtro;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FaturaList;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Anullo_Fature;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Totali;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.FlowDocumentReader FaturaShow;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ProgresNumber;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Slash;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TotalProgres;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pas;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\View\MyFatura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Para;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/view/myfatura.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MyFatura.xaml"
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
            this.FilterGUI = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 2:
            this.Filtro = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\View\MyFatura.xaml"
            this.Filtro.Click += new System.Windows.RoutedEventHandler(this.Filtro_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FaturaList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\View\MyFatura.xaml"
            this.FaturaList.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.FaturaList_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Anullo_Fature = ((System.Windows.Controls.MenuItem)(target));
            
            #line 46 "..\..\..\View\MyFatura.xaml"
            this.Anullo_Fature.Click += new System.Windows.RoutedEventHandler(this.Anullo_Fature_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Totali = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.FaturaShow = ((System.Windows.Controls.FlowDocumentReader)(target));
            
            #line 81 "..\..\..\View\MyFatura.xaml"
            this.FaturaShow.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.FaturaShow_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProgresNumber = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Slash = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.TotalProgres = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Pas = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\View\MyFatura.xaml"
            this.Pas.Click += new System.Windows.RoutedEventHandler(this.Pas_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Para = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\View\MyFatura.xaml"
            this.Para.Click += new System.Windows.RoutedEventHandler(this.Para_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

