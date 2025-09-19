using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// UnlockSkill.cs
/// 
/// Ce script gère le déblocage des compétences dans l’arbre de compétences.
/// Il permet :
/// — De dépenser des points de compétence pour débloquer une compétence.
/// - De mettre à jour l’état des compétences enfants après déblocage.
/// </summary>
public class UnlockSkill : MonoBehaviour
{
    // Identifiant de la compétence actuellement sélectionnée.
    public static int skillId;

    /// <summary>
    /// Débloque les compétences enfants d’une compétence parent donnée.
    /// </summary>
    /// <param name="iDParent">Identifiant de la compétence parent.</param>
    /// <param name="allSkills">Tableau de tous les GameObjects représentant les compétences.</param>
    public void UnlockChild(int iDParent, GameObject[] allSkills)
    {
        foreach (GameObject skillChild in allSkills)
        {
            SetSkillInfos skillCI = (SetSkillInfos)skillChild.GetComponent(typeof(SetSkillInfos));

            // Vérifie si la compétence enfant a pour parent la compétence sélectionnée.
            if (iDParent == skillCI.ParentId)
            {
                Image[] children2 = skillChild.GetComponentsInChildren<Image>();
                foreach (Image image2 in children2)
                {
                    if (image2.name == "Icone")
                    {
                        ChangeState skillCS = (ChangeState)image2.GetComponent(typeof(ChangeState));

                        // Si la compétence enfant est verrouillée, on la débloque.
                        if (skillCS.state == 0)
                        {
                            skillCS.OnButtonClick();
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Dépense des points de compétence pour débloquer la compétence sélectionnée.
    /// </summary>
    public void SpendSkill()
    {
        int skillPoints = LevelUp.skillPoints;
        GameObject[] allSkills = GameObject.FindGameObjectsWithTag("skill");

        foreach (GameObject skill in allSkills)
        {
            SetSkillInfos skillI = (SetSkillInfos)skill.GetComponent(typeof(SetSkillInfos));
            int cost = skillI.skillCost;

            // Vérifie si c’est la compétence sélectionnée et si le joueur a assez de points
            if (skillId == skillI.SkillId && skillPoints >= cost)
            {
               
                Image[] children = skill.GetComponentsInChildren<Image>();
                foreach (Image image in children)
                {
                    if(image.name == "Icone")
                    {
                        ChangeState skillS = (ChangeState)image.GetComponent(typeof(ChangeState));
                        
                        // Si la compétence est disponible, on la débloque
                        if (skillS.state == 1)
                        {
                            skillS.OnButtonClick();

                            // Met à jour l'affichage du niveau et des points
                            LevelUp.skillPoints = skillPoints - cost;
                            GameObject level = GameObject.Find("Level");
                            LevelUp.SetLevel();

                            TextMeshProUGUI detail = GameObject.Find("Details").GetComponent<TextMeshProUGUI>();
                            detail.text = "Already possessed";

                            // Débloque toutes les compétences enfants
                            int iDParent = skillId;
                            UnlockChild(iDParent, allSkills);


                        }
                    }
                }
            }
        }
    }
}
