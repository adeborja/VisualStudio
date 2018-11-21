using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaLoL_Entidades.Persistencia;
using ListaLoL_BL.Listados;

namespace _16_ListaLoL_UI.ViewModels
{
    class miViewModelLoL : clsVMBase
    {

        #region propiedades privadas

        private List<clsCategoria> _listadoCompletoCategorias;
        private List<clsPersonaje> _listadoPersonajes;
        private clsPersonaje _personajeSeleccionado;
        private List<clsPersonaje> _listadoCompletoPersonajes;
        private int _categoriaSeleccionada;

        private String _imagenRetrato;
        private String _gridVisibilidad;

        private DelegateCommand _buscarPersonajesPorCategoriaCommand;

        #endregion

        #region propiedades publicas

        public List<clsCategoria> listadoCompletoCategorias
        {
            get
            {
                return _listadoCompletoCategorias;
            }

            set
            {
                _listadoCompletoCategorias = value;
            }
        }

        public List<clsPersonaje> listadoPersonajes
        {
            get
            {
                return _listadoPersonajes;
            }

            set
            {
                _listadoPersonajes = value;
                NotifyPropertyChanged(); //TODO
            }
        }

        public clsPersonaje personajeSeleccionado
        {
            get
            {
                return _personajeSeleccionado;
            }

            set
            {
                _personajeSeleccionado = value;
                NotifyPropertyChanged("personajeSeleccionado"); //TODO
                if(_personajeSeleccionado!=null)
                {
                    _imagenRetrato = "Assets/Retratos/" + _personajeSeleccionado.nombre + ".png";
                    NotifyPropertyChanged("imagenRetrato");
                    _gridVisibilidad = "Visible";
                    NotifyPropertyChanged("gridVisibilidad");
                }
            }
        }

        public int categoriaSeleccionada
        {
            get
            {
                return _categoriaSeleccionada;
            }

            set
            {
                _categoriaSeleccionada = value;
            }
        }

        public String imagenRetrato
        {
            get
            {
                return _imagenRetrato;
            }

            set
            {
                _imagenRetrato = value;
                NotifyPropertyChanged("imagenRetrato");
            }
        }

        public String gridVisibilidad
        {
            get
            {
                return _gridVisibilidad;
            }

            set
            {
                _gridVisibilidad = value;
                NotifyPropertyChanged("gridVisibilidad");
            }
        }

        #endregion

        #region constructor por defecto

        public miViewModelLoL()
        {
            clsListadoCategorias_BL listadoCategorias_BL = new clsListadoCategorias_BL();
            clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();

            _listadoCompletoCategorias = listadoCategorias_BL.listadoCompletoCategorias_BL();
            _listadoCompletoPersonajes = listadoPersonajes_BL.listadoCompletoPersonajes_BL();
            //_listadoPersonajes = null;
            _listadoPersonajes = listadoPersonajes_BL.listadoCompletoPersonajes_BL();
            _personajeSeleccionado = null;
            _gridVisibilidad = "Collapsed";
        }

        #endregion

        #region buscarPersonajesPorCategoria

        public DelegateCommand buscarPersonajesPorCategoriaCommand
        {
            get
            {
                _buscarPersonajesPorCategoriaCommand = new DelegateCommand(buscarPersonajesPorCategoriaCommand_Executed);
                return _buscarPersonajesPorCategoriaCommand;
            }
        }

        private void buscarPersonajesPorCategoriaCommand_Executed()
        {
            _listadoPersonajes = new List<clsPersonaje>();
            _listadoPersonajes = _listadoCompletoPersonajes.Where(personaje => personaje.idCategoria.Equals(_categoriaSeleccionada)).ToList(); //falta por bindear categoria seleccionada en el xaml
            NotifyPropertyChanged("listadoPersonajes");
            _gridVisibilidad = "Collapsed";
            NotifyPropertyChanged("gridVisibilidad");
        }

        #endregion


    }
}
