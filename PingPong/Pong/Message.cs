using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public record Message
    {
        public string Id { get; set; } 

        public string Text { get; set; }

        public int Status { get; set; }

    }
}
