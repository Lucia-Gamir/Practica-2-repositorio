using System.ComponentModel.Design;

namespace Practice1
{
    class PoliceCar : PlateVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        private bool chasingVehicle;
        private PoliceStation policeStation;

        public PoliceCar(string plate, bool radar, PoliceStation policeStation) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            if (radar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null;
            }

            this.policeStation = policeStation;
        }

        public void UseRadar(PlateVehicle vehicle)
        {
            if (speedRadar != null)
            {
                if (isPatrolling)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (speedRadar.IsAboveLimit())
                    {
                        StartChasing(vehicle.GetPlate());
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage($"has no active radar."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no radar. "));
            }
        }


        public void ActivateAlert(string vehiclePlate)
        {
            policeStation.ActivateAlert(vehiclePlate, this.GetPlate());
        }

        public void StartChasing(string vehiclePlate, bool stationNotified = false)
        {
            chasingVehicle = true;
            Console.WriteLine(WriteMessage($"Started chasing vehicle {vehiclePlate}. "));
            if (!stationNotified)
            {
                Console.WriteLine(WriteMessage($"Activated alarm. "));
                ActivateAlert(vehiclePlate);
            }
        }

        public void StopChasing()
        { 
            chasingVehicle = false; 
            Console.WriteLine(WriteMessage($"Stopped chasing. "));
        }

        public void DeActivateAlert()
        { 
            policeStation.DeActivateAlert();
            Console.WriteLine(WriteMessage($"Deactivated alert. "));
        }
    }
}