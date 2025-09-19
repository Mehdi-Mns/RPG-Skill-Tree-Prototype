using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// SkillEditor.cs
/// 
/// Ce script est un **éditeur personnalisé Unity** pour le composant LevelUp.
/// Il permet d'afficher dans l'Inspector le nombre de points de compétence 
/// du joueur, et un message si aucun point n'est présent.
/// 
/// Il est placé dans un dossier Editor pour qu'Unity le reconnaisse comme outil d'édition.
/// </summary>
[CustomEditor(typeof(LevelUp))] // On spécifie que cet éditeur est pour le script LevelUp
public class SkillEditor : Editor
{
    private void OnGUI()
    {
        // On récupère la référence de l'objet LevelUp actuellement sélectionné
        LevelUp playerSkill = (LevelUp)target;
        
        Handles.BeginGUI();

        // Récupère le texte du champ de skill (nombre de points)
        string showedSkill = playerSkill.skillField.text;
        if (showedSkill.Trim() == "")
        {
            GUILayout.Label("Skill is empty");
        }
        else
        {
            GUILayout.Label("The number of skill points is " + showedSkill);
        }

    }
}
