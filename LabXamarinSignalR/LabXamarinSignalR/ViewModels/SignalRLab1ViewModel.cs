using LabXamarinSignalR.Helpers;
using LabXamarinSignalR.Models;
using SignalR.Client.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabXamarinSignalR.ViewModels
{
    public class SignalRLab1ViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ModelSignalR> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ICommand CreateText { get; }
        public SignalRLab1ViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<ModelSignalR>();
            
            CreateText = new Command(async () =>  CreateTextCommand());

           XamaSignal();

        }

        async  Task XamaSignal()
        {
            // Connect to the server
            var hubConnection = new HubConnection("http://192.168.0.109/LabSignalRWebMaster/");

            // Create a proxy to the 'ChatHub' SignalR Hub
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("notifyHub");

            // Wire up a handler for the 'UpdateChatMessage' for the server
            // to be called on our client
            chatHubProxy.On<string>("ClientUpdateDateTime", message =>
               Items.Add(new ModelSignalR {TextoServer=message }));

            // Start the connection
            await hubConnection.Start();

            // Invoke the 'UpdateNick' method on the server
        }

        private void CreateTextCommand()
        {
            ModelSignalR msig = new ModelSignalR();
            msig.TextoServer = DateTime.Now.ToString();

            Items.Add(msig);
        }
    }
}
