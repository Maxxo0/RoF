using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ScriptableCard : ScriptableObject
{
    public string cardTitle;
    public Sprite cardIcon;
    public Sprite cardBorder;
    public bool isUpgraded;
    public CardType cardType;
    public enum CardType { Attack, Shield, Special }

    public CardClass cardClass;
    public enum CardClass { Deathknight, Necromancer, Monster }


    public CardDescription cardDescription;
    public CardAmount cardCost;
    public CardAmount cardEffect;
    public CardAmount buffAmount;



    public CardRarity rarity;
    public enum CardRarity
    {
        Character,
        Common,
        Rare,
        Epic,
        Legendary
    }

    public int GetCardCostAmount()
    {
        if (!isUpgraded)
            return cardCost.baseAmount;
        else
            return cardCost.upgradedAmount;
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
        //public CardAmount buffAmount;
    }


}