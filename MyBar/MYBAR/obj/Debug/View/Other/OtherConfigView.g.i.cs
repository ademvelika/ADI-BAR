﻿#pragma checksum "..\..\..\..\View\Other\OtherConfigView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1815413C96654486CE2C597EFAA456FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYBAR.View.Other;
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


namespace MYBAR.View.Other {
    
    
    /// <summary>
    /// OtherConfigView
    /// </summary>
    public partial class OtherConfigView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\View\Other\OtherConfigView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GUI1;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\Other\OtherConfigView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GUI2;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\Other\OtherConfigView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton SwitchMobile;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\Other\OtherConfigView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton SwitchPM;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/view/other/otherconfigview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Other\OtherConfigView.xaml"
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
            
            #line 7 "..\..\..\..\View\Other\OtherConfigView.xaml"
            ((MYBAR.View.Other.OtherConfigView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GUI1 = ((System.Windows.Controls.Border)(target));
            
            #line 24 "..\..\..\..\View\Other\OtherConfigView.xaml"
            this.GUI1.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GUI1_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GUI2 = ((System.Windows.Controls.Border)(target));
            
            #line 28 "..\..\..\..\View\Other\OtherConfigView.xaml"
            this.GUI2.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GUI2_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SwitchMobile = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 35 "..\..\..\..\View\Other\OtherConfigView.xaml"
            this.SwitchMobile.Click += new System.Windows.RoutedEventHandler(this.Switch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SwitchPM = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 37 "..\..\..\..\View\Other\OtherConfigView.xaml"
            this.SwitchPM.Click += new System.Windows.RoutedEventHandler(this.SwitchPM_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

