# RPG Skill Tree Prototype

## Description

**Projet Unity : Arbre de compétences RPG**  
Ce projet est un prototype d’arbre de compétences interactif pour RPG, développé sous **Unity 2020.1.6f1**.

**Objectif :** Permettre au joueur de débloquer des capacités en dépensant des points de compétence.  

**Fonctionnalités principales :**  
- Système de niveau et de points de compétence.
- Arbre de compétences interactif avec UI et icônes.
- Scripts pour simuler la montée en niveau et l’allocation de points. 
- Déblocage des compétences selon le parent/enfant si les conditions sont remplies.
- Changement visuel des compétences selon l’état : verrouillée, activée, possédée (ChangeState.cs)
- Visualisation des points dans l’éditeur Unity (SkillEditor.cs)
- Sauvegarde des points de compétence via PlayerPrefs (non utilisée actuellement)

## Structure du projet

- `Assets/Animator/` : graph de transition entre les différents états d'une compétence. 
- `Assets/Scripts/` : scripts C# pour gérer le gameplay et l’arbre de compétences.  
- `Assets/Prefabs/` : prefabs pour les compétences de l’arbre.  
- `Assets/Resources/` : images, icônes et autres assets utilisés dans l’UI.  
- `Assets/Scenes/` : scènes Unity, notamment la scène principale de l’arbre.  
- `ProjectSettings/` : paramètres du projet Unity.  

## Pré-requis

- Unity **2020.1.6f1** (recommandé pour compatibilité avec le projet).  
- TextMeshPro installé (Unity Package Manager)
- Système d’exploitation : Windows, Mac ou Linux compatible avec Unity 2020.  

## Installation et utilisation

1. **Cloner le projet :**  

```bash
git clone https://github.com/Mehdi-Mns/RPG-Skill-Tree-Prototype
```

2.Ouvrir le projet dans Unity 2020.1.6f1.

3.Vérifier que le package TextMeshPro est installé.

4.Appuyer sur Play pour tester le prototype.

## Pistes d'améliorations :

Le projet est bien fonctionnel et l'application est responsive et l'exercice m'a extrêmement motivé, mais on peut aller encore plus loin: 
- Ajouter plus de dépendance entre les skills (en ajoutant par exemple une liste de parents au lieu d'un seul) ce qui permettrait d'avoir besoin de débloquer plusieurs skills pour avoir accès à un nouveau.
- Pouvoir améliorer plusieurs fois 1 skill qui donnerait des effets améliorés et d'avoir accès à d'autres skills. 
- Ajouter des skills spéciaux (surtout en fin de branches) qui débloquerais une nouvelles branches ou un nouvel arbre de compétence.

## Licence
- Projet pedagogique – usage libre pour consultation, tests et apprentissage.
