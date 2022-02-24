using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawAndGuess.Server
{
    class Player
    {
        public TcpClient Client { get; set; }
        public bool IsDrawer { get; set; }

        public Player(TcpClient client, bool isDrawer)
        {
            Client = client;
            IsDrawer = isDrawer;
        }
    }
}
