using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_DataBinding.Models.Entidades
{
    public class clsDepartamento
    {
        


        #region constructor por defecto
        public clsDepartamento()
        {

        }
        #endregion

        #region constructor por parametros
        public clsDepartamento(int id, String nombre)
        {
            this.idDepartamento = id;
            this.nombreDepartamento = nombre;
        }
        #endregion

        #region declaracion de atributos y propiedades
        public int idDepartamento { set; get; }
        public String nombreDepartamento { set; get; }
        #endregion

    }
}