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
    public sealed partial class index : Page
    {
        public index()
        {
            this.InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            //Comprobar nombre de usuario
            if(txbNombre.Text=="")
            {
                tbkErrorNombre.Text = "El campo Usuario no puede estar vacio";
            }
            else
            {
                tbkErrorNombre.Text = "";
            }

            //Comprobar contraseña
            if (pswBox.Password.ToString()=="")
            {
                tbkErrorContrasena.Text = "El campo Contraseña no puede estar vacio";
            }
            else
            {
                tbkErrorContrasena.Text = "";
            }

            //Simular login
            if (txbNombre.Text != "" && pswBox.Password.ToString() != "")
            {
                if(txbNombre.Text == "Angel" && pswBox.Password.ToString() == "123")
                {
                        this.Frame.Navigate(typeof(splitView));
                }
                else
                {
                    tbkErrorLogin.Text = "El usuario o contraseña introducidos no es valido";
                }
            }
            else
            {
                tbkErrorLogin.Text = "";
            }
        }
    }
}
