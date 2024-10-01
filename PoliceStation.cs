using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class PoliceStation
    {
        private List<PoliceCar> policeCars;
        private bool alert;

        public void RegisterCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
        }

        public void NotifyPlate(string vehiclePlate)
        {
            for (int i = 0; i < policeCars.Count; i++)
            {
                PoliceCar policeCar = policeCars[i];
                if (policeCar.IsPatrolling())
                {
                    Console.WriteLine("Police Car Notified");
                    bool stationNotified = true;
                    policeCar.StartChasing(vehiclePlate, stationNotified);
                }
            }
        }

        public void ActivateAlert(string vehiclePlate)
        { 
            if (!alert)
            {  
                alert = true;
                NotifyPlate(vehiclePlate);
            }
        }

        public void DeActivateAlert()
        { 
            alert = false; 
        }
    }
}
