using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ChangeState.cs
/// 
/// Ce script gère l'état visuel d'une compétence dans l'arbre de compétences.
/// Il permet :
/// — De changer l'apparence de la compétence en fonction de son état :
/// 0 = verrouillée, 1 = activée, 2 = déjà possédée.
/// - De mettre à jour les couleurs et sprites liés à la compétence.
/// - De gérer l'animation via un Animator attaché à l'objet.
/// </summary>
public class ChangeState : MonoBehaviour
{
    public int state;
    public Sprite activated;
    public Sprite disabled;
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Met à jour l'Animator avec l'état actuel.
    /// </summary>
    /// <param name="st">État à appliquer.</param>
    public void SetState(int st)
    {
        animator.SetInteger("State", st);
    }

    /// <summary>
    /// Méthode appelée lorsqu'on clique sur la compétence.
    /// </summary>
    public void OnButtonClick()
    {
        UpState(state);
        state++;
        SetState(state);
    }

    /// <summary>
    /// Met à jour visuellement la compétence selon l'état.
    /// </summary>
    /// <param name="st">État actuel à appliquer.</param>
    public void UpState(int st)
    {
        Image icone = GetComponent<Image>();
        Image back = icone.transform.parent.GetComponent<Image>();
        Image circle = back.transform.parent.GetComponent<Image>();
        Image skill = circle.transform.parent.GetComponent<Image>();
        Image[] children = skill.GetComponentsInChildren<Image>();
        Image lign = null;
        
        switch (st)
        {
            case 0 : // Compétence verrouillée
                icone.sprite = disabled;
                back.color = Color.black;
                circle.color = Color.white;
                foreach (Image image in children)
                {
                    if (image.name == "Line")
                    {
                        lign = image.GetComponentInChildren<Image>();
                        lign.color = new Color(154, 0, 105);
                    }
                }
                break;
            case 1: // Compétence activée
                icone.sprite = activated;
                circle.color = new Color(154, 0, 105);
                break;
            case 2: // Déjà possédée
                state--;
                break;
        }
    }

    /// <summary>
    /// Initialisation du script.
    /// Met à jour l'état de la compétence selon la valeur initiale de "state"
    /// </summary>
    void Start()
    {
        for(int stUp = 0; stUp < state; stUp++)
        {
            UpState(stUp);
        }
    }
}
