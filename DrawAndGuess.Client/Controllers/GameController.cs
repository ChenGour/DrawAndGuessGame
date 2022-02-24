using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace DrawAndGuess.Client.Controllers
{
    public class GameController : Controller
    {
        string msg = "";
        TcpClient client;
        public ActionResult Welcome()
        {
            string msg = "";
            client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 3000);

            //Send and recieve messages to server
            NetworkStream netStream = client.GetStream();
            BinaryReader reader = new BinaryReader(netStream);
            BinaryWriter writer = new BinaryWriter(netStream);

            //Accept message from server if the client is drawer or guesser
            msg = reader.ReadString();
            ViewBag.Message = msg;

            return View("Welcome");
        }

        public ActionResult WordChoosing()
        {
            return View();
        }

        public ActionResult Drawing()
        {
            return View();
        }

        public ActionResult Guessing()
        {
            return View();
        }

        public ActionResult Waiting()
        {
            return View();
        }
    }
}
