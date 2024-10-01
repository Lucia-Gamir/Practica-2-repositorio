using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class PoliceStation: IMessageWritter
    {
        private List<PoliceCar>? policeCars;
        private bool alert;

        public PoliceStation() 
        { 
            this.policeCars = new List<PoliceCar>();
            this.alert = false;
        }

        public void RegisterCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
            Console.WriteLine(policeCar.WriteMessage("Registered in PoliceStation. "));
        }

        public void NotifyPlate(string vehiclePlate, string policePlate)
        {
            for (int i = 0; i < policeCars.Count; i++)
            {
                PoliceCar policeCar = policeCars[i];
                if (policeCar.IsPatrolling() & policeCar.GetPlate() != policePlate)
                {
                    Console.WriteLine(policeCar.WriteMessage($"Has been notified of the chasing. "));
                    bool stationNotified = true;
                    policeCar.StartChasing(vehiclePlate, stationNotified);
                }
            }
        }

        public void ActivateAlert(string vehiclePlate, string policePlate)
        { 
            if (!alert)
            {  
                alert = true;
                NotifyPlate(vehiclePlate, policePlate);
            }
        }

        public void DeActivateAlert()
        { 
            alert = false; 
        }

        public string WriteMessage(string message)
        {
            return $"PoliceStation: {message}";
        }
    }
}
