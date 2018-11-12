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
    class MainPageViewModel : clsVMBase
    {
        #region propiedades privadas

        private List<clsPersona> _listadoDePersonas;
        private clsPersona _personaSeleccionada;
        private List<clsDepartamento> _listadoDepartamentos;
        private clsDepartamento _departamentoSeleccionado;

        private DelegateCommand _eliminarCommand;
        private DelegateCommand _actualizarListadoCommand;

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
                _personaSeleccionada = value;

                //Llamamos a CanExecute de eliminar para que compruebe si habilita el comando
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
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
                NotifyPropertyChanged("departamentoSeleccionado");
            }
        }


        public DelegateCommand eliminarCommand
        {
            get
            {
                _eliminarCommand = new DelegateCommand(eliminarCommand_Executed, eliminarCommand_CanExecute);
                return _eliminarCommand;
            }
        }

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
                }
                catch(Exception e)
                {
                    //TODO lo mismo del anterior
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

        //Al implementar la clase clsVMBase no es necesario utilizar INotifytaltal
        //protected void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}



        #region constructor por defecto

        public MainPageViewModel()
        {
            //clsListadoPersonas_BL listadoPersonas = new clsListadoPersonas_BL();
            clsListadoDepartamentos_BL listadoDepartamentos = new clsListadoDepartamentos_BL();

            //Cargar el listado de personas
            //_listadoDePersonas = listadoPersonas.listadoCompletoPersonas_BL();
            actualizarListadoCommand_Executed();

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
