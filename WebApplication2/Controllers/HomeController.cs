using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult display(string ip, int port)
        {

            Start(ip, port);
            return View();
        }


        public void Start(string flightServerIP, int flightCommandPort)
        {
            byte[] data = new byte[1024];
            string[] cmds= { "", "" };
            string longitude = "get /position/longitude-deg";
            string latitude = "get /position/latitude-deg";

            TcpClient server;

            try
            {
                server = new TcpClient(flightServerIP, flightCommandPort);
            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect to server");
                return;
            }
            NetworkStream ns = server.GetStream();
            cmds[0] = longitude;
            cmds[1] = latitude;
            foreach (string cmd in cmds)
            {
                string tmpCmd = cmd + "\r\n";
                ns.Write(Encoding.ASCII.GetBytes(tmpCmd), 0, tmpCmd.Length);
                ns.Flush();
            }
            ns.Close();
            server.Close();
        }
    }
}