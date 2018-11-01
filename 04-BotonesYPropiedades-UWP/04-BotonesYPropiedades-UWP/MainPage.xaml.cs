using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _04_BotonesYPropiedades_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            createButton();
        }

        private void createButton()
        {
            Button boton3 = new Button { Content = "Boton3" };
            stkpnlListaBotones.Children.Add(boton3);

            boton3.Height = 70;
            boton3.Width = 200;
            boton3.Margin = new Thickness(10);
            boton3.Foreground = new SolidColorBrush(Colors.White);
            boton3.Background = new SolidColorBrush(Colors.Gray);
            //boton3.


            //Añade un evento onclick al elemento
            boton3.Click += boton3_click;
        }


        private async void boton3_click(object sender, RoutedEventArgs args)
        {
            /*
            MessageDialog mensaje = new MessageDialog("tecsto");

            mensaje.Commands.Add(new UICommand);
            //por terminar*/


            //https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/buttons
            ContentDialog dialogo = new ContentDialog
            {
                Title = "Boton 3",
                Content = "Has apretado el boton 3",
                CloseButtonText = "Cierra esto",
                PrimaryButtonText = "Lo se",
                SecondaryButtonText = "Po si"

            };

            ContentDialogResult resultado = await dialogo.ShowAsync();

        }
    }
}
