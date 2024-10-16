using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardUI : MonoBehaviour
{

    private Card card;

    //  [Header("Prefabs Elements")]
    // [SerializeField] private Image _cardimage;
    public void Attack()
    {
        Destroy(gameObject);
    }

    public void LoadCard(Card _card)
    {
        card = _card;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //cardTitleText.text = card.cardTitle;
        //cardDescriptionText.text = card.GetCardDescriptionAmount();
        //cardCostText.text = card.GetCardCostAmount().ToString();
        //cardImage.sprite = card.cardIcon;
    }
}
