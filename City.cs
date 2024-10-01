using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class City
    {
        private PoliceStation policeStation;
        private List<Taxi> taxiLicenses;

        void RegisterTaxiLicense(Taxi taxi)
        {
            taxiLicenses.Add(taxi);
        }

        void RemoveTaxiLicense(Taxi taxi)
        {
            taxiLicenses.Remove(taxi);
        }

    }
}
