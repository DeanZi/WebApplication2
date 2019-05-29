using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Home
        public ActionResult Index(string ip, int port)
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
           
            //while (server.Connected)  //while the client is connected, we look for incoming messages
            //{
                foreach (string cmd in cmds)
                {
                    string tmpCmd = cmd + "\r\n";
                    ns.Write(Encoding.ASCII.GetBytes(tmpCmd), 0, tmpCmd.Length);
                }
                byte[] msg = new byte[1024];     // byte array
                ns.Read(msg, 0, msg.Length);   //the networkstream now reads what is being sent from the client
                char[] charsToTrim = { ' ', '?' };
                string phrase = Encoding.Default.GetString(msg).Trim(charsToTrim);
                Console.WriteLine(phrase); //we print the filtered input from the client
                string[] details = phrase.Split(',', '\n');
            details[0]=details[0].Replace("/position/longitude-deg = '", "");
            details[0] = details[0].Replace("' (double)\r", "");
            details[1] = details[1].Replace("/> /position/latitude-deg = '", "");
            details[1] = details[1].Replace("' (double)\r", "");


            /*    if (details[0] != "" && details[1] != "")
                    Update(Convert.ToDouble(details[0]), Convert.ToDouble(details[1]));//we take the interesting first two
              */  //pieces of information which stands for Lat and Lon and update our fields accordinglly.
                  //}

            ns.Close();
            server.Close();
        }
    }
}