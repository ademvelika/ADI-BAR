﻿#pragma checksum "..\..\..\CustomControls\Ora.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B5CFE9F0897F7964C088EC8D9EB375DE93E81B1"
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


namespace MYBAR.CustomControls {
    
    
    /// <summary>
    /// Ora
    /// </summary>
    public partial class Ora : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OraBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShtoOre;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZbritOre;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinutaBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShtoMinuta;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZbritMinuta;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\CustomControls\Ora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AMPM;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/customcontrols/ora.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CustomControls\Ora.xaml"
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
            this.OraBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\CustomControls\Ora.xaml"
            this.OraBox.LostFocus += new System.Windows.RoutedEventHandler(this.OraBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ShtoOre = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\CustomControls\Ora.xaml"
            this.ShtoOre.Click += new System.Windows.RoutedEventHandler(this.ShtoOre_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ZbritOre = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\CustomControls\Ora.xaml"
            this.ZbritOre.Click += new System.Windows.RoutedEventHandler(this.ZbritOre_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MinutaBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\CustomControls\Ora.xaml"
            this.MinutaBox.LostFocus += new System.Windows.RoutedEventHandler(this.MinutaBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShtoMinuta = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\CustomControls\Ora.xaml"
            this.ShtoMinuta.Click += new System.Windows.RoutedEventHandler(this.ShtoMinuta_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ZbritMinuta = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\CustomControls\Ora.xaml"
            this.ZbritMinuta.Click += new System.Windows.RoutedEventHandler(this.ZbritMinuta_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AMPM = ((System.Windows.Controls.Label)(target));
            
            #line 48 "..\..\..\CustomControls\Ora.xaml"
            this.AMPM.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.AMPM_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

