using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// LevelUp.cs
/// 
/// Ce script gère le niveau du joueur et les points de compétence.
/// Il permet d’augmenter ou de diminuer le niveau, de suivre les points de compétence,
/// et d’afficher ces valeurs dans l’interface utilisateur via TextMeshProUGUI.
/// </summary>
public class LevelUp : MonoBehaviour
{
    // Variables statiques pour le niveau et les points de compétence.
    public static int level;
    public static int skillPoints;

    // Affichage du nombre de points dans l’UI.
    public TextMeshProUGUI skillField;

    /// <summary>
    /// Met à jour le texte affiché pour le niveau et les points de compétence.
    /// </summary>
    public static void SetLevel()
    {
        GameObject[] skillPrints = GameObject.FindGameObjectsWithTag("skillPoint");
        TextMeshProUGUI levelO = GameObject.Find("LevelNumber").GetComponent<TextMeshProUGUI>();
        levelO.text = level.ToString();

        // Met à jour tous les textes des points de compétence.
        foreach (GameObject text in skillPrints)
        {
            (text.GetComponent<TextMeshProUGUI>()).text = skillPoints.ToString();
        }
    }

    /// <summary>
    /// Incrémente le niveau et les points de compétence.
    /// </summary>
    public void LevelsUp()
    {
        level++;
        skillPoints++;
        SetLevel();
    }

    /// <summary>
    /// Décrémente le niveau et les points de compétence si possible.
    /// </summary>
    public void LevelsDown()
    {
        if(skillPoints > 0)
        {
            level--;
            skillPoints--;
            SetLevel();
        }
    }

    /// <summary>
    /// Initialisation du script.
    /// Appelé avant la première update.
    /// </summary>
    void Start()
    {
        skillField = GameObject.Find("Number").GetComponent<TextMeshProUGUI>();
        skillPoints = PlayerPrefs.GetInt("skill");
        level = skillPoints + 1;
        SetLevel();
    }

    /// <summary>
    /// Sauvegarde le nombre de points de compétence dans PlayerPrefs.
    /// Non utilisé pour le moment.
    /// </summary>
    /// <param name="skillPoints">Nombre de points à sauvegarder.</param>
    public void SaveSkill(int skillPoints)
    {
        PlayerPrefs.SetInt("skill", skillPoints);
    }
}
