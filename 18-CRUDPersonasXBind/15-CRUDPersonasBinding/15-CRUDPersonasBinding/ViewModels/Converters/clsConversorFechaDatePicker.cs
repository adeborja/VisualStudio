﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _15_CRUDPersonasBinding.ViewModels.Converters
{
    class clsConversorFechaDatePicker : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = (DateTime)value;
            DateTimeOffset fechaDevuelta = new DateTimeOffset(fecha);

            return fechaDevuelta;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset fechaOffSet = (DateTimeOffset)value;
            DateTime fecha = fechaOffSet.DateTime;

            return fecha;
        }
    }
}
