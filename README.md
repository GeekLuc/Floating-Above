# Floating Above
Unity project of a game created during a back-to-school game jam in B3JV at HEAJ
https://geekluc.itch.io/floating-above

# Luca Rougefort / GeekLuc
## Etudiant B3JV programmation de jeux vidéo HEAJ

## **Jeux Floating Above**
    - Description : Project unity d'un jeux réalisé lors d'une game jam de rentrée scolaire en B3JV à l'HEAJ en 2024
    - Technologies : C#, Unity

## Contact
- **GitHub** : [GeekLuc](https://github.com/GeekLuc)
- **Email** : [luca.rougefort2001@gmail.com](luca.rougefort2001@gmail.com)

#Explication de quelque scripts
##Ballon.cs
Le script Ballon.cs gère le comportement d'un ballon attaché au joueur. Il permet de gonfler et dégonfler le ballon en fonction des entrées utilisateur, tout en ajustant la taille et la position du ballon. Le script inclut des effets visuels et sonores pour les actions de gonflage et de dégonflage, ainsi que des animations pour le personnage et le ballon. Il gère également les collisions avec le sol et les transitions entre les états de vol et de chute.

##Ventilo.cs
Le script Ventilo.cs pousse le joueur dans une direction spécifique lorsqu'il entre dans sa zone d'effet. Il utilise un BoxCollider pour détecter les collisions avec le joueur et applique une force de poussée configurable. Le script gère également les effets visuels et sonores lors de l'entrée et de la sortie du joueur dans la zone de poussée. Les directions de poussée peuvent être configurées pour pousser le joueur vers la gauche, la droite, le haut ou le bas avec également une force en paramétre.

##CheckPoint.cs
Le script CheckPoint.cs gère le comportement des points de contrôle dans un jeu Unity. Il détecte si le joueur a passé le point de contrôle et le déverrouille en conséquence. Lors du déverrouillage, il joue des effets visuels et sonores, et change la couleur du drapeau associé. Le script permet également de vérifier si le point de contrôle est déverrouillé et de récupérer sa position.

##Oiseaux.cs
Le script Oiseau.cs contrôle le comportement d'un oiseau ennemi dans un jeu Unity. Il déplace l'oiseau horizontalement et ajuste sa position verticale en fonction d'une sinusoïde pour simuler un mouvement de vol. Lorsque l'oiseau atteint une position minimale définie, il est détruit. Le script inclut également des effets sonores et visuels pour la destruction de l'oiseau. Les paramètres de vitesse, amplitude et fréquence du mouvement peuvent être configurés pour ajuster le comportement de l'oiseau.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Luca Rougefort / GeekLuc
## B3JV Student in Video Game Programming at HEAJ


## **Floating Above Game**
    - Description: Unity project of a game created during a back-to-school game jam in B3JV at HEAJ in 2024
    - Technologies: C#, Unity
    
##Contact
    - **GitHub**: GeekLuc
    - **Email**: luca.rougefort2001@gmail.com
    
#Explanation of Some Scripts
##Ballon.cs
The Ballon.cs script manages the behavior of a balloon attached to the player. It allows inflating and deflating the balloon based on user inputs, while adjusting the balloon's size and position. The script includes visual and sound effects for inflating and deflating actions, as well as animations for the character and the balloon. It also handles ground collisions and transitions between flying and falling states.

##Ventilo.cs
The Ventilo.cs script pushes the player in a specific direction when they enter its effect zone. It uses a BoxCollider to detect collisions with the player and applies a configurable push force. The script also manages visual and sound effects when the player enters and exits the push zone. The push directions can be configured to push the player left, right, up, or down, with a configurable force.

##CheckPoint.cs
The CheckPoint.cs script manages the behavior of checkpoints in a Unity game. It detects if the player has passed the checkpoint and unlocks it accordingly. Upon unlocking, it plays visual and sound effects and changes the color of the associated flag. The script also allows checking if the checkpoint is unlocked and retrieving its position.

##Oiseau.cs
The Oiseau.cs script controls the behavior of an enemy bird in a Unity game. It moves the bird horizontally and adjusts its vertical position based on a sine wave to simulate flying motion. When the bird reaches a defined minimum position, it is destroyed. The script also includes sound and visual effects for the bird's destruction. The speed, amplitude, and frequency parameters of the movement can be configured to adjust the bird's behavior.
