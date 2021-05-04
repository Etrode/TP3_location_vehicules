using System;
using System.Linq;

namespace TP3_location_vehicules
{
    public class Location
    {
        private IDataLayer _dataLayer;

        public bool utilisateurConnecte { get; private set; }

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
                this.utilisateurConnecte = false;
                return "Nom d'utilisateur ou mot de passe incorrect";
            }
            this.utilisateurConnecte = true;
            return "";
        }


    }
}
