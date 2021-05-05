using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    public class Reservation
    {
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public double KmEstimation { get; set; }

        public double KmFinal { get; set; }

        public double PrixEstimation { get; set; }

        public double PrixFinal { get; set; }

        public Client Client { get; set; }

        public Vehicule Vehicule { get; set; }

    }
}
