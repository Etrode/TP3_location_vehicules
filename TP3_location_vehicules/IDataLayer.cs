using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    public interface IDataLayer
    {
        List<Client> Clients { get; }
        List<Vehicule> Vehicules { get; }
        List<Reservation> Reservations { get; }
    }
}
