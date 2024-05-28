using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping
{
    internal interface ISender
    {
        public void AddMessage();
        public Message GetMessage();
        public List<Message> GetMessageList();
        public void RemoveMessage();
    }
}
