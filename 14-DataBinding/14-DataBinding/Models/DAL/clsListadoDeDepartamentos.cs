using _14_DataBinding.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_DataBinding.Models.DAL
{
    public class clsListadoDeDepartamentos
    {
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            lista.Add(new clsDepartamento(1, "Imagen"));
            lista.Add(new clsDepartamento(2, "Sonido"));
            lista.Add(new clsDepartamento(3, "Electronica"));
            lista.Add(new clsDepartamento(4, "Accesorios"));


            return lista;
        }
    }
}