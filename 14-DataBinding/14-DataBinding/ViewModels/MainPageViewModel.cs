using _14_DataBinding.Models.DAL;
using _14_DataBinding.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_DataBinding.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region propiedades privadas

        private List<clsPersona> _listadoDePersonas;
        private clsPersona _personaSeleccionada;
        private List<clsDepartamento> _listadoDepartamentos;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region propiedades publicas

        public List<clsPersona> listadoDePersonas
        {
            get
            {
                return _listadoDePersonas;
            }

            set
            {
                _listadoDePersonas = value;
            }
        }

        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }

            set
            {
                _personaSeleccionada = value;
                OnPropertyChanged("personaSeleccionada");
            }
        }

        public List<clsDepartamento> listadoDepartamentos
        {
            get
            {
                return _listadoDepartamentos;
            }

            set
            {
                _listadoDepartamentos = value;
            }
        }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
     


        #region constructor por defecto

        public MainPageViewModel()
        {
            //Cargar el listado de personas
            _listadoDePersonas = clsListadoPersonas.getListado();
        }

        #endregion
    }
}
