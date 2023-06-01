﻿#pragma checksum "..\..\..\Windows\ConnectionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6DD4950269E700487C04A811E6CBFF64846C437B5405652E02BEDFAC569FDD9A"
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
        
        
        #line 50 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ServerNameComboBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BaseNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTextBox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox PasswordCheckBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckConnectionButton;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Windows\ConnectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AuthorizationButton;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Windows\ConnectionWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/BookingClient;component/windows/connectionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ConnectionWindow.xaml"
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
            
            #line 17 "..\..\..\Windows\ConnectionWindow.xaml"
            ((BookingClient.ConnectionWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 32 "..\..\..\Windows\ConnectionWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ServerNameComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.BaseNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.LoginTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PasswordPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 79 "..\..\..\Windows\ConnectionWindow.xaml"
            this.PasswordPasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PasswordCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 83 "..\..\..\Windows\ConnectionWindow.xaml"
            this.PasswordCheckBox.Click += new System.Windows.RoutedEventHandler(this.PasswordCheckBox_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.CheckConnectionButton = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Windows\ConnectionWindow.xaml"
            this.CheckConnectionButton.Click += new System.Windows.RoutedEventHandler(this.CheckConnectionButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.AuthorizationButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\Windows\ConnectionWindow.xaml"
            this.AuthorizationButton.Click += new System.Windows.RoutedEventHandler(this.AuthorizationButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\Windows\ConnectionWindow.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

