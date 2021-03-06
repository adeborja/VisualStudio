﻿using miChatSignalR.Models;
using miChatSignalR.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace miChatSignalR
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ChatMessageViewModel _vm;

        public MainPage()
        {
            this.InitializeComponent();
            //this.DataContext = (Application.Current as App).ChatVM;
            _vm = (ChatMessageViewModel)this.DataContext;
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text != "")
            {
                //(Application.Current as App).Broadcast(new ChatMessage { Username = name.Text, Message = text.Text });
                //_vm.Broadcast(new ChatMessage { Username = name.Text, Message = text.Text });

                mandarMensaje(name.Text, text.Text);
                text.Text = "";
            }

        }

        private void KeyboardAccelerator_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            mandarMensaje(name.Text, text.Text);
            text.Text = "";
        }

        private void mandarMensaje(string nombre, string mensaje)
        {
            _vm.Broadcast(new ChatMessage { Username = nombre, Message = mensaje });
        }
    }
}
