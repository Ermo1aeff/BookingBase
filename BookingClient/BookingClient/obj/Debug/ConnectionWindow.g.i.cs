﻿#pragma checksum "..\..\ConnectionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "94BE298C53A20AF144DF3C5F8E031A559369F731863D56A7F3B920C4F681FD9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BookingClient;
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


namespace BookingClient {
    
    
    /// <summary>
    /// ConnectionWindow
    /// </summary>
    public partial class ConnectionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ServerNameComboBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BaseNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTextBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox PasswordCheckBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckConnectionButton;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AuthorizationButton;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BookingClient;component/connectionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConnectionWindow.xaml"
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
            
            #line 17 "..\..\ConnectionWindow.xaml"
            ((BookingClient.ConnectionWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ServerNameComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.BaseNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LoginTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PasswordPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 80 "..\..\ConnectionWindow.xaml"
            this.PasswordPasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PasswordCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 85 "..\..\ConnectionWindow.xaml"
            this.PasswordCheckBox.Click += new System.Windows.RoutedEventHandler(this.PasswordCheckBox_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CheckConnectionButton = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\ConnectionWindow.xaml"
            this.CheckConnectionButton.Click += new System.Windows.RoutedEventHandler(this.CheckConnectionButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AuthorizationButton = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\ConnectionWindow.xaml"
            this.AuthorizationButton.Click += new System.Windows.RoutedEventHandler(this.AuthorizationButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\ConnectionWindow.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

