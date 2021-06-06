using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    internal  class DataLayer : IDataLayer
    {
        public List<Client> Clients { get; set; }

        public List<Vehicule> Vehicules { get; }

        public List<Reservation> Reservations { get; }

        public DataLayer()
        {
            // Récupération des données réelles hors test
            this.Clients = new List<Client>();
            this.Vehicules = new List<Vehicule>();
            this.Reservations = new List<Reservation>();
        }
    }
}
