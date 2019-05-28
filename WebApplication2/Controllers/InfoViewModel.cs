using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class InfoViewModel
    {
        public Info flightInfoModel;

        string[] convertedString = new string[2];



        //Connect button prompts
        public void Connect()
        {
            flightInfoModel = new Info(false);
            if (flightInfoModel.flag)
            {
                flightInfoModel.MainServer("stop", "0", 0);
                Task task2 = Task.Factory.StartNew(() => flightInfoModel.MainServer("start", ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort));
                Task task3 = Task.Factory.StartNew(() => Update());
            }
        }

        //Update Lon & Lat values
        public void Update()
        {
            while (true)
            {
                if (flightInfoModel != null)
                {
                    if (flightInfoModel.flag)
                    {
                        try
                        {
                            Lon = flightInfoModel.latLon[0];
                            Lat = flightInfoModel.latLon[1];
                            convertedString[0] = String.Join(" ", flightInfoModel.latLon);
                            File.WriteAllLines(@"C:\Users\Dean\Downloads\Output1.txt", convertedString);

                        }
                        catch (Exception e) { }
                    }
                }
            }
        }

        //Lon property
        private double lon;
        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
            }
        }

        //Lat property
        private double lat;
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
            }
        }
    }
}