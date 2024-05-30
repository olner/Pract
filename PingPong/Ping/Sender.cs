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

        public async Task<Message> AddMessage(string message)
        {
            var serviceResponse = await client.AddMessageAsync(message, DummyUser.Id);
            return serviceResponse.Response;
        }

        public async Task<Message> DeleteMessage(Guid id)
        {
            var serviceResponse = await client.DeleteMessageAsync(DummyUser.Id,id);
            throw new NotImplementedException();
        }

        public async Task<Message> GetMessage(Guid id)
        {
            var serviceResponse = await client.GetMessageAsync(DummyUser.Id,id);
            return serviceResponse.Response;
        }

        public async Task<List<Message>> GetMessageList(Guid id)
        {
            var serviceResponse = await client.GetMessageListAsync(DummyUser.Id, id);
            return (List<Message>)serviceResponse.Response;
        }
    }
}
