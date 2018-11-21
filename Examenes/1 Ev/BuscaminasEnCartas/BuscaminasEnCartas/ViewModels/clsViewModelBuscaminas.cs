using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaminasEnCartas.Models.Entidades;
using Windows.UI.Xaml.Controls;

namespace BuscaminasEnCartas.ViewModels
{
    class clsViewModelBuscaminas : clsVMBase
    {

        #region propiedades privadas

        private clsCarta[] _arrayCartas;
        private Uri[] _arrayImagenes;
        private clsCarta _cartaPulsada;
        private int _contadorCartasPulsadas;
        private int _puntuacion;

        private DelegateCommand _nuevaPartidaCommand;
        private DelegateCommand _mostrarReglasCommand;

        private String _colorDeFondo;

        #endregion

        #region propiedades publicas

        public clsCarta[] arrayCartas
        {
            get
            {
                return _arrayCartas;
            }

            set
            {
                _arrayCartas = value;
                NotifyPropertyChanged("arrayCartas");
            }
        }

        public Uri[] arrayImagenes
        {
            get
            {
                return _arrayImagenes;
            }

            set
            {
                _arrayImagenes = value;
                NotifyPropertyChanged("arrayImagenes");
            }
        }

        public clsCarta cartaPulsada
        {
            get
            {
                return _cartaPulsada;
            }

            set
            {
                _cartaPulsada = value;

                //si la carta pulsada no habia sido pulsada anteriormente, se hacen las comprobaciones pertinentes.
                //Esto esta así debido a que por la falta de familiaridad con GridView no he logrado que los
                //elementos ya pulsados se deshabiliten en la propia interfaz
                if(!_cartaPulsada.haSidoPulsada)
                {
                    //marca la carta seleccionada como pulsada
                    marcarCarta();

                    //si la carta es una bomba, se termina el juego
                    if (_cartaPulsada.esBomba)
                    {
                        finDelJuego(true);
                    }
                    //si no lo es, se continua la partida
                    else
                    {
                        //Se aumenta el contador de cartas pulsadas
                        _contadorCartasPulsadas++;

                        //Si ya se han pulsado cinco cartas, se termina el juego
                        if (_contadorCartasPulsadas == 5)
                        {
                            finDelJuego(false);
                        }
                    }

                    NotifyPropertyChanged("cartaPulsada");
                    NotifyPropertyChanged("arrayCartas");
                }
                
            }
        }

        public String colorDeFondo
        {
            get
            {
                return _colorDeFondo;
            }

            set
            {
                _colorDeFondo = value;
                NotifyPropertyChanged("colorDeFondo");
            }
        }

        public int puntuacion
        {
            get
            {
                return _puntuacion;
            }

            set
            {
                _puntuacion = value;
                NotifyPropertyChanged("puntuacion");
            }
        }

        /// <summary>
        /// Funcion que crea una nueva partida y lo devuelve
        /// </summary>
        public DelegateCommand nuevaPartidaCommand
        {
            get
            {
                _nuevaPartidaCommand = new DelegateCommand(nuevaPartidaCommand_Executed);
                return _nuevaPartidaCommand;
            }
        }

        /// <summary>
        /// Funcion que prepara todos los elementos necesarios para empezar una partida desde cero
        /// </summary>
        private void nuevaPartidaCommand_Executed()
        {
            _cartaPulsada = null;
            _contadorCartasPulsadas = 0;
            _arrayCartas = new clsCarta[16];
            _colorDeFondo = "AliceBlue";

            rellenarArrayCartas();
            asignarBombasEnCartas();

            NotifyPropertyChanged("cartaPulsada");
            NotifyPropertyChanged("arrayCartas");
            NotifyPropertyChanged("colorDeFondo");
        }
        
        
        /// <summary>
        /// Funcion que muestra al jugador las reglas del juego
        /// </summary>
        public DelegateCommand mostrarReglasCommand
        {
            get
            {
                _mostrarReglasCommand = new DelegateCommand(mostrarReglasCommand_Executed);
                return _mostrarReglasCommand;
            }
        }

        /// <summary>
        /// Funcion que pinta una ventana en pantalla al jugador con las reglas del juego
        /// </summary>
        private async void mostrarReglasCommand_Executed()
        {
            ContentDialog reglasPopUp = new ContentDialog();

            reglasPopUp.Title = "Reglas del juego";
            reglasPopUp.Content = "Hay un total de 16 cartas, y 4 de ellas contienen una bomba.\n\nPara ganar, debes elegir 5 cartas y que ninguna sea una bomba.\n\nGanas 5 puntos por no elegir ninguna bomba en la partida.\n\nPierdes 3 puntos por elegir una bomba.";
            reglasPopUp.PrimaryButtonText = "Entendido, ¡voy a ganar!";

            await reglasPopUp.ShowAsync();
        }

