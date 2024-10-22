using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Maxxo;


public class CardUI : MonoBehaviour
{
    BattleSceneManager battleSceneManager;
    public ScriptableCard card;
    public TMP_Text cardTitleText;
    public TMP_Text cardDescriptionText;
    public TMP_Text cardCostText;
    public Image cardImage;
    public Image cardBorder;

    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.actualClass == GameManager.CharacterClass.necromancer && card.name == ("Player_Attack"))
        {
            cardTitleText.text = ("Ligthning Bolt");
        }
        if (GameManager.Instance.actualClass == GameManager.CharacterClass.deathknight && card.name == ("Player_Attack"))
        {
            //card.cardTitle = ("Slash");
            cardTitleText.text = ("Slash");
        }
        if (GameManager.Instance.actualClass == GameManager.CharacterClass.necromancer && card.name == ("Player_HeavyAttack"))
        {
            cardTitleText.text = ("Thunder");
        }
        if (GameManager.Instance.actualClass == GameManager.CharacterClass.deathknight && card.name == ("Player_HeavyAttack"))
        {
            //card.cardTitle = ("Slash");
            cardTitleText.text = ("Bonk");
        }

        

    }

    //  [Header("Prefabs Elements")]
    // [SerializeField] private Image _cardimage;


    public void SelectCard()
    {
        //Debug.Log("card is selected");
        battleSceneManager.selectedCard = this;
    }

    public void DeselectCard()
    {
        //Debug.Log("card is deselected");
        battleSceneManager.selectedCard = null;
        //animator.Play("HoverOffCard");
    }
    public void Attack()
    {
        Destroy(gameObject);
    }

    public void LoadCard(ScriptableCard _card)
    {
        card = _card;
        //gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        cardTitleText.text = card.cardTitle;
        cardDescriptionText.text = card.GetCardDescriptionAmount();
        cardCostText.text = card.GetCardCostAmount().ToString();
        cardImage.sprite = card.cardIcon;
        cardBorder.sprite = card.cardBorder;
    }
    public void HoverCard()
    {
        if (battleSceneManager.selectedCard == null)
            Debug.Log("HoverCard");
            //animator.Play("HoverOnCard");
    }
    public void DropCard()
    {
        if (battleSceneManager.selectedCard == null)
            Debug.Log("DropCard");
        //animator.Play("HoverOffCard");
    }
    public void HandleDrag()
    {

    }
    public void HandleEndDrag()
    {
        if (battleSceneManager.energy < card.GetCardCostAmount())
            return;

       /* if (card.cardType == Card.CardType.Attack)
        {
            battleSceneManager.PlayCard(this);
            animator.Play("HoverOffCard");
        }
        else if (card.cardType != Card.CardType.Attack)
        {
            animator.Play("HoverOffCard");
            battleSceneManager.PlayCard(this);
        }*/
    }
}
