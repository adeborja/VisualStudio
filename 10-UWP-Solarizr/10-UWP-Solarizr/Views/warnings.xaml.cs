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
    public sealed partial class warnings : Page
    {
        public warnings()
        {
            this.InitializeComponent();
        }

        #region Acciones de botones del splitview

        //boton expandir listview
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menuSplitView.IsPaneOpen = !menuSplitView.IsPaneOpen;
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
    }
}
