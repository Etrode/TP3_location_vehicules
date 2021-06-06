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

        public double? KmFinal { get; set; }

        public double PrixEstimation { get; set; }

        public double? PrixFinal { get; set; }

        public Client Client { get; set; }

        public Vehicule Vehicule { get; set; }

        public Reservation(DateTime dateDebut, DateTime dateFin, double kmEstimation, double? kmFinal, double prixEstimation, double? prixFinal, Client client, Vehicule vehicule)
        {
            DateDebut = dateDebut;
            DateFin = dateFin;
            KmEstimation = kmEstimation;
            KmFinal = kmFinal;
            PrixEstimation = prixEstimation;
            PrixFinal = prixFinal;
            Client = client;
            Vehicule = vehicule;
        }
    }
}
