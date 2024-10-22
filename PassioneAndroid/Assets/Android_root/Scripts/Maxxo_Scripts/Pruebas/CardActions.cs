using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxxo
{ 
public class CardActions : MonoBehaviour
    {
        ScriptableCard card;
        GameObject tr;
        BattleSceneManager battleSceneManager;

        private void Awake()
        {
            battleSceneManager = FindObjectOfType<BattleSceneManager>();
            
        }

        

        // Start is called before the first frame update
        public void PerformAcrion(ScriptableCard _card, GameObject _target)
        {
            card = _card;
            GameManager.Instance.target = _target;
        }
    

        private void AttackEnemy()
        {
            /*int totalDamage = card.GetCardEffectAmount()+player.strength.buffValue;
            if(target.vulnerable.buffValue>0)
            {
                float a = totalDamage*1.5f;
                Debug.Log("incrased damage from "+totalDamage+" to "+(int)a);
                totalDamage = (int)a;
            }
            target.TakeDamage(totalDamage);*/

            Debug.Log("Ataque");
        }

    }
}
