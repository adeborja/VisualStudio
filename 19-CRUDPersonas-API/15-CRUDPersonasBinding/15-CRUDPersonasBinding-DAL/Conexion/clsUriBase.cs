using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonasBinding_DAL.Conexion
{
    public class clsUriBase
    {
        /// <summary>
        /// Devuelve un string con la url de la api
        /// </summary>
        /// <returns>Un string con la uri de la api</returns>
        public String getUriBase()
        {

            String uri = "https://angelapirestpersonas.azurewebsites.net/api/";

            return uri;
        }
    }
}
