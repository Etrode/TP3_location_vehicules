using System;
using System.Collections.Generic;
using System.Linq;

namespace TP3_location_vehicules
{
    public class Location
    {
        private IDataLayer _dataLayer;

        public Client utilisateurConnecte { get; private set; }

        public Location()
        {
            // Constructeur pour récupérer les données réelles hors test
            this._dataLayer = new DataLayer();
        }

        public Location(IDataLayer dataLayer)
        {
            this._dataLayer = dataLayer;
        }

        public string ConnexionUtilisateur(string nomUtilisateur, string motDePasse)
        {
            Client client = this._dataLayer.Clients.SingleOrDefault(c => (c.NomUtilisateur == nomUtilisateur) && (c.MotDePasse == motDePasse));
            if (client == null)
            {
                this.utilisateurConnecte = null;
                return "Nom d'utilisateur ou mot de passe incorrect";
            }
            this.utilisateurConnecte = client;
            return "";
        }

        public bool InscriptionUtilisateur(Client client)
        {
            bool exists = false;
            foreach(Client c in this._dataLayer.Clients)
            {
                if(c.NomUtilisateur == client.NomUtilisateur)
                {
                    exists = true;
                    break;
                }
            }
            if (exists)
                return false;
            this._dataLayer.Clients.Add(client);
            return true;
        }

        public List<String> VehiculesDisponibles(DateTime? debut, DateTime? fin)
        {
            List<String> listeImmatriculations = new List<String>();
            // Utilisateur connecté
            if (utilisateurConnecte == null)
                return listeImmatriculations;
            // Verification permis de conduire (sous-entend au moins 18 ans)
            if(string.IsNullOrEmpty(utilisateurConnecte.NumeroPermisConduire))
                return listeImmatriculations;
            // Controle date
            if(debut == null || fin == null)
                return listeImmatriculations;
            if ((debut < DateTime.Today) || (fin < debut))
                return listeImmatriculations;
            // Vérification s'il existe déjà une réservation planifiée ou en cours pour l'utilisateur
            Reservation reservationEnCours = this._dataLayer.Reservations.SingleOrDefault(r => (r.Client.NomUtilisateur == this.utilisateurConnecte.NomUtilisateur)
                                                                                          && (r.DateFin >= DateTime.Today));
            if (reservationEnCours != null)
                return listeImmatriculations;

            // Liste de véhicules non réservées
            List<Vehicule> vehiculesDisponibles = new List<Vehicule>();
            foreach(Vehicule vehicule in this._dataLayer.Vehicules)
            {
                Reservation reservationExiste = this._dataLayer.Reservations.SingleOrDefault(r => r.Vehicule == vehicule && ((debut >= r.DateDebut && debut <= r.DateFin) || (fin >= r.DateDebut && fin <= r.DateFin)));
                if (reservationExiste == null)
                    vehiculesDisponibles.Add(vehicule);
            }
            // Aucun véhicule disponible
            if (!vehiculesDisponibles.Any())
                return listeImmatriculations;
            // Restrictions suivant l'âge
            if (utilisateurConnecte.GetAge() < 21)
            {
                foreach(Vehicule v in vehiculesDisponibles.GetRange(0, vehiculesDisponibles.Count()))
                {
                    if(v.ChevauxFiscaux >= 8)
                        vehiculesDisponibles.Remove(v);
                }
            } else if(utilisateurConnecte.GetAge() <= 25 )
            {
                foreach (Vehicule v in vehiculesDisponibles.GetRange(0, vehiculesDisponibles.Count()))
                {
                    if (v.ChevauxFiscaux >= 13)
                        vehiculesDisponibles.Remove(v);
                }
            }

            foreach (Vehicule vehiculeCourant in vehiculesDisponibles)
            {
                listeImmatriculations.Add(vehiculeCourant.Immatriculation);
            }
            return listeImmatriculations;
        }

        public double reservation(Vehicule vehicule, DateTime debut, DateTime fin, double kmEstime)
        {
            double prix = vehicule.PrixReservation + (vehicule.TarifKilometrique * kmEstime);
            this._dataLayer.Reservations.Add(new Reservation(debut, fin, kmEstime, null, prix, null, this.utilisateurConnecte, vehicule));
                       
            return prix;
        }


    }
}
