using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public string cardTitle;
    public bool isUpgraded;
    public CardDescription cardDescription;
    public CardAmount cardCost;
    public CardAmount cardEffect;
    public CardAmount buffAmount;
    public Sprite cardIcon;
    public CardType cardType;
    public enum CardType { Attack, Skill, Power }
    public CardClass cardClass;
    public enum CardClass { ironChad, silent, colorless, curse, status }
    public CardTargetType cardTargetType;
    public enum CardTargetType { self, enemy };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetCardCostAmount()
    {
        if (!isUpgraded)
            return cardCost.baseAmount;
        else
            return cardCost.upgradedAmount;
    }
    public int GetCardEffectAmount()
    {
        if (!isUpgraded)
            return cardEffect.baseAmount;
        else
            return cardEffect.upgradedAmount;
    }
    public string GetCardDescriptionAmount()
    {
        if (!isUpgraded)
            return cardDescription.baseAmount;
        else
            return cardDescription.upgradedAmount;
    }
    public int GetBuffAmount()
    {
        if (!isUpgraded)
            return buffAmount.baseAmount;
        else
            return buffAmount.upgradedAmount;
    }
}
[System.Serializable]
public struct CardAmount
{
    public int baseAmount;
    public int upgradedAmount;
}
[System.Serializable]
public struct CardDescription
{
    public string baseAmount;
    public string upgradedAmount;
}
[System.Serializable]
public struct CardBuffs
{
    //public Buff.Type buffType;
    public CardAmount buffAmount;
}

