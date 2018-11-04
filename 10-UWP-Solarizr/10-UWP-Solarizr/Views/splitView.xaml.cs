using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _10_UWP_Solarizr.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class splitView : Page
    {
        public splitView()
        {
            this.InitializeComponent();
        }

        #region Acciones de botones del splitview

        //boton expandir listview
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        //boton home
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(home));
        }

        //boton mensajes
        private void btnMensajes_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(messages));
        }

        //boton avisos
        private void btnAvisos_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(warnings));
        }

        //boton contactos
        private void btnContactos_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(contact));
        }

        #endregion

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeListBoxItem.IsSelected)
            {
                //ResultTextBlock.Text = "Home";
                btnHome_Click(sender, e);
            }
            else
            {
                if (MensaggesListBoxItem.IsSelected)
                {
                    //ResultTextBlock.Text = "Mensajes";
                    btnMensajes_Click(sender, e);
                }
                else
                {
                    if (WarningListBoxItem.IsSelected)
                    {
                        //ResultTextBlock.Text = "Alertas";
                        btnAvisos_Click(sender, e);
                    }
                    else
                    {
                        if (ContactListBoxItem.IsSelected)
                        {
                            //ResultTextBlock.Text = "Contacto";
                            btnContactos_Click(sender, e);
                        }
                    }
                }
            }
        }
    }
}

