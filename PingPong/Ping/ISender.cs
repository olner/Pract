using PingPong.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping
{
    public interface ISender
    {
        public Task<Message> AddMessage(string message);
        public Task<Message> GetMessage(Guid id);
        public Task<List<Message>> GetMessageList(Guid id);
        public Task<Message> DeleteMessage(Guid id);
    }
}
