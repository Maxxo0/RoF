using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxxo
{
    [CreateAssetMenu]
    public class Character : ScriptableObject
    {
        public CharacterClass characterClass;
        public enum CharacterClass { deathknight, nigromancer }
        public GameObject characterPrefab;
        public Relic startingRelic;
//        public Sprite splashArt;
        public List<Card> startingDeck;
    }
}