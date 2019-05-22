using miChatSignalR.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _conn = new HubConnection("https://michatsignalr.azurewebsites.net");
            _proxy = _conn.CreateHubProxy("ChatHub");
            _conn.Start();

            _proxy.On<ChatMessage>("broadcastMessage", OnMessage);
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
