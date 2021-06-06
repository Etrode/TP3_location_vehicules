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

        public int GetAge()
        {
            DateTime today = DateTime.Today;

            // Age sans prise en compte du jour et du mois
            int age = today.Year - this.DateNaissance.Year;

            // On compare ensuite la date de naissance complète par rapport à la date d'aujourd'hui ramenée à l'année de naissance
            // pour ensuite diminuer l'âge
            if (this.DateNaissance.Date > today.AddYears(-age)) 
                age--;

            return age;
        }
    }
}
