






using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public int health;
    public int healthMaxBase;
    public int healthMaxAlter;
    public int armor;
    public bool isAlive;
    public ScriptableCard cardDrop;
    public ScriptableCard[] cardsDrops;
    BattleSceneManager battleSceneManager;
    public enum Type { player, enemy }
    public Type type;

    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
    }

    private void Start()
    {
        health = healthMaxBase;
    }
    private void Update()
    {
        if (isAlive == false && type == Type.enemy) { eDead(); }
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

    public void TargetAttack(int dmg, bool shadowDmg) 
    {
    
    
    }
    void eDead() 
    {
        cardDrop = cardsDrops[Random.Range(0,10)];
        battleSceneManager.DisplayCardEnemy(cardDrop);
        gameObject.SetActive(false);
    }
}
