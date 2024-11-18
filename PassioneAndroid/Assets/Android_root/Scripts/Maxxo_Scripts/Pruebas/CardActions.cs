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
        public void PerformAction(ScriptableCard _card, GameObject _target)
        {
            card = _card;
            GameManager.Instance.target = _target;

            switch (card.cardTitle)
            {
                case "Player Attack":
                    Debug.Log("Ataca");
                    AttackEnemy();
                    break;
                case "Player Heavy":
                    AttackEnemy();
                    break;
                case "Skeleton Attack":
                    AttackEnemy();
                    break;
                case "Skeleton Armor":
                    Block();
                    break;
                case "Spider Bite":
                    AttackEnemy();
                    break;
                case "Spider Web":
                    Stun();
                    break;
                case "Mimic Bite":
                    AttackEnemy();
                    break;
                case "Mimic Loot":
                    TakeItem();
                    break;
                case "Mimic Surprise":
                    Stun();
                    break;
                case "Demon Attack":
                    AttackEnemy();
                    BurnEnemy();
                    break;
                case "Demon Drain":
                    DrainLife();
                    break;
                case "Eye Beam":
                    TrueDamage();
                    break;
                case "Eye Bite":
                    AttackEnemy();
                    break;

            }
        }
    

        private void AttackEnemy()
        {
            
            int totalDamage = card.GetCardEffectAmount();
            totalDamage=GameManager.Instance.player.GetComponent<Debuffs>().OnAttack(totalDamage);
            HealtManager healtManager = GameManager.Instance.target.GetComponent<HealtManager>();
            healtManager.TakeDMG(totalDamage);

            Debug.Log("Ataque");
        }

        private void Block()
        {
            int armor = card.GetCardEffectAmount();

            HealtManager healtManager = GameManager.Instance.target.GetComponent<HealtManager>();
            healtManager.ArmorUp(armor);
        }

        public void Stun()
        {

        }

        public void TakeItem()
        {

        }

        public void BurnEnemy()
        {
            GameManager.Instance.target.GetComponent<Debuffs>().ApplyBurn();
        }
        public void PoisonEnemy()
        {
            GameManager.Instance.target.GetComponent<Debuffs>().ApplyPoison();
        }
        public void BleeedEnemy()
        {
            GameManager.Instance.target.GetComponent<Debuffs>().ApplyBleed();
        }

        public void DrainLife()
        {

        }

        public void TrueDamage()
        {

        }

        
    }
}
