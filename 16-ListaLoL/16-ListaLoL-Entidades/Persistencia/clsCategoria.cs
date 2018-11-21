using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLoL_Entidades.Persistencia
{
    public class clsCategoria
    {
        #region constructor por defecto

        public clsCategoria()
        {

        }

        #endregion

        #region constructor por parametros

        public clsCategoria(int nId, String nNombre)
        {
            this.idCategoria = nId;
            this.nombreCategoria = nNombre;
        }

        #endregion


        #region atributos y propiedades

        public int idCategoria { get; set; }
        public String nombreCategoria { get; set; }

        #endregion

    }
}
