using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawAndGuess.Server
{
    public class Server
    {
        ArrayList clients = new ArrayList();
        TcpListener listener;
        TcpClient client;
        byte[] data;
        string msg = "";
        string guess = "";

        //Connect to server
        public void Connect()
        {
            //Start server
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 3000);
            listener.Start();
            Console.WriteLine("Server is listening.");

            while (true)
            {
                if (clients.Count < 2)
                {
                    //This client is a drawer
                    if (clients.Count == 0)
                    {
                        client = listener.AcceptTcpClient();
                        clients.Add(client);
                        Player drawerPlayer = new Player(client, true);
                        Console.WriteLine("Drawer connected");
                        msg = "Drawer";
                    }
                    else//This client is a guesser
                    {
                        client = listener.AcceptTcpClient();
                        clients.Add(client);
                        Player guesserPlayer = new Player(client, false);
                        Console.WriteLine("Guesser connected");
                        msg = "Guesser";
                    }
                }

                //Send and recieve messages to client
                NetworkStream netStream = client.GetStream();
                BinaryReader reader = new BinaryReader(netStream);
                BinaryWriter writer = new BinaryWriter(netStream);

                //Send to client side if client is drawer or guesser
                writer.Write(msg);
            }
        }
    }
}
