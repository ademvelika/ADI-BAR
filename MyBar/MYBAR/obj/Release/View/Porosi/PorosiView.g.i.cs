﻿#pragma checksum "..\..\..\..\View\Porosi\PorosiView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00B67829B677B7C326003B7754ADE67C127C64ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYBAR.View.Porosi;
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


namespace MYBAR.View.Porosi {
    
    
    /// <summary>
    /// PorosiView
    /// </summary>
    public partial class PorosiView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 179 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PorositeDG;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FatureBody;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PorosiBody;
        
        #line default
        #line hidden
        
        
        #line 300 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FreeTable;
        
        #line default
        #line hidden
        
        
        #line 304 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run Total;
        
        #line default
        #line hidden
        
        
        #line 316 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Aprovo;
        
        #line default
        #line hidden
        
        
        #line 317 "..\..\..\..\View\Porosi\PorosiView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Refuzo;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/view/porosi/porosiview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Porosi\PorosiView.xaml"
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
            this.PorositeDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 179 "..\..\..\..\View\Porosi\PorosiView.xaml"
            this.PorositeDG.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.PorositeDG_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FatureBody = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.PorosiBody = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.FreeTable = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Total = ((System.Windows.Documents.Run)(target));
            return;
            case 6:
            this.Aprovo = ((System.Windows.Controls.Button)(target));
            
            #line 316 "..\..\..\..\View\Porosi\PorosiView.xaml"
            this.Aprovo.Click += new System.Windows.RoutedEventHandler(this.Aprovo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Refuzo = ((System.Windows.Controls.Button)(target));
            
            #line 317 "..\..\..\..\View\Porosi\PorosiView.xaml"
            this.Refuzo.Click += new System.Windows.RoutedEventHandler(this.Refuzo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

