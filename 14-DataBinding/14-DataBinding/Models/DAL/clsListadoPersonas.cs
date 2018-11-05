using _14_DataBinding.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_DataBinding.Models.DAL
{
    /// <summary>
    /// Metodo que construirá una lista de personas para devolverlo
    /// </summary>
    public class clsListadoPersonas
    {
        /// <summary>
        /// Metodo que introduce personas en una lista
        /// </summary>
        /// <returns>una lista con objetos persona</returns>
        public static List<clsPersona> getListado()
        {
            List<clsPersona> listado = new List<clsPersona>();

            listado.Add(new clsPersona(0, "Angel David", "de Borja", new DateTime(1987,8,11), "Calle de mi casa X", "954459123", 1));
            listado.Add(new clsPersona(1, "Menga", "Nito", new DateTime(1999, 9, 9), "Calle Falsa 9", "954999999", 2));
            listado.Add(new clsPersona(2, "Pepe", "Pinazo", new DateTime(2001, 9, 11), "Calle Antigua s/n", "555-4785", 3));

            return listado;
        }

        //public void pintarListaPersonas(List<clsPersona> lista)
        //{
        //    foreach()
        //}
    }
}