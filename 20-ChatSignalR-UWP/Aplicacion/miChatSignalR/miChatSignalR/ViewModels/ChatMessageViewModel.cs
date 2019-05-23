using miChatSignalR.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace miChatSignalR.ViewModels
{

    //private ChatMessageViewModel _ChatVM { get; set; } = new ChatMessageViewModel();


    public class ChatMessageViewModel
    {
        private ObservableCollection<ChatMessage> _messages;
        private HubConnection _conn { get; set; }
        private IHubProxy _proxy { get; set; }

        public ObservableCollection<ChatMessage> Messages
        {
            get
            {
                return _messages;
            }

            set
            {
                _messages = value;
            }
        }

        public HubConnection Conn
        {
            get
            {
                return _conn;
            }

            set
            {
                _conn = value;
            }
        }

        public IHubProxy Proxy
        {
            get
            {
                return _proxy;
            }

            set
            {
                _proxy = value;
            }
        }

        public void SignalR()
        {
            //_conn = new HubConnection("https://michatsignalr.azurewebsites.net");
            _conn = new HubConnection("http://localhost:58455/");
            _proxy = _conn.CreateHubProxy("ChatHub");
            _conn.Start();

            mostrarConexion(_conn);

            _proxy.On<ChatMessage>("broadcastMessage", OnMessage);

            _proxy.On("pintarCuadro", aux);
        }

        public async void aux()
        {
            /*ContentDialog dialog = new ContentDialog();
            dialog.Content = "Un cuadrito";
            dialog.PrimaryButtonText = "Chupi";

            await dialog.ShowAsync();*/

            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Content = "Un cuadrito";
                dialog.PrimaryButtonText = "Chupi";

                await dialog.ShowAsync();
            });

        }

        public async void mostrarConexion(HubConnection con)//bool estaConectado)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Content = "Conexion: "+con.State.ToString();
            dialog.PrimaryButtonText = "Chupi";

            await dialog.ShowAsync();
        }

        public void Broadcast(ChatMessage msg)
        {
            _proxy.Invoke("Send", msg);
        }

        public async void OnMessage(ChatMessage msg)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                _messages.Add(msg);
            });
        }


        public ChatMessageViewModel()
        {
            _messages = new ObservableCollection<ChatMessage>();

            SignalR();
        }

    }
}
