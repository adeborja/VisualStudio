using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01___HelloWorld_WindowsForms_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaludar_Click(object sender, EventArgs e)
        {
            string nombre;

            nombre = this.txtNombre.Text;

            //MessageBox.Show("Hola " + nombre);
            //MessageBox.Show($"Hola {nombre}");
            //MessageBox.Show(string.Format("Hola {0}", nombre));

            clsPersona oPersona = new clsPersona();
            oPersona.nombre = "Angel";
            oPersona.apellido = "Gel";

            MessageBox.Show($"Hola, soy el objeto {oPersona.nombre} {oPersona.apellido}");

        }
    }
}
