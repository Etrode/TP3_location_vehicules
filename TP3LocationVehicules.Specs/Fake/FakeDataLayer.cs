using System.Collections.Generic;
using TP3_location_vehicules;

namespace TP3LocationVehicules.Specs.Fake
{
    class FakeDataLayer : IDataLayer
    {
        public List<Client> Clients { get; set; }

        public List<Vehicule> Vehicules { get; set; }

        public List<Reservation> Reservations { get; set; }

        public FakeDataLayer()
        {
            this.Clients = new List<Client>();
            this.Vehicules = new List<Vehicule>();
            this.Reservations = new List<Reservation>();
        }
    }
}
