﻿#pragma checksum "..\..\OrderCtrl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03B0AF5131E142019CEE11FA868D72F39F488695"
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
using _2019CSharp;


namespace _2019CSharp {
    
    
    /// <summary>
    /// OrderCtrl
    /// </summary>
    public partial class OrderCtrl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 48 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrderBtn;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bord;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid check;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid pay;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid com;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvFood;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TableId;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvSelectFood;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\OrderCtrl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalPrice;
        
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
            System.Uri resourceLocater = new System.Uri("/2019CSharp;component/orderctrl.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderCtrl.xaml"
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
            this.OrderBtn = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\OrderCtrl.xaml"
            this.OrderBtn.Click += new System.Windows.RoutedEventHandler(this.OrderBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bord = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.check = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            
            #line 61 "..\..\OrderCtrl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.show_pay);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 62 "..\..\OrderCtrl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.show_check);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pay = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            
            #line 66 "..\..\OrderCtrl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.show_complete);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 67 "..\..\OrderCtrl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.show_pay);
            
            #line default
            #line hidden
            return;
            case 9:
            this.com = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.listBox = ((System.Windows.Controls.ListView)(target));
            
            #line 82 "..\..\OrderCtrl.xaml"
            this.listBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lvFood = ((System.Windows.Controls.ListView)(target));
            
            #line 95 "..\..\OrderCtrl.xaml"
            this.lvFood.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LvFood_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.TableId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.lvSelectFood = ((System.Windows.Controls.ListView)(target));
            return;
            case 15:
            this.TotalPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            
            #line 160 "..\..\OrderCtrl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.show_check);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 14:
            
            #line 151 "..\..\OrderCtrl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnMinus_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

