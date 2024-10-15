using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour
{
    #region DOT_Variables
    // Efectos activos o no
    public bool isPoisoned;
    public bool isBleeding;
    public bool isBurning;

    //Aqui las variables para determianr los turnos de los distintos debuffs
    public int poisonedCoun;
    public int poisonedCounMax = 100;
    public int bleedingCoun;
    public int bleedingCounMax = 10;
    public int burningCoun;
    public int burningCounMax = 3;

    // nivel de los debufos
    public int poisondeLvL;
    public int bleedingLvL;
    public int burningLvL;

    // daño de los debufos
    public int poisonedDMG = 5;
    public int bleedingDMG = 2;
    public int burningDMG = 10;

    #endregion

    #region Debuff_Variables

    bool DamageReduction;
    bool Vulnerability;

    int DamageReductionCount;
    int VulnerabilityCount;



    #endregion

    void DebuffsCunt() 
    {
        if (Vulnerability) 
        {
            VulnerabilityCount -= 1;
            if (VulnerabilityCount == 0) Vulnerability = false;
        }
        if (DamageReduction) 
        {
            DamageReductionCount -= 1;
            if (DamageReductionCount == 0) DamageReduction = false;
        }
    }

    #region ApplyDebuf

    public void OnAttack(int dmg, bool shadowDmg) 
    {
        if (DamageReduction) 
        {
            float a = dmg * 0.75f;
            dmg = (int)Mathf.Round(a);
        }
        gameObject.GetComponent<Buffs>().OnAttack(dmg, shadowDmg);
    }

    public void OnTakeDamage(int dmg, bool shadowDmg) 
    {
        if (Vulnerability) 
        {
            float a = dmg * 1.25f;
            dmg = (int)Mathf.Round(a);
        }
        gameObject.GetComponent<Buffs>().OnTakeDamage(dmg, shadowDmg);
    }

    void AddVulnerability(int counts = 1) 
    {
        Vulnerability = true;
        VulnerabilityCount += counts;
    }
    void AddDamageReduction(int counts = 1)
    {
        DamageReduction = true;
        DamageReductionCount += counts;
    }

    #endregion

    #region DOT
    void EndTurn()
    {
        Poisoned();
        Bleeding();
        Burning();
        DebuffsCunt();
    }

    void Poisoned()
    {
        if (isPoisoned)
        {
            gameObject.GetComponent<HealtManager>().TakeDMG(poisonedDMG * poisondeLvL, true);
            poisonedCoun -= 1;
            if (poisonedCoun == 0)
            {
                poisondeLvL = 0;
                isPoisoned = false;
            }
        }
    }

    void Bleeding()
    {
        if (isBleeding)
        {
            gameObject.GetComponent<HealtManager>().TakeDMG(Mathf.RoundToInt((bleedingDMG + (Mathf.RoundToInt(gameObject.GetComponent<HealtManager>().healthMaxAlter * 0.05f))) * (1 + (0.2f * bleedingLvL))), true);
            bleedingCoun -= 1;
            if (bleedingCoun == 0)
            {
                bleedingLvL = 0;
                isBleeding = false;
            }
        }
    }
    void Burning()
    {
        if (isBurning)
        {
            gameObject.GetComponent<HealtManager>().TakeDMG(burningDMG * burningLvL);
            burningCoun -= 1;
            if (burningCoun == 0)
            {

                burningLvL = 0;
                isBurning = false;
            }
        }
    }
    #endregion

    #region AplicarDOT

    public void ApplyPoison(int counts = 1) 
    {
        if (!isPoisoned) isPoisoned = true;
        poisondeLvL += counts;
        poisonedCoun = poisonedCounMax;
            
    }
    public void ApplyBleed(int counts = 1) 
    {
        if (!isBleeding) isBleeding = true;
        bleedingLvL += counts;
        bleedingCoun = bleedingCounMax;
    }

    public void ApplyBurn(int counts = 1) 
    {
        if(!isBurning) isBurning = true;
        burningLvL += counts;
        burningCoun = burningCounMax;  
    }
    #endregion

    #region ClearDOT
    public void ClearPoison(bool all=false)
    {
        if (!all)
        {
            if (isPoisoned)
            {
                poisondeLvL -= 1;
                if (poisondeLvL == 0)
                {
                    isPoisoned = false;
                    poisonedCoun = 0;
                }
            }
        }
        else 
        {
            poisondeLvL = 0;
            isPoisoned = false;
            poisonedCoun = 0;
        }

    }
    public void ClearBleed(bool all = false)
    {
        if (!all)
        {
            if (isBleeding)
            {
                bleedingLvL -= 1;
                if (bleedingLvL == 0)
                {
                    isBleeding = false;
                    bleedingCoun = 0;
                }
            }
        }
        else
        {
            bleedingLvL = 0;
            isBleeding = false;
            bleedingCoun = 0;
        }
    }

    public void ClearBurn(bool all = false)
    {
        if (!all)
        {
            if (isBurning)
            {
                burningLvL -= 1;
                if (burningLvL == 0)
                {
                    isBurning = false;
                    burningCoun = 0;
                }
            }
        }
        else
        {
            burningLvL = 0;
            isBurning = false;
            burningCoun = 0;
        }
    }
    #endregion


}
