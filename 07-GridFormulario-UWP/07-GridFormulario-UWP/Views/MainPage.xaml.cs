using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace _07_GridFormulario_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al boton btnSave
        /// Valida las entradas de texto y manda mensajes de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Declaracion de variables
            Boolean error = false;
            Boolean fechaCorrecta = false;
            Boolean emailCorrecto = false;

            //Validaciones de los distintos campos a rellenar
            if(String.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombreError.Text = "El campo nombre no puede estar vacio";
                error = true;
            }
            else
            {
                txtNombreError.Text = "";
            }

            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                txtApellidoError.Text = "El campo apellidos no puede estar vacio";
                error = true;
            }
            else
            {
                txtApellidoError.Text = "";
            }

            if (String.IsNullOrEmpty(txtFecha.Text))
            {
                txtFechaError.Text = "El campo fecha no puede estar vacio";
                error = true;
            }
            else
            {
                fechaCorrecta = validaFecha(txtFecha.Text.ToString());

                if(!fechaCorrecta)
                {
                    txtFechaError.Text = "La fecha introducida no es correcta";
                    error = true;
                }
                else
                {
                    txtFechaError.Text = "";
                }
            }

            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmailError.Text = "El campo email no puede estar vacio";
                error = true;
            }
            else
            {
                emailCorrecto = validarEmail(txtEmail.Text.ToString());

                if (!emailCorrecto)
                {
                    txtEmailError.Text = "El email introducido no es correcto";
                    error = true;
                }
                else
                {
                    txtEmailError.Text = "";
                }
            }

            if (error)
                txtCorrecto.Text = "";
            else
                txtCorrecto.Text = "Informacion correcta";
        }
        
        /// <summary>
        /// Metodo para validar si una fecha es correcta
        /// </summary>
        /// <param name="s">El string con la fecha a validar</param>
        /// <returns> True si la fecha es valida o false si no lo es</returns>
        public Boolean validaFecha(String s)
        {
            Boolean esCorrecto = false;
            DateTime temp;

            /*try
            {
                DateTime.Parse(s);
                
                esCorrecto = true;
            }
            catch(Exception e)
            {
                esCorrecto = false;
            }*/

            esCorrecto = DateTime.TryParse(s,out temp);

            return esCorrecto;
        }

        public Boolean validarEmail(String s)
        {
            Boolean esCorrecto = false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(s);

            esCorrecto = match.Success;

            return esCorrecto;
        }
    }
}
