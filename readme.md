# Projet ChessBras

Afin de t'initier aux concepts de base de la programmation orientée objet en C#, tu vas programmer ton propre jeu d'échec pas vraiment fonctionnel!!!

## Objectif

Comprendre le principe de l'héritage et tous les concepts qui s'y rattachent. (override, virtual, classe parent et enfant, etc...)

Continuer l'apprentissage des concepts de visibilité et d'abstraction.

S'initier au polymorphisme (même si ce n'est pas dans l'objectif du cours, on en fait alors...)

## Descrption de la demande.

À partir du diagrame UML, tu dois créer un jeu d'échec qui permettra
- De déplacer les pièces

## Voici les différentes étapes du projet

### La création du plateau de jeu.

# Spécification du jeu d'échecs

À partir de l'énoncé ci-dessous, identifie toutes les classes et ajoutes les dans sur lucid chart.

Tu ne dois pas relier les classes ni identifier les méthodes ou les attributs. Cela se fera ultérieurement.
## Plateau de jeu
Le jeu d'échecs se joue sur un plateau. Chacune des pièces connaît son emplacement sur le plateau de jeu en fonction de la rangée et de la colonne. L'emplacement en haut à gauche est row 0 et col 0, et en bas à droite est row 7 et col 7. Une pièce peut être blanche ou noire. Le plateau offre donc 64 emplacements disponibles. La combinaison d'une rangée et d'une colonne se nomme des coordonées.

## Pièces
Chaque joueur commence avec 16 pièces :
- 8 Pawns (pions)
- 2 Rooks (tours)
- 2 Knights (cavaliers)
- 2 Bishops (fous)
- 1 Queen (dame)
- 1 King (roi)

## Position initiale
### Pièces blanches (rangées 0 et 1)

- Rangée 0 : Rook(0,0), Knight(0,1), Bishop(0,2), Queen(0,3), King(0,4), Bishop(0,5), Knight(0,6), Rook(0,7)
- Rangée 1 : Pawns aux positions (1,0), (1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7)

### Pièces noires (rangées 6 et 7)

- Rangée 7 : Rook(7,0), Knight(7,1), Bishop(7,2), Queen(7,3), King(7,4), Bishop(7,5), Knight(7,6), Rook(7,7)
- Rangée 6 : Pawns aux positions (6,0), (6,1), (6,2), (6,3), (6,4), (6,5), (6,6), (6,7)

## Règles de déplacement

### Pawn (pion)
- Avance d'une case vers l'avant
- Lors de son premier mouvement, peut avancer de deux cases
- Capture en diagonale vers l'avant d'une case
- Peut effectuer une prise "en passant" si un pion adverse vient d'avancer de deux cases à côté de lui

### Rook (tour)
- Se déplace horizontalement ou verticalement
- Peut parcourir plusieurs cases dans ces directions
- Ne peut pas sauter par-dessus d'autres pièces

### Knight (cavalier)
- Se déplace en "L" : deux cases dans une direction (horizontale ou verticale) puis une case perpendiculairement
- Seule pièce pouvant sauter par-dessus d'autres pièces

### Bishop (fou)
- Se déplace en diagonale
- Peut parcourir plusieurs cases dans ces directions
- Ne peut pas sauter par-dessus d'autres pièces

### Queen (dame)
- Combine les mouvements de la tour et du fou
- Peut se déplacer horizontalement, verticalement et en diagonale
- Peut parcourir plusieurs cases dans ces directions
- Ne peut pas sauter par-dessus d'autres pièces

### King (roi)
- Se déplace d'une seule case dans toutes les directions (horizontale, verticale, diagonale)

## Règles générales
- Les blancs jouent en premier
- Les joueurs jouent à tour de rôle
- Une pièce ne peut pas se déplacer sur une case occupée par une pièce de la même couleur
- Une pièce peut capturer une pièce adverse en se déplaçant sur sa case
- Une pièce ne peut pas mettre son propre roi en danger


## Fonctionnement interne du jeu 
- Voir le diagramme de séquence qui sera fourni.