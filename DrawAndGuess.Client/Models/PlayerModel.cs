using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace DrawAndGuess.Client.Models
{
    public class PlayerModel
    {
        public TcpClient Client { get; set; }
        public bool IsDrawer { get; set; }
    }
}