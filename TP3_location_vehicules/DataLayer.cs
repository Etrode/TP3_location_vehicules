using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    internal  class DataLayer : IDataLayer
    {
        public List<Client> Clients { get; private set; }

        public DataLayer()
        {
            this.Clients = new List<Client>();
            // Récupération des données réelles hors test
        }
    }
}
