using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ScriptableCard : ScriptableObject
{
    [field: SerializeField] public string cardName { get; private set; }
    [field: SerializeField, TextArea] public string cardDescription { get; private set;}

    [field: SerializeField] public int playCost { get; private set; }

    [field: SerializeField] public Sprite image { get; private set; }





    public enum CardClass
    {
        Deathknight,
        Necromancer,
        Monster
    }

    public enum CardEffectType
    {
        Attack,
        Shield,
        Special,
        LifeSteal
    }

    public enum CardRarity
    {
        Character,
        Common,
        Rare,
        Epic,
        Legendary
    }



}
