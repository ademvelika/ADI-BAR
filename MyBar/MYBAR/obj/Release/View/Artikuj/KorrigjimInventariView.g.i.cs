﻿#pragma checksum "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D058E73A1DF2062BC455D27D0BC021E0F8260E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYBAR.View.Artikuj;
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


namespace MYBAR.View.Artikuj {
    
    
    /// <summary>
    /// KorrigjimInventariView
    /// </summary>
    public partial class KorrigjimInventariView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid KorrigjimList;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindPrevious;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindNext;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run Indeks;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run Number;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KorrigjoInventar;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/view/artikuj/korrigjiminventariview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
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
            
            #line 7 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
            ((MYBAR.View.Artikuj.KorrigjimInventariView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.KorrigjimList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 69 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
            this.SearchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FindPrevious = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
            this.FindPrevious.Click += new System.Windows.RoutedEventHandler(this.FindPrevious_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FindNext = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
            this.FindNext.Click += new System.Windows.RoutedEventHandler(this.FindNext_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Indeks = ((System.Windows.Documents.Run)(target));
            return;
            case 7:
            this.Number = ((System.Windows.Documents.Run)(target));
            return;
            case 8:
            this.KorrigjoInventar = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\View\Artikuj\KorrigjimInventariView.xaml"
            this.KorrigjoInventar.Click += new System.Windows.RoutedEventHandler(this.KorrigjoInventar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

