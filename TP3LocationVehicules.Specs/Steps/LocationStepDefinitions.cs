using TechTalk.SpecFlow;
using TP3_location_vehicules;
using TP3LocationVehicules.Specs.Fake;
using FluentAssertions;

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
        private Location _location;
        private FakeDataLayer _fakeDataLayer;

        public LocationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._fakeDataLayer = new FakeDataLayer();
            this._location = new Location(this._fakeDataLayer);
        }


        [Given(@"que les clients suivants existent")]
        public void SoitQueLesClientsSuivantsExistent(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                this._fakeDataLayer.Clients.Add(new Client(row[0], row[1]));
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
            this._location.utilisateurConnecte.Should().BeFalse();
        }

        [Then(@"le message d'erreur est ""(.*)""")]
        public void AlorsLeMessageDUtilisateurOuMotDePasseIncorrect(string errorMessage)
        {
            this._messageErreur.Should().Be(errorMessage);
        }

        [Then(@"la connexion a réussi")]
        public void AlorsLaConnexionAReussi()
        {
            this._location.utilisateurConnecte.Should().BeTrue();
        }

    }
}
