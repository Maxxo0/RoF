






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

    private void Update()
    {
        if (isAlive == false) { dead(); }
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
    void dead() 
    {
        gameObject.SetActive(false);
    }
}
