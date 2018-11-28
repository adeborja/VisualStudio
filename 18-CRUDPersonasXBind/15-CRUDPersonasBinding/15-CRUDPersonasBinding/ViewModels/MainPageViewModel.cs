using _15_CRUDPersonasBinding_BL.Listados;
using _15_CRUDPersonasBinding_BL.Manejadoras;
using _15_CRUDPersonasBinding_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _15_CRUDPersonasBinding_UI.ViewModels
{
    public class MainPageViewModel : clsVMBase
    {
        #region propiedades privadas

        private List<clsPersona> _listadoDePersonas;
        private clsPersona _personaSeleccionada;
        private List<clsDepartamento> _listadoDepartamentos;
        private clsDepartamento _departamentoSeleccionado;

        private DelegateCommand _eliminarCommand;
        private DelegateCommand _actualizarListadoCommand;
        private DelegateCommand _anadirNuevoCommand;
        private DelegateCommand _guardarPersonaCommand;

        private List<clsPersona> _listadoDePersonasBusqueda;
        private String _textoBusqueda;
        private DelegateCommand _rellenarListadoBusquedaCommand;

        //private String _listadoDePersonasVisible;
        //private String _listadoDePersonasBusquedaVisible;

        //public event PropertyChangedEventHandler PropertyChanged;

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
                //Evitar stackoverflow
                if(_personaSeleccionada!=value)
                {
                    _personaSeleccionada = value;

                    //Llamamos a CanExecute de eliminar para que compruebe si habilita el comando
                    _eliminarCommand.RaiseCanExecuteChanged();
                    _guardarPersonaCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("personaSeleccionada");
                }

                //_personaSeleccionada = value;

                ////Llamamos a CanExecute de eliminar para que compruebe si habilita el comando
                //_eliminarCommand.RaiseCanExecuteChanged();
                //_guardarPersonaCommand.RaiseCanExecuteChanged();
                //NotifyPropertyChanged("personaSeleccionada");
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
                //NotifyPropertyChanged("departamentoSeleccionado");
            }
        }

        #region eliminarCommand

        public DelegateCommand eliminarCommand
        {
            get
            {
                _eliminarCommand = new DelegateCommand(eliminarCommand_Executed, eliminarCommand_CanExecute);
                return _eliminarCommand;
            }
        }

        
        /// <summary>
        /// Funcion para eliminar una persona de la base de datos
        /// </summary>
        //private void eliminarCommand_Executed()
        //{
        //    //Instanciar un objeto de la manejadora de la capa BL
        //    clsManejadoraPersona_BL manejadoraBL = new clsManejadoraPersona_BL();

        //    try //Vamos a llamar a la base de datos
        //    {
        //        manejadoraBL.borrarPersonaPorID_BL(personaSeleccionada.idPersona);
        //    }
        //    catch (Exception e)
        //    {
        //        //TODO lanzar un dialogo con error
        //    }
        //}



        private async void eliminarCommand_Executed()
        {
            int filasAfectadas = -1;
            clsManejadoraPersona_BL manejadoraBL = new clsManejadoraPersona_BL();
            ContentDialog confirmarBorrado = new ContentDialog();
            ContentDialog seHaBorrado = new ContentDialog();
            ContentDialogResult resultado;

            //Definir las propiedades del popup
            confirmarBorrado.Title = "Eliminar";
            confirmarBorrado.Content = "¿¡Estas seguro de querer borrar a esta persona!?";
            confirmarBorrado.PrimaryButtonText = "Cancelar";
            confirmarBorrado.SecondaryButtonText = "Aceptar";

            resultado = await confirmarBorrado.ShowAsync();
            if(resultado == ContentDialogResult.Secondary)
            {
                try
                {
                    filasAfectadas = manejadoraBL.borrarPersonaPorID_BL(personaSeleccionada.idPersona);

                    //Actualizamos la lista de personas
                    //clsListadoPersonas_BL listadoPersonas = new clsListadoPersonas_BL();

                    //Cargar el listado de personas
                    //_listadoDePersonas = listadoPersonas.listadoCompletoPersonas_BL();
                    //NotifyPropertyChanged("listadoDePersonas"); //propiedad en linea 30
                    actualizarListadoCommand_Executed();

                    seHaBorrado.Content = "La persona ha sido borrada";
                    seHaBorrado.PrimaryButtonText = "Aceptar";
                    await seHaBorrado.ShowAsync();

                }
                catch(Exception e)
                {
                    confirmarBorrado.Title = "Error";
                    confirmarBorrado.Content = "Se ha producido un error";
                    confirmarBorrado.PrimaryButtonText = "Aceptar";
                    await confirmarBorrado.ShowAsync();
                }
            }
        }


        /// <summary>
        /// Funcion que devuelve un logico para habilitar o deshabilitar los controles bindeados al comando eliminar
        /// </summary>
        /// <returns></returns>
        private bool eliminarCommand_CanExecute()
        {
            bool sePuedeEliminar = false;

            if(personaSeleccionada!=null)
            {
                sePuedeEliminar = true;
            }

            return sePuedeEliminar;
        }

        #endregion

        #region actualizarListadoCommand

        public DelegateCommand actualizarListadoCommand
        {
            get
            {
                _actualizarListadoCommand = new DelegateCommand(actualizarListadoCommand_Executed);
                return _actualizarListadoCommand;
            }
        }

        private void actualizarListadoCommand_Executed()
        {
            //Actualizamos la lista de personas
            clsListadoPersonas_BL listadoPersonas = new clsListadoPersonas_BL();

            //Cargar el listado de personas
            _listadoDePersonas = listadoPersonas.listadoCompletoPersonas_BL();
            NotifyPropertyChanged("listadoDePersonas"); //propiedad en linea 30

            //myAppBarButton.ClearValue(AppBarButton.IsEnabledProperty) para limpiar el estado de las appbarbutton, pero tiene que se en OnNavigatedTo()
        }

        #endregion

        #region guardarPersonaCommand

        public DelegateCommand guardarPersonaCommand
        {
            get
            {
                _guardarPersonaCommand = new DelegateCommand(guardarPersonaCommand_Executed, guardarPersonaCommand_CanExecute);
                return _guardarPersonaCommand;
            }
        }

        /// <summary>
        /// Funcion que devuelve un logico para habilitar o deshabilitar los controles bindeados al comando guardar
        /// </summary>
        /// <returns></returns>
        private bool guardarPersonaCommand_CanExecute()
        {
            bool sePuedeEliminar = false;

            if (personaSeleccionada != null)
            {
                sePuedeEliminar = true;
            }

            return sePuedeEliminar;
        }

        private async void guardarPersonaCommand_Executed()
        {
            int filasAfectadas = - 1;
            clsManejadoraPersona_BL manejadoraBL = new clsManejadoraPersona_BL();
            ContentDialog mensajePopUp = new ContentDialog();

            try
            {
                if(personaSeleccionada.idPersona==0)
                {
                    filasAfectadas = manejadoraBL.crearPersona_BL(personaSeleccionada);

                    //actualizarListadoCommand_Executed();

                    if (filasAfectadas == 1)
                    {
                        //actualizarListadoCommand_Executed();

                        mensajePopUp.Title = "Creacion exitosa";
                        mensajePopUp.Content = "La persona ha sido creada correctamente";
                        mensajePopUp.PrimaryButtonText = "Aceptar";
                    }
                    else
                    {
                        //actualizarListadoCommand_Executed();

                        mensajePopUp.Title = "Creacion fallida";
                        mensajePopUp.Content = "La persona no ha podido ser creada";
                        mensajePopUp.PrimaryButtonText = "Aceptar :(";
                    }
                }
                else
                {
                    filasAfectadas = manejadoraBL.editarPersona_BL(personaSeleccionada);

                    //actualizarListadoCommand_Executed();

                    if (filasAfectadas == 1)
                    {
                        mensajePopUp.Title = "Creacion exitosa";
                        mensajePopUp.Content = "La persona ha sido editada correctamente";
                        mensajePopUp.PrimaryButtonText = "Aceptar";
                    }
                    else
                    {
                        mensajePopUp.Title = "Creacion fallida";
                        mensajePopUp.Content = "La persona no ha podido ser creada";
                        mensajePopUp.PrimaryButtonText = "Aceptar :(";
                    }
                }

                actualizarListadoCommand_Executed();

                await mensajePopUp.ShowAsync();

                
            }
            catch(Exception e)
            {
                mensajePopUp.Title = "Error";
                mensajePopUp.Content = "Se ha producido un error";
                mensajePopUp.PrimaryButtonText = "Aceptar";
                await mensajePopUp.ShowAsync();
            }
        }

        #endregion

        #region anadirNuevoCommand

        public DelegateCommand anadirNuevoCommand
        {
            get
            {
                _anadirNuevoCommand = new DelegateCommand(anadirNuevoCommand_Execute);
                return _anadirNuevoCommand;
            }
        }

        private void anadirNuevoCommand_Execute()
        {
            personaSeleccionada = new clsPersona();
        }

        #endregion


        #endregion

        //Al implementar la clase clsVMBase no es necesario utilizar INotifytaltal
        //protected void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}



        #region listadoDePersonasBusqueda

        public List<clsPersona> listadoDePersonasBusqueda
        {
            get
            {
                return _listadoDePersonasBusqueda;
            }

            set
            {
                _listadoDePersonasBusqueda = value;
            }
        }

        #endregion


        #region textoBusqueda

        public String textoBusqueda
        {
            get
            {
                return _textoBusqueda;
            }

            set
            {
                _textoBusqueda = value;
            }
        }

        #endregion

        /*public String listadoDePersonasVisible
        {
            get
            {
                return _listadoDePersonasVisible;
            }

            set
            {
                _listadoDePersonasVisible = value;
                NotifyPropertyChanged("listadoDePersonasVisible");
            }
        }*/

        /*public String listadoDePersonasBusquedaVisible
        {
            get
            {
                return _listadoDePersonasBusquedaVisible;
            }

            set
            {
                _listadoDePersonasBusquedaVisible = value;
                NotifyPropertyChanged("listadoDePersonasBusquedaVisible");
            }
        }*/



        public DelegateCommand actualizarListadoBusquedaCommand
        {
            get
            {
                _rellenarListadoBusquedaCommand = new DelegateCommand(rellenarListadoBusquedaCommandCommand_Executed);
                return _rellenarListadoBusquedaCommand;
            }
        }

        private void rellenarListadoBusquedaCommandCommand_Executed()
        {
            //Actualizamos la lista de personas
            clsListadoPersonas_BL listadoPersonas = new clsListadoPersonas_BL();

            //Cargar el listado de personas que cumplan los criterios de busqueda
            _listadoDePersonas = listadoPersonas.listadoPersonasBusquedaNombreApellidos_BL(_textoBusqueda); //TODO
            NotifyPropertyChanged("listadoDePersonas");
        }


        #region constructor por defecto

        public MainPageViewModel()
        {
            //clsListadoPersonas_BL listadoPersonas = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL listadoDepartamentos = new clsListadoDepartamentos_BL();

            //Cargar el listado de personas
            //_listadoDePersonas = listadoPersonas.listadoCompletoPersonas_BL();
            actualizarListadoCommand_Executed();

            _listadoDepartamentos = listadoDepartamentos.listadoCompletoPersonas_BL();

            //_listadoDePersonasBusquedaVisible = "Visible";
            //_listadoDePersonasVisible = "Collapsed";
        }

        #endregion


        #region metodoRafaListaBusqueda



        #endregion

    }
}
