﻿#pragma checksum "D:\Github Angel\VisualStudio\09-Controles-UWP\09-Controles-UWP\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FB424854DDB134C4C08B70BE6F3F9650"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _09_Controles_UWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 53
                {
                    this.btnTooltip1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 3: // MainPage.xaml line 78
                {
                    this.pvtPivotMaster = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                }
                break;
            case 4: // MainPage.xaml line 166
                {
                    this.slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 5: // MainPage.xaml line 201
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Button_Click;
                }
                break;
            case 6: // MainPage.xaml line 122
                {
                    this.txbChequearPalabra = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // MainPage.xaml line 44
                {
                    this.rbNo = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 8: // MainPage.xaml line 45
                {
                    this.rbAlomojo = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 9: // MainPage.xaml line 46
                {
                    this.btnRadioButtons = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
