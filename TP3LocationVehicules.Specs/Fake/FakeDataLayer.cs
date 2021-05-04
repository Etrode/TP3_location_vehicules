using System;
using System.Collections.Generic;
using System.Text;
using TP3_location_vehicules;

namespace TP3LocationVehicules.Specs.Fake
{
    class FakeDataLayer : IDataLayer
    {
        public List<Client> Clients { get; set; }

        public FakeDataLayer()
        {
            this.Clients = new List<Client>();
        }
    }
}
