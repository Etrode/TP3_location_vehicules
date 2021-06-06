using TechTalk.SpecFlow;
using TP3_location_vehicules;
using TP3LocationVehicules.Specs.Fake;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TP3LocationVehicules.Specs.Steps
{
    [Binding]
    public sealed class LocationStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private string _nomUtilisateur;
        private string _motDePasse;
        private string _messageErreur;
        private Client _clientInscrit;
        private bool _estInscrit;
        private DateTime? _dateDebut;
        private DateTime? _dateFin;
        private Vehicule _vehicule;
        private double? _kmEstimee;
        private double _prixEstimee;
        List<String> _immatDisponibles;
        private Location _location;
        private FakeDataLayer _fakeDataLayer;

        public LocationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._fakeDataLayer = new FakeDataLayer();
            this._location = new Location(this._fakeDataLayer);
            this._estInscrit = false;
            this._immatDisponibles = new List<String>();
        }

        // Connexion -------------

        [Given(@"que l'on a les clients suivants")]
        public void SoitQueLesClientsSuivantsExistent(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                this._fakeDataLayer.Clients.Add(new Client(row[0], row[1], row[2], row[3], DateTime.Parse(row[4]), row[5], DateTime.Parse(row[6])));
            }
        }

        [Given(@"les véhicules suivants")]
        public void SoitQueLesVehiculesSuivantExistent(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                this._fakeDataLayer.Vehicules.Add(new Vehicule(row[0], row[1], row[2], row[3], double.Parse(row[4]), double.Parse(row[5]), int.Parse(row[6])));
            }
        }

        [Given(@"les réservations suivantes")]
        public void SoitLesReservationsSuivantes(Table table)
        {
            // Récupération des clients et véhicules pour créer les réservations
            foreach (TableRow row in table.Rows)
            {
                Client currentClient = null;
                Vehicule currentVehicule = null;
                foreach (Client client in this._fakeDataLayer.Clients)
                {
                    if (client.NomUtilisateur == row[1])
                    {
                        currentClient = client;
                        break;
                    }
                }
                if (currentClient != null)
                {
                    foreach (Vehicule vehicule in this._fakeDataLayer.Vehicules)
                    {
                        if (vehicule.Immatriculation == row[0])
                        {
                            currentVehicule = vehicule;
                            break;
                        }
                    }
                    if (currentVehicule != null)
                    {
                        this._fakeDataLayer.Reservations.Add(new Reservation(DateTime.Parse(row[2]), DateTime.Parse(row[3]), double.Parse(row[4]), row[5] == "null" ? (double?)null : double.Parse(row[5]), double.Parse(row[6]), row[7] == "null" ? (double?)null : double.Parse(row[7]), currentClient, currentVehicule));
                    }
                }
            }
        }

        [Given(@"que mon nom utilisateur est ""(.*)""")]
        public void SoitQueMonNomUtilisateurEst(string nomUtilisateur)
        {
            this._nomUtilisateur = nomUtilisateur;
        }


        [Given(@"mon mot de passe est ""(.*)""")]
        public void SoitMonMotDePasseEst(string motDePasse)
        {
            this._motDePasse = motDePasse;
        }

        [When(@"j'essaie de me conntecter à mon compte")]
        public void QuandJEssaieDeMeConntecterAMonCompte()
        {
            this._messageErreur = this._location.ConnexionUtilisateur(this._nomUtilisateur, this._motDePasse);
        }

        [Then(@"la connexion échoue")]
        public void AlorsLaConnexionEchoue()
        {
            this._location.utilisateurConnecte.Should().Be(null);
        }

        [Then(@"le message d'erreur est ""(.*)""")]
        public void AlorsLeMessageDUtilisateurOuMotDePasseIncorrect(string errorMessage)
        {
            this._messageErreur.Should().Be(errorMessage);
        }

        [Then(@"la connexion a réussi")]
        public void AlorsLaConnexionAReussi()
        {
            this._location.utilisateurConnecte.Should().NotBe(null);
        }

        // Inscription -------------

        [Given(@"que mes informations clientes sont les suivantes")]
        public void SoitQueMesInformationsClientesSontLesSuivantes(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                _clientInscrit = new Client(row[0], row[1], row[2], row[3], DateTime.Parse(row[4]), row[5], DateTime.Parse(row[6]));
                break;
            }
        }

        [When(@"j'essaie de m'inscrire")]
        public void QuandJInscrire()
        {
            _estInscrit = this._location.InscriptionUtilisateur(_clientInscrit);
        }

        [Then(@"l'inscription réussi")]
        public void AlorsLInscriptionReussi()
        {
            _estInscrit.Should().BeTrue();
        }

        [Then(@"l'inscription échoue")]
        public void AlorsLInscriptionEchoue()
        {
            _estInscrit.Should().BeFalse();
        }

        // Affichage disponibilités -------------

        [Given(@"que je suis le client suivant connecté")]
        public void SoitQueJeSuisLeClientSuivant(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                this._location.ConnexionUtilisateur(row[0], row[1]);
                break;
            }
        }

        [Given(@"mes dates de réservation sont")]
        public void SoitMesDatesDeReservationSont(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                _dateDebut = DateTime.Parse(row[0]);
                _dateFin = DateTime.Parse(row[1]);
                break;
            }
        }

        [When(@"je souhaite vérifier la disponibilité des véhicules")]
        public void QuandJeSouhaiteVerifierLaDisponibiliteDesVehicules()
        {
            _immatDisponibles = this._location.VehiculesDisponibles(_dateDebut, _dateFin);
        }


        [Then(@"les véhicules disponibles sont")]
        public void AlorsLesVehiculesDisponiblesSont(Table table)
        {
            bool egal = false;
            List<String> listeImmatriculations = new List<string>();
            foreach (TableRow row in table.Rows)
            {
                listeImmatriculations.Add(row[0]);
            }
            
            if( (!listeImmatriculations.Any()) &&  (!_immatDisponibles.Any()))
            {
                egal = true;
            } else
            {
                egal = listeImmatriculations.All(l => _immatDisponibles.Contains(l)) && _immatDisponibles.All(l => listeImmatriculations.Contains(l));
            }
            egal.Should().BeTrue();
        }

        // Réservation ------------

        [Given(@"le véhicule choisi a l'immatriculation ""(.*)""")]
        public void SoitLeVehiculeChoisiALImmatriculation(string immatriculation)
        {
            _vehicule = this._fakeDataLayer.Vehicules.SingleOrDefault(v => v.Immatriculation == immatriculation);
        }
        [Given(@"les km estimés de ""(.*)""")]
        public void SoitLesKmEstimesDe(double km)
        {
            _kmEstimee = km;
        }

        [When(@"je demande la réservation")]
        public void QuandJeDemandeLaReservation()
        {
            _prixEstimee = this._location.reservation(_vehicule, (DateTime)_dateDebut, (DateTime)_dateFin, (double)_kmEstimee);
        }


        [Then(@"la réservation est au prix de ""(.*)"" euros")]
        public void AlorsLaReservationEstAuPrixDeEuros(double prix)
        {
            _prixEstimee.Should().Be(prix);
        }


    }
}