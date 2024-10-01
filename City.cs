using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class City: IMessageWritter
    {
        private PoliceStation policeStation;
        private List<Taxi> taxiLicenses;

        public City(PoliceStation policeStation)
        {
            this.policeStation = policeStation;
            this.taxiLicenses = new List<Taxi>();
        }
           

        public void RegisterTaxiLicense(Taxi taxi)
        {
            taxiLicenses.Add(taxi);
            Console.WriteLine(taxi.WriteMessage("Registered in City"));
        }

        public void RemoveTaxiLicense(Taxi taxi)
        {
            taxiLicenses.Remove(taxi);
            Console.WriteLine(taxi.WriteMessage("Removed from City"));
        }

        public string WriteMessage(string message)
        {
            return $"City: {message}";
        }
    }
}
