﻿#pragma checksum "..\..\..\MenuM.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6F58E44572C0550DDBC9FDE83A79DE7692F04CEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using ManuelitoWpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ManuelitoWpf {
    
    
    /// <summary>
    /// MenuM
    /// </summary>
    public partial class MenuM : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\MenuM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Gioca;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\MenuM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_regole;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MenuM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Classifica;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MenuM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_nome;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MenuM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_inserisciNome;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MenuM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Impostazioni;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.18.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ManuelitoWpf;V1.0.0.0;component/menum.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MenuM.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.18.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_Gioca = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\MenuM.xaml"
            this.btn_Gioca.Click += new System.Windows.RoutedEventHandler(this.btn_Gioca_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_regole = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\MenuM.xaml"
            this.btn_regole.Click += new System.Windows.RoutedEventHandler(this.btn_regole_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_Classifica = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\MenuM.xaml"
            this.btn_Classifica.Click += new System.Windows.RoutedEventHandler(this.btn_Classifica_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txb_nome = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\MenuM.xaml"
            this.txb_nome.GotFocus += new System.Windows.RoutedEventHandler(this.SvuotaTextBox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbl_inserisciNome = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btn_Impostazioni = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\MenuM.xaml"
            this.btn_Impostazioni.Click += new System.Windows.RoutedEventHandler(this.btn_Impostazioni_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

