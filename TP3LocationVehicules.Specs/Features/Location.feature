Fonctionnalité: Location

Contexte:
	Etant donnée que les clients suivants existent
	| NomUtilisateur    | MotDePasse        |
	| JoffreyBaratheon  | KingOfTheSeven!   |
	| DaenerysTargaryen | @superKhaleesi    |
	| JonSnow           | !bastardButProud  |
	| TheonGreyjoy      | eunuchForEver:)   |


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


