﻿#pragma checksum "..\..\..\..\View\FatureView\FatureDetailsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "443125E0070DD0817150C218813C661A"
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
    /// FatureDetailsView
    /// </summary>
    public partial class FatureDetailsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KokaText;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FundText;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FatureImage;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FileChoser;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CleanImage;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RuajFatureInfo;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.FlowDocumentReader DocReader;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PreviewFatureInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/MYBAR;component/view/fatureview/faturedetailsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
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
            this.KokaText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.FundText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.FatureImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.FileChoser = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
            this.FileChoser.Click += new System.Windows.RoutedEventHandler(this.ImageChoser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CleanImage = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
            this.CleanImage.Click += new System.Windows.RoutedEventHandler(this.CleanImage_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RuajFatureInfo = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
            this.RuajFatureInfo.Click += new System.Windows.RoutedEventHandler(this.RuajFatureInfo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DocReader = ((System.Windows.Controls.FlowDocumentReader)(target));
            return;
            case 8:
            this.PreviewFatureInfo = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\View\FatureView\FatureDetailsView.xaml"
            this.PreviewFatureInfo.Click += new System.Windows.RoutedEventHandler(this.PreviewFatureInfo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

