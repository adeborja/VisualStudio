using _12_HamburgerHeavenChallenge.Views;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _12_HamburgerHeavenChallenge
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            frmSplitView.Navigate(typeof(Financial));
            txbNombreVentana.Text = "Financial";
        }

        private void HamburgerMenu_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void lbxBotones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners/UWP-021-Implementing-a-Simple-Hamburger-Navigation-Menu
            

            if (lbiHome.IsSelected)
            {
                txbNombreVentana.Text = "Financial";
                frmSplitView.Navigate(typeof(Financial));
                ElGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
            }
            else if (lbiFavorites.IsSelected)
            {
                txbNombreVentana.Text = "Favorites";
                frmSplitView.Navigate(typeof(Favorites));
                //columnaFlecha.Width = (GridLength)20;
                ElGrid.ColumnDefinitions[0].Width = new GridLength(40, GridUnitType.Pixel);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //https://docs.microsoft.com/en-us/windows/uwp/design/basics/navigation-history-and-backwards-navigation#system-back-behavior-for-backward-compatibilities

            if (frmSplitView.CanGoBack)
            {
                frmSplitView.GoBack();
            }
        }
    }
}
