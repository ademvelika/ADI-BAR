﻿#pragma checksum "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0ADA0A847BFFAA68CAA9D76F566D1DCD3FD2D24"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYBAR.CustomControls;
using MYBAR.CustomControls.FatureFilter;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace MYBAR.CustomControls.FatureFilter {
    
    
    /// <summary>
    /// FatureAdminFilter
    /// </summary>
    public partial class FatureAdminFilter : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartClock;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FinishClock;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserCombo;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IntervalCheck;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Switch;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderNumberStart;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderNumberFinish;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/customcontrols/faturefilter/fatureadminfilter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
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
            this.StartClock = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.FinishClock = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.UserCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.IntervalCheck = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
            this.IntervalCheck.Checked += new System.Windows.RoutedEventHandler(this.IntervalCheck_Checked);
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
            this.IntervalCheck.Unchecked += new System.Windows.RoutedEventHandler(this.IntervalCheck_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Switch = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 58 "..\..\..\..\CustomControls\FatureFilter\FatureAdminFilter.xaml"
            this.Switch.Click += new System.Windows.RoutedEventHandler(this.Switch_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OrderNumberStart = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.OrderNumberFinish = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

