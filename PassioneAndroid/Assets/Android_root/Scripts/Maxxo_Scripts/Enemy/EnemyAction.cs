using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxxo
{
    [System.Serializable]
    public class EnemyAction
    {
        public IntentType intentType;
        public enum IntentType { Attack, Block, StrategicBuff, StrategicDebuff, AttackDebuff }
        public int amount;
        public int debuffAmount;
        public Buff.Type buffType;
        public int chance;
        public Sprite icon;
    }
}
