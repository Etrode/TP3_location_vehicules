Fonctionnalité: Location

Contexte:
	Etant donnée que l'on a les clients suivants
	| NomUtilisateur    | MotDePasse        | Nom       | Prenom    | DateNaissance | NumeroPermisConduire |  DatePermisConduire | 
	| JoffreyBaratheon  | KingOfTheSeven!   | Baratheon |  Joffrey  | Jan 2, 1999   |  439328589895        |   Mar 5, 2017       | 
	| DaenerysTargaryen | @superKhaleesi    | Targaryen | Daenerys  | Jun 3, 1985   |  P3L932P18589895     |   Apr 1, 1996       | 
	| JonSnow           | !bastardButProud  |  Snow     |    Jon    | Apr 15, 1978  |  678304858382        |   Jan 1, 1998       | 
	| TheonGreyjoy      | eunuchForEver:)   |  Greyjoy  |   Theon   | Nov 1, 1970   |  084736298473        |   Aug 1, 1991       | 
	Et les véhicules suivants
	| Immatriculation | Marque    | Modele    | Couleur   | PrixReservation | TarifKilometrique | ChevauxFiscaux |
	|  CX-212-TK      | Renault   |  Clio 2   |  bleu      | 23             | 0,25              | 4              |
	|  AZ-124-NS      | Peugeot   |  205      |  grise     | 25             | 0,3               | 5              |
	|  NS-219-CS      | Renault   |  twingo 2 |  bleu      | 23             | 0,18              | 4              |
	|  TZ-300-SK      | Opel      |  Vectra   |  rouge     | 34             | 0,4               | 9              |
	|  SS-117-SS      | Audi      |  A4       |  blanche   | 42             | 0,6               | 14             |
	Et les réservations suivantes
	| Immatriculation | NomUtilisateur | dateDebut   | dateFin      | kmEstimation | kmFinal | prixEstimation | prixFinal |
	| NS-219-CS       | TheonGreyjoy   | Jun 1, 2021 | July 3, 2021 | 600          | null    | 108            | null      |

#  Connexion

@ClientNonReconnu
Scénario: Connexion client - nom utilisateur ou mot de passe incorrect
	Etant donnée que mon nom utilisateur est "jean-charles"
	Et mon mot de passe est "toto"
	Quand j'essaie de me conntecter à mon compte
	Alors la connexion échoue
	Et le message d'erreur est "Nom d'utilisateur ou mot de passe incorrect"

@ClientReconnu
Scénario: Connexion client - réussi
	Etant donnée que mon nom utilisateur est "JoffreyBaratheon"
	Et mon mot de passe est "KingOfTheSeven!"
	Quand j'essaie de me conntecter à mon compte
	Alors la connexion a réussi

#  Inscription

@InscriptionNominal
Scénario: Inscription client cas nominal
	Etant donnée que mes informations clientes sont les suivantes
	| NomUtilisateur    | MotDePasse        | Nom      | Prenom    | DateNaissance | NumeroPermisConduire |  DatePermisConduire | 
	| SansaStark        | KillerOfNightKing | Stark    |  Sansa  | Jan 2, 2003     |  439328389895        |   Mar 10, 2021      | 
	Quand j'essaie de m'inscrire
	Alors l'inscription réussi

@InscriptionClientExistant
Scénario: Inscription client déjà existant
	Etant donnée que mes informations clientes sont les suivantes
	| NomUtilisateur    | MotDePasse        | Nom       | Prenom    | DateNaissance | NumeroPermisConduire |  DatePermisConduire | 
	| JoffreyBaratheon  | KingOfTheSeven!   | Baratheon |  Joffrey  | Jan 2, 1999   |  439328589895        |   Mar 5, 2017       | 
	Quand j'essaie de m'inscrire
	Alors l'inscription échoue


#  Affichage disponibilités

@AffichageDisponibilitesNominal
Scénario: Cas simple affichage disponibilités plus de 25 ans
	Etant donnée que je suis le client suivant connecté
	| NomUtilisateur    | MotDePasse         |
	| DaenerysTargaryen  | @superKhaleesi!   |
	Et mes dates de réservation sont
	| DateDebut   | DateFinIncluse |
	| Jun 8, 2021 | Jun 10, 2021   |
	Quand je souhaite vérifier la disponibilité des véhicules
	Alors les véhicules disponibles sont
	| Immatriculation |
	|  CX-212-TK      |
	|  AZ-124-NS      |
	|  TZ-300-SK      |
	|  SS-117-SS      |

@AffichageDisponibilites22
Scénario: Cas affichage disponibilités 22 ans
	Etant donnée que je suis le client suivant connecté
	| NomUtilisateur    | MotDePasse        |
	| JoffreyBaratheon  | KingOfTheSeven!   |
	Et mes dates de réservation sont
	| DateDebut   | DateFinIncluse |
	| Jun 8, 2021 | Jun 10, 2021   |
	Quand je souhaite vérifier la disponibilité des véhicules
	Alors les véhicules disponibles sont
	| Immatriculation |
	|  CX-212-TK      |
	|  AZ-124-NS      |
	|  TZ-300-SK      |


#  Réservation (Les dates et le véhicules sont forcément valides car vérifier dans les disponibilités)

@ClientReservation
Scénario: Cas simple de réservation acceptée
	Etant donnée que je suis le client suivant connecté
	| NomUtilisateur    | MotDePasse        |
	| JoffreyBaratheon  | KingOfTheSeven!   |
	Et mes dates de réservation sont
	| DateDebut     |   DateFinIncluse  |
	| Jan 2, 1999   |  Mar 5, 2017      |
	Et le véhicule choisi a l'immatriculation "CX-212-TK"
	Et les km estimés de "400"
	Quand je demande la réservation
	Alors la réservation est au prix de "123" euros
