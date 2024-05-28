using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.WebClient;

namespace Ping
{
    public class Sender : ISender
    { 
        private PingPong.WebClient.PingPongApi client;
        public Sender()
        {
            HttpClient httpClient = new HttpClient();  
            httpClient.BaseAddress = new Uri("http://localhost:5000/");
            client = new PingPongApi(httpClient);
        }

        public async void AddMessage()
        {
            var message = client.AddMessageAsync();
            throw new NotImplementedException();
        }

        public void RemoveMessage()
        {
            throw new NotImplementedException();
        }

        Message ISender.GetMessage()
        {
            throw new NotImplementedException();
        }

        List<Message> ISender.GetMessageList()
        {
            throw new NotImplementedException();
        }
    }
}
