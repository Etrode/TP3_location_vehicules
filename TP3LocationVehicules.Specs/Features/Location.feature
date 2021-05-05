Fonctionnalité: Location

Contexte:
	Etant donnée que les clients suivants existent
	| NomUtilisateur    | MotDePasse        | Nom       | Prenom    | DateNaissance | DatePermisConduire | NumeroPermisConduire |
	| JoffreyBaratheon  | KingOfTheSeven!   | Baratheon |  Joffrey  | Jan 2, 1999   |  Mar 5, 2017       |  439328589895        |
	| DaenerysTargaryen | @superKhaleesi    | Targaryen | Daenerys  | Jun 3, 1985   |  Apr 1, 1996       |  P3L932P18589895     |
	| JonSnow           | !bastardButProud  |  Snow     |    Jon    | Apr 15, 1978  |  Jan 1, 1998       |  678304858382        |
	| TheonGreyjoy      | eunuchForEver:)   |  Greyjoy  |   Theon   | Nov 1, 1970   |  Aug 1, 1991       |  084736298473        |


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

@ClientReservationNominal
Scénario: Cas simple de réservation acceptée
	Etant donnée que je suis le client suivant
	| NomUtilisateur    | MotDePasse        | Nom       | Prenom    | DateNaissance | DatePermisConduire | NumeroPermisConduire |
	| TheonGreyjoy      | eunuchForEver:)   |  Greyjoy  |   Theon   | Nov 1, 1970   |  Aug 1, 1991       |  084736298473        |
	Et que mes dates de réservation sont
	| DateDebut     |   DateFinIncluse  |
	| DateDebut     |   DateFin         |
	| Jan 2, 1999   |  Mar 5, 2017      |
	Et que le véhicule souhaité a l'immatriculation P3L932P18589895
	Et que le véhicule souhaité est disponible
	Et que je n'ai pas d'autres réservations en cours
	Alors la réservation est acceptée
