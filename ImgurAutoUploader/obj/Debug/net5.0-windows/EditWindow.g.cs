#pragma checksum "..\..\..\EditWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF464D22B32577E51CF7AA00EA9135DC1EF04854"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using ImgurAutoUploader;
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


namespace ImgurAutoUploader {
    
    
    /// <summary>
    /// EditWindow
    /// </summary>
    public partial class EditWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox viewBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.InkCanvas inkCanvas;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Ink.DrawingAttributes attribute;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar UploadProgressBar;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SecretButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ImgurAutoUploader;component/editwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\EditWindow.xaml"
            ((ImgurAutoUploader.EditWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.viewBox = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 3:
            this.inkCanvas = ((System.Windows.Controls.InkCanvas)(target));
            
            #line 17 "..\..\..\EditWindow.xaml"
            this.inkCanvas.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.InkCanvas_PreviewMouseWheel);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\EditWindow.xaml"
            this.inkCanvas.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.InkCanvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\EditWindow.xaml"
            this.inkCanvas.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.InkCanvas_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\EditWindow.xaml"
            this.inkCanvas.PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.InkCanvas_PreviewMouseRightButtonDown);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\EditWindow.xaml"
            this.inkCanvas.PreviewMouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.InkCanvas_PreviewMouseRightButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.attribute = ((System.Windows.Ink.DrawingAttributes)(target));
            return;
            case 5:
            this.UploadProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 6:
            this.SecretButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\EditWindow.xaml"
            this.SecretButton.Click += new System.Windows.RoutedEventHandler(this.UploadButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UploadButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\EditWindow.xaml"
            this.UploadButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

