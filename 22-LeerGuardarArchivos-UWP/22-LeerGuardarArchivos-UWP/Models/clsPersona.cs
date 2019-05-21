using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
//using System.Runtime.Serialization.Formatters.Binary;

namespace _15_CRUDPersonasBinding_Entidades
{
    //https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute?view=netframework-4.8
    [Serializable()]
    public class clsPersona
    {
        #region constructor por defecto

        public clsPersona()
        {
            
        }

        #endregion

        #region constructor por parametros

        public clsPersona(String nNombre, String nApellido)
        {
            this.nombre = nNombre;
            this.apellidos = nApellido;
        }

        #endregion


        #region atributos y propiedades
        
        public String nombre { get; set; }
        public String apellidos { get; set; }


        #endregion
    }
}