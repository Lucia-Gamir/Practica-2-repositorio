using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class PlateVehicle: Vehicle
    {
        private string plate;

        public PlateVehicle(string typeOfVehicle, string plate) : base (typeOfVehicle)
        {
            this.plate = plate;
        }

        public string GetPlate()
        {
            return plate;
        }

        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
        }
    }
}
