using System;
using System.Collections.Generic;
using System.Text;

namespace TP3_location_vehicules
{
    public class Client
    {
        public string NomUtilisateur { get; private set; }

        public string MotDePasse { get; private set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        public DateTime DatePermisConduire { get; set; }

        public string NumeroPermisConduire { get; set; } // string car alphanumérique pour les permis avant 1975


        public Client(string nomUtilisateur, string motDePasse, string nom, string prenom
            , DateTime dateNaissance, string numeroPermisConduire
            , DateTime datePermisConduire)
        {
            NomUtilisateur = nomUtilisateur;
            MotDePasse = motDePasse;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            NumeroPermisConduire = numeroPermisConduire;
            DatePermisConduire = datePermisConduire;
        }

        public Client(string nomUtilisateur, string motDePasse)
        {
            NomUtilisateur = nomUtilisateur;
            MotDePasse = motDePasse;
        }
    }
}
