﻿#pragma checksum "..\..\..\Views\SeriesView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "122E25B6D0E8ACAC72046416F13E6A8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using System.Windows.Interactivity;
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
using TennisTableWPF.Views;


namespace TennisTableWPF.Views {
    
    
    /// <summary>
    /// SeriesView
    /// </summary>
    public partial class SeriesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListeSeries;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IdSerie;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IdSerieLabel;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DenominationSerie;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DenominationLabel;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateSerie;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditSerie;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteSerie;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveSerie;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Views\SeriesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshSerie;
        
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
            System.Uri resourceLocater = new System.Uri("/TennisTableWPF;component/views/seriesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SeriesView.xaml"
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
            this.ListeSeries = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.IdSerie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.IdSerieLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.DenominationSerie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DenominationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.CreateSerie = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.EditSerie = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.DeleteSerie = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.SaveSerie = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.RefreshSerie = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

