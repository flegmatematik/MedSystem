﻿#pragma checksum "..\..\..\Objednavka\ShowObjednavky - Copy.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F520E2D490F3B18CF214FC98F9D45F2B5DF00A727EB56CB61EA587537DB0A258"
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
using UIMedSystem.Objednavka;


namespace UIMedSystem.Objednavka {
    
    
    /// <summary>
    /// ShowObjednavky
    /// </summary>
    public partial class ShowObjednavky : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GreetBlock;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ListedAppsLabel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListedApps;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NonAppsLabel;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView NonListedApps;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PastAppsLabel;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PastApps;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorBox;
        
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
            System.Uri resourceLocater = new System.Uri("/UIMedSystem;component/objednavka/showobjednavky%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Objednavka\ShowObjednavky - Copy.xaml"
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
            this.GreetBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ListedAppsLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ListedApps = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.NonAppsLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.NonListedApps = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.PastAppsLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.PastApps = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.ErrorBox = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

