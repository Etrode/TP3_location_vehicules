using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    public class Client
    {
        public string NomUtilisateur { get; private set; }

        public string MotDePasse { get; private set; }

        public Client(string nomUtilisateur, string motDePasse)
        {
            this.NomUtilisateur = nomUtilisateur;
            this.MotDePasse = motDePasse;
        }
    }
}
