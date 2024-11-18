






using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public bool noDMG;
    public int health;
    public int healthMaxBase;
    public int healthMaxAlter;
    public int armor;
    public bool isAlive;
    public bool isDead;
    public ScriptableCard cardDrop;
    public ScriptableCard[] cardsDrops;
    BattleSceneManager battleSceneManager;
    Animator animator;
    public enum Type { player, enemy }
    public Type type;
    Enemy enemy;

    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        health = healthMaxBase;
    }
    private void Update()
    {
        if (isAlive == false && type == Type.enemy) { eDead(); }
        if (isAlive == false && type == Type.player) { Dead(); }
    }

    public void HealthUp(int healthUp) 
    {
        if ((health + healthUp) > healthMaxAlter) health = healthMaxAlter;
        else health += healthUp;
    }

    public void ArmorUp(int armorUp)
    {
        armor += armorUp;
    }

    //Aqui se gestiona el recibir daño de todos los lados
    
    
    
    public void TakeDMG(int dmg, bool shadowDmg=false) 
    {
        if (noDMG) return;
        if (!shadowDmg || armor > 0)
        {
            if ((armor - dmg) > 0) { armor -= dmg; }
            else
            {
                dmg -= armor;
                armor = 0;
                if ((health - dmg) <= 0) isAlive = false;
                else health -= dmg;
            }

        }
        else
        {

            if ((health - dmg) <= 0) isAlive = false;
            else health -= dmg;
        }
    }
    void eDead() 
    {
        if (!isDead) 
        {
            isDead = true;
            GameManager.Instance.target = null;
            cardDrop = cardsDrops[Random.Range(0, 10)];
            battleSceneManager.DisplayCardEnemy(cardDrop);
            GameManager.Instance.playerDeck.Add(cardDrop);
            GameManager.Instance.deathEnemies++;
            
            if (enemy.enemyT == Enemy.EnemyType.Enemy1) { GameManager.Instance.canE1 = false; }
            if (enemy.enemyT == Enemy.EnemyType.Enemy2) { GameManager.Instance.canE2 = false; }
            if (enemy.enemyT == Enemy.EnemyType.Enemy3) { GameManager.Instance.canE3 = false; }
            animator.SetTrigger("Death");
        }
    }

    void Dead()
    {
        if (!isDead) 
        {
            isDead = true;
            Debug.Log("You die");
            gameObject.SetActive(false);
        }
    }

    public void Death()
    {
        if (GameManager.Instance.maxEnemies == GameManager.Instance.deathEnemies)
        {
            GameManager.Instance.stateS++;
            SceneManager.Instance.RewardPanel();
        }
        gameObject.SetActive(false);
    }
}
