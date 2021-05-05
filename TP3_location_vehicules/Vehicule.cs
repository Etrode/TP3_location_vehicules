using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    public class Vehicule
    {
        public string Immatriculation { get; set; }

        public string Marque { get; set; }

        public string Modele { get; set; }

        public string Couleur { get; set; }

        public double TarifKilometrique { get; set; }

        public int ChevauxFiscaux { get; set; }

        public Vehicule(string immatriculation, string marque, string modele, string couleur, double tarifKilometrique, int chevauxFiscaux)
        {
            Immatriculation = immatriculation;
            Marque = marque;
            Modele = modele;
            Couleur = couleur;
            TarifKilometrique = tarifKilometrique;
            ChevauxFiscaux = chevauxFiscaux;
        }
    }
}
