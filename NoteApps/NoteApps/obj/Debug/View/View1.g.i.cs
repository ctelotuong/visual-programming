﻿#pragma checksum "..\..\..\View\View1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4E8A262B6124C192A00141E186754AFBFA801CD6A8410976D51414A326276664"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace NoteApps.View {
    
    
    /// <summary>
    /// View1
    /// </summary>
    public partial class View1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton boldButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ItalicButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton UnderlineButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Strikethrough;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox fontFamilyComboBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox fontSizeComboBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\View1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveFileButton;
        
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
            System.Uri resourceLocater = new System.Uri("/NoteApps;component/view/view1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\View1.xaml"
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
            
            #line 12 "..\..\..\View\View1.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.boldButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 15 "..\..\..\View\View1.xaml"
            this.boldButton.Click += new System.Windows.RoutedEventHandler(this.boldButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ItalicButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 20 "..\..\..\View\View1.xaml"
            this.ItalicButton.Click += new System.Windows.RoutedEventHandler(this.ItalicButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UnderlineButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 26 "..\..\..\View\View1.xaml"
            this.UnderlineButton.Click += new System.Windows.RoutedEventHandler(this.UnderlineButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Strikethrough = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 32 "..\..\..\View\View1.xaml"
            this.Strikethrough.Click += new System.Windows.RoutedEventHandler(this.Strikethrough_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.fontFamilyComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\View\View1.xaml"
            this.fontFamilyComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.fontFamilyComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.fontSizeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\..\View\View1.xaml"
            this.fontSizeComboBox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.fontSizeComboBox_TextChanged));
            
            #line default
            #line hidden
            return;
            case 8:
            this.SaveFileButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\View\View1.xaml"
            this.SaveFileButton.Click += new System.Windows.RoutedEventHandler(this.SaveFileButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