        /// <summary>
        /// Funcion que define tres objetos tipo Uri dentro de un array y lo devuelve
        /// </summary>
        /// <returns></returns>
        public Uri[] asignarImagenes()
        {
            Uri[] imagenes = new Uri[3];

            imagenes[0] = new Uri("ms-appx://BuscaminasEnCartas/Assets/Imagenes/presionar.png", UriKind.RelativeOrAbsolute);
            imagenes[1] = new Uri("ms-appx://BuscaminasEnCartas/Assets/Imagenes/salvado.png", UriKind.RelativeOrAbsolute);
            imagenes[2] = new Uri("ms-appx://BuscaminasEnCartas/Assets/Imagenes/bomba.png", UriKind.RelativeOrAbsolute);

            return imagenes;
        }

        /// <summary>
        /// Funcion que rellena el array de cartas con cartas por el constructor por defecto y les asigna un id y la imagen de presionar
        /// </summary>
        public void rellenarArrayCartas()
        {
            int nId = 1;
            for (int i = 0; i < _arrayCartas.Length; i++)
            {
                _arrayCartas[i] = new clsCarta();
                _arrayCartas[i].imagen = _arrayImagenes[0];
                _arrayCartas[i].id = nId;
                nId++;
            }
        }

        /// <summary>
        /// Funcion que marca una carta del array de cartas, cambiando su valor de haSidoPulsada a true y cambiando su imagen
        /// segun si esBomba es true o false, en cuyos casos se le asignara la imagen de bomba o salvado respectivamente
        /// </summary>
        public void marcarCarta()
        {
            bool encontrado = false;
            for(int i=0;!encontrado;i++)
            {
                if(_arrayCartas[i].id==_cartaPulsada.id)
                {
                    encontrado = true;
                    _arrayCartas[i].haSidoPulsada = true;

                    if(_arrayCartas[i].esBomba)
                    {
                        _arrayCartas[i].imagen = _arrayImagenes[2];
                    }
                    else
                    {
                        _arrayCartas[i].imagen = _arrayImagenes[1];
                    }
                }
            }
        }


        /// <summary>
        /// Funcion que inicializa las cartas y que asigna 4 bombas en total a 4 cartas del array de cartas
        /// </summary>
        public void asignarBombasEnCartas()
        {
            int numero;
            int totalBombas = 0;

            Random aleatorio = new Random();

            while (totalBombas < 4)
            {
                numero = aleatorio.Next(0, 15);

                if (!_arrayCartas[numero].esBomba)
                {
                    _arrayCartas[numero].esBomba = true;
                    totalBombas++;
                }
            }
        }
        
        /// <summary>
        /// Funcion que muestra en pantalla un mensaje de victoria o derrota al jugador en funcion del valor recibido.
        /// Si recibe true, significa que el jugador ha pulsado una bomba y ha perdido, si recibe false ha ganado.
        /// </summary>
        /// <param name="haPulsadoBomba"></param>
        public async void finDelJuego(bool haPulsadoBomba)
        {
            ContentDialog mensajePopUp = new ContentDialog();

            if(haPulsadoBomba)
            {
                _colorDeFondo = "Red";
                NotifyPropertyChanged("colorDeFondo");

                _puntuacion = _puntuacion - 3;
                NotifyPropertyChanged("puntuacion");

                mensajePopUp.Title = "HAS PERDIDO";
                mensajePopUp.Content = "Has elegido una mina, pierdes la partida.\n\nHas perdido 3 puntos.";
                mensajePopUp.PrimaryButtonText = "¡No me rendire! Juego otra vez";
            }
            else
            {
                _colorDeFondo = "Green";
                NotifyPropertyChanged("colorDeFondo");

                _puntuacion = _puntuacion + 5;
                NotifyPropertyChanged("puntuacion");

                mensajePopUp.Title = "HAS GANADO";
                mensajePopUp.Content = "Enhorabuena, no has perdido la mano con ninguna bomba.\n\nHas ganado 5 puntos.";
                mensajePopUp.PrimaryButtonText = "¡Estoy en racha! Juego otra vez";

            }

            await mensajePopUp.ShowAsync();

            //Iniciar nueva partida al pulsar el boton del mensaje
            nuevaPartidaCommand_Executed();
        }

        #endregion

        #region constructor por defecto

        public clsViewModelBuscaminas()
        {
            _arrayCartas = new clsCarta[16];
            _arrayImagenes = asignarImagenes();
            _cartaPulsada = null;
            _contadorCartasPulsadas = 0;
            _colorDeFondo = "AliceBlue";
            _puntuacion = 0;

            rellenarArrayCartas();
            asignarBombasEnCartas();
        }

        #endregion


    }
}
