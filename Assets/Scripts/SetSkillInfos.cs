using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// SetSkillInfos.cs
/// 
/// Ce script gère les informations et l'affichage d'une compétence dans l'arbre de compétences.
/// Lorsqu'une compétence est sélectionnée, il met à jour l'UI pour afficher :
/// - le titre et la description de la compétence
/// - le coût en points
/// - l'image associée
/// - l'état de déblocage (possédée, disponible, ou verrouillée)
/// 
/// Attaché à chaque GameObject représentant une compétence dans l'arbre.
/// </summary>
public class SetSkillInfos : MonoBehaviour
{
    // Informations de la compétence.
    public int SkillId;
    public int ParentId;
    public int skillCost;
    public string skillTitle;
    public string skillDescription;
    public Sprite skillImage;
    public int ind;

    /// <summary>
    /// Affiche les informations de cette compétence dans l'UI
    /// </summary>
    public void ShowDescription()
    {
        Image skill = GetComponent<Image>();
        skill.color = new Color(1, 0, 1);

        // Compétence séléctionnée, depuis le script UnlockSkill.
        UnlockSkill.skillId = SkillId;

        // Nombre de points de compétence disponibles depuis le script LevelUp.
        int skillPoints = LevelUp.skillPoints;

        // Récupère toutes les compétences pour mettre à jour leur état visuel.
        GameObject[] allSkills = GameObject.FindGameObjectsWithTag("skill");
        foreach (GameObject OtherSkill in allSkills)
        {
            SetSkillInfos skillI = (SetSkillInfos)OtherSkill.GetComponent(typeof(SetSkillInfos));
            if (skillI.SkillId != SkillId)
                (OtherSkill.GetComponent<Image>()).color = new Color(41.0f/255.0f, 35.0f/255.0f, 34.0f/255.0f);
        }

        // Mise à jour des différents éléments de l'UI.
        TextMeshProUGUI descriptionTitle = GameObject.Find("DescriptionTitle").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI description = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
        Image image = GameObject.Find("DescriptionImage").GetComponent<Image>();
        TextMeshProUGUI cost = GameObject.Find("SkillCost").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI costDesc = GameObject.Find("CostDescription").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI detail = GameObject.Find("Details").GetComponent<TextMeshProUGUI>();

        // Remplissage des informations
        descriptionTitle.text = skillTitle;
        description.text = skillDescription;
        image.sprite = skillImage;
        costDesc.text = "Skill Cost :";
        cost.text = skillCost.ToString();

        // Vérifie l'état de chaque icône enfant pour afficher le détail requis
        Image[] children = skill.GetComponentsInChildren<Image>();
        foreach (Image Image in children)
        {
            if (Image.name == "Icone")
            {
                ChangeState skillCS = (ChangeState)Image.GetComponent(typeof(ChangeState));
                SetSkillInfos skillI = (SetSkillInfos)skill.GetComponent(typeof(SetSkillInfos));
                switch (skillCS.state)
                {
                    case 0: // verrouillée, nécessite un prérequis
                        string skillName ="";
                        foreach (GameObject OtherSkill in allSkills)
                        {
                            SetSkillInfos skillPI = (SetSkillInfos)OtherSkill.GetComponent(typeof(SetSkillInfos));
                            if (skillI.ParentId != skillPI.SkillId)
                                skillName = skillPI.skillTitle;
                        }
                        detail.text = "Need to unlock : " + skillName;
                        break;
                    case 1: // disponible
                        detail.text = "";
                        break;
                    case 2: // déjà possédée
                        detail.text = "Already possessed";
                        break;
                }
            }
        }
    }
}
