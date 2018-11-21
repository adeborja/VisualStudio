using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasEnCartas.Models.Entidades
{
    public class clsCarta : clsVMBase
    {
        #region propiedades privadas

        private bool _esBomba;
        private Uri _imagen;
        private bool _haSidoPulsada;
        private int _id;

        #endregion

        #region atributos y propiedades

        public bool esBomba
        {
            get
            {
                return _esBomba;
            }

            set
            {
                _esBomba = value;
                NotifyPropertyChanged("esBomba");
            }
        }
        public Uri imagen
        {
            get
            {
                return _imagen;
            }

            set
            {
                _imagen = value;
                NotifyPropertyChanged("imagen");
            }
        }
        public bool haSidoPulsada
        {
            get
            {
                return _haSidoPulsada;
            }

            set
            {
                _haSidoPulsada = value;
                NotifyPropertyChanged("haSidoPulsada");
            }
        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged("id");
            }
        }

        #endregion

        #region constructor por defecto

        public clsCarta()
        {
            esBomba = false;
            imagen = null;
            haSidoPulsada = false;
            id = 0;
        }

        #endregion
    }
}
