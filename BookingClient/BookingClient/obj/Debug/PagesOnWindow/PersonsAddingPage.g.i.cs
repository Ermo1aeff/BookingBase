﻿#pragma checksum "..\..\..\PagesOnWindow\PersonsAddingPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99C12E6340914B3F6D17DD1FB0678D7DEAF0BCCB1792C2141856455C7DE7DCF5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BookingClient.PagesOnWindow;
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


namespace BookingClient.PagesOnWindow {
    
    
    /// <summary>
    /// PersonsAddingPage
    /// </summary>
    public partial class PersonsAddingPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 141 "..\..\..\PagesOnWindow\PersonsAddingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PersonListBox;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\PagesOnWindow\PersonsAddingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalDueTextBox;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\PagesOnWindow\PersonsAddingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CommitSelectingRoomsButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BookingClient;component/pagesonwindow/personsaddingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PagesOnWindow\PersonsAddingPage.xaml"
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
            this.PersonListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.TotalDueTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.CommitSelectingRoomsButton = ((System.Windows.Controls.Button)(target));
            
            #line 211 "..\..\..\PagesOnWindow\PersonsAddingPage.xaml"
            this.CommitSelectingRoomsButton.Click += new System.Windows.RoutedEventHandler(this.CommitSelectingRoomsButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

