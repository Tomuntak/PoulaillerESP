﻿#pragma checksum "..\..\..\View\uc_config.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1CEA193FBF4D6989C890C3FEC178A6FB6F01B273F963E7AD1549D6FDA020781E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using PoulaillerMaquette.View;
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


namespace PoulaillerMaquette.View {
    
    
    /// <summary>
    /// uc_config
    /// </summary>
    public partial class uc_config : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_ConfPoule;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LBL_nom;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LBL_Poids;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LBL_Arriv;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LBL_Sort;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_DelPoule;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_AddPoule;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\uc_config.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_AltPoule;
        
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
            System.Uri resourceLocater = new System.Uri("/PoulaillerMaquette;component/view/uc_config.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\uc_config.xaml"
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
            this.BTN_ConfPoule = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\View\uc_config.xaml"
            this.BTN_ConfPoule.Click += new System.Windows.RoutedEventHandler(this.BTN_ConfPoule_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LBL_nom = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LBL_Poids = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LBL_Arriv = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.LBL_Sort = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.BTN_DelPoule = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\View\uc_config.xaml"
            this.BTN_DelPoule.Click += new System.Windows.RoutedEventHandler(this.BTN_DelPoule_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BTN_AddPoule = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\View\uc_config.xaml"
            this.BTN_AddPoule.Click += new System.Windows.RoutedEventHandler(this.BTN_AddPoule_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BTN_AltPoule = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\View\uc_config.xaml"
            this.BTN_AltPoule.Click += new System.Windows.RoutedEventHandler(this.BTN_AltPoule_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

