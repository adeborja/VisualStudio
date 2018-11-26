using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _15_CRUDPersonasBinding.ViewModels.Converters
{
    class clsConversorFechas :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String fechaEnCadena = "";
            DateTime fecha = (DateTime)value;

            fechaEnCadena = fecha.Day+"/" + fecha.Month + "/" + fecha.Year;

            return fechaEnCadena;



            /*DateTime fecha = (DateTime)value;

            return fecha.ToShortDateString();*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

            String fechaEnCadena = value.ToString();
            String[] fechaDividida = fechaEnCadena.Split("/");
            int anio = Int32.Parse(fechaDividida[2]), mes = Int32.Parse(fechaDividida[1]), dia = Int32.Parse(fechaDividida[0]);

            //y,m,d
            DateTime fecha = new DateTime(anio, mes, dia);

            return fecha;



            /*DateTime resultado;

            DateTime.TryParse((String)value, out resultado);

            return resultado;*/
        }
    }
}
