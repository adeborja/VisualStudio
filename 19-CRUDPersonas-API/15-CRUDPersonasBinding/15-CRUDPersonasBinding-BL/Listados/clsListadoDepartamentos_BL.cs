using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15_CRUDPersonasBinding_DAL.Listados;
using _15_CRUDPersonasBinding_Entidades;

namespace _15_CRUDPersonasBinding_BL.Listados
{
    public class clsListadoDepartamentos_BL
    {
        public List<clsDepartamento> listadoCompletoPersonas_BL()
        {
            List<clsDepartamento> lista = new List<clsDepartamento>();

            //instanciar un objeto
            clsListadoDepartamentos_DAL objeto = new clsListadoDepartamentos_DAL();

            lista = objeto.listadoCompletoDepartamentos_DAL();

            return lista;
        }
    }
}
