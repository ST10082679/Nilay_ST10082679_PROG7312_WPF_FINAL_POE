﻿#pragma checksum "..\..\..\Views\ServiceRequestStatus.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D5E6525A6C30D01CBA755FCFA5B41077BB4E428C4936145F4DE4BC02641A3D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Nilay_ST10082679_PROG7312_WPF_FINAL_POE;
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


namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE {
    
    
    /// <summary>
    /// ServiceRequestStatus
    /// </summary>
    public partial class ServiceRequestStatus : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBackToMainMenu;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSearch;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSortByPriority;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGetUrgent;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReset;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelServiceRequests;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbStatuses;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\Views\ServiceRequestStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Nilay_ST10082679_PROG7312_WPF_FINAL_POE;component/views/servicerequeststatus.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ServiceRequestStatus.xaml"
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
            this.BtnBackToMainMenu = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\ServiceRequestStatus.xaml"
            this.BtnBackToMainMenu.Click += new System.Windows.RoutedEventHandler(this.BtnBackToMainMenu_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Views\ServiceRequestStatus.xaml"
            this.BtnSearch.Click += new System.Windows.RoutedEventHandler(this.BtnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnSortByPriority = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Views\ServiceRequestStatus.xaml"
            this.BtnSortByPriority.Click += new System.Windows.RoutedEventHandler(this.BtnSortByPriority_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnGetUrgent = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\Views\ServiceRequestStatus.xaml"
            this.BtnGetUrgent.Click += new System.Windows.RoutedEventHandler(this.BtnGetUrgent_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnReset = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\Views\ServiceRequestStatus.xaml"
            this.BtnReset.Click += new System.Windows.RoutedEventHandler(this.BtnReset_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.stackPanelServiceRequests = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.cmbStatuses = ((System.Windows.Controls.ComboBox)(target));
            
            #line 144 "..\..\..\Views\ServiceRequestStatus.xaml"
            this.cmbStatuses.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbStatuses_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LblComboBox = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

