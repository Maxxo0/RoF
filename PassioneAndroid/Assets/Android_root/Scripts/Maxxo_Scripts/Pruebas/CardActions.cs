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

            switch (card.cardTitle)
            {
                case "Ligthning Bolt":
                    AttackEnemy();
                    break;
                case "Slash":
                    AttackEnemy();
                    break;
                case "Thunder":
                    AttackEnemy();
                    break;
                case "Bonk":
                    AttackEnemy();
                    break;
                case "Skeleton Attack":
                    AttackEnemy();
                    break;
                case "Skeleton Armor":
                    Block();
                    break;
            }
        }
    

        private void AttackEnemy()
        {
            int totalDamage = card.GetCardEffectAmount();
            
            //target.TakeDamage(totalDamage);

            Debug.Log("Ataque");
        }

        private void Block()
        {

        }
    }
}
