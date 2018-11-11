using _15_CRUDPersonasBinding_BL.Listados;
using _15_CRUDPersonasBinding_BL.Manejadoras;
using _15_CRUDPersonasBinding_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonasBinding_UI.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region propiedades privadas

        private List<clsPersona> _listadoDePersonas;
        private clsPersona _personaSeleccionada;
        private List<clsDepartamento> _listadoDepartamentos;
        private clsDepartamento _departamentoSeleccionado;

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

        public clsDepartamento departamentoSeleccionado
        {
            get
            {
                return _departamentoSeleccionado;
            }
            set
            {
                _departamentoSeleccionado = value;
                OnPropertyChanged("departamentoSeleccionado");
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
            clsListadoPersonas_BL listadoPersonas = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL listadoDepartamentos = new clsListadoDepartamentos_BL();

            //Cargar el listado de personas
            _listadoDePersonas = listadoPersonas.listadoCompletoPersonas_BL();

            _listadoDepartamentos = listadoDepartamentos.listadoCompletoPersonas_BL();
        }

        #endregion

        public int guardarPersonaEditada()
        {
            int filasAfectadas = -1;
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();

            //if (o.GetType() == typeof(clsPersona))
            //{
            //    clsPersona p = (clsPersona)o;

            //    filasAfectadas = manejadora.editarPersona_BL(o);
            //}

            //filasAfectadas = manejadora.editarPersona_BL(personaSeleccionada);

            

            return filasAfectadas;
        }
    }
}
