﻿#pragma checksum "..\..\..\LearningWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1327CDB269E742C2FFF9FC5BAE941D75"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
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


namespace SATAppRafiqul {
    
    
    /// <summary>
    /// LearningWindow
    /// </summary>
    public partial class LearningWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\LearningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Home;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\LearningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Exit2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\LearningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Next;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\LearningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Answer;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\LearningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtbx_vc;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\LearningWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Previous;
        
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
            System.Uri resourceLocater = new System.Uri("/SATAppRafiqul;component/learningwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LearningWindow.xaml"
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
            this.Btn_Home = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\LearningWindow.xaml"
            this.Btn_Home.Click += new System.Windows.RoutedEventHandler(this.Btn_Back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Btn_Exit2 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\LearningWindow.xaml"
            this.Btn_Exit2.Click += new System.Windows.RoutedEventHandler(this.Btn_Exit2_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Btn_Next = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\LearningWindow.xaml"
            this.Btn_Next.Click += new System.Windows.RoutedEventHandler(this.Btn_Next_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btn_Answer = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\LearningWindow.xaml"
            this.Btn_Answer.Click += new System.Windows.RoutedEventHandler(this.Btn_Answer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtbx_vc = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Btn_Previous = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\LearningWindow.xaml"
            this.Btn_Previous.Click += new System.Windows.RoutedEventHandler(this.Btn_Previous_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

