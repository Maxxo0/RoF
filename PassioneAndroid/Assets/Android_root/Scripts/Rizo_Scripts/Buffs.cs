using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{

    #region Buff_Variables

    bool DamageStrength;
    bool Durability;

    int DamageStrengthCount;
    int DurabilityCount;

    #endregion
    void BuffsCunt()
    {
        if (Durability)
        {
            DurabilityCount -= 1;
            if (DurabilityCount == 0) Durability = false;
        }
        if (DamageStrength)
        {
            DamageStrengthCount -= 1;
            if (DamageStrengthCount == 0) DamageStrength = false;
        }
    }
    #region ApplyBuff

    public void OnAttack(int dmg, bool shadowDmg)
    {
        if (DamageStrength)
        {
            float a = dmg * 1.25f;
            dmg = (int)Mathf.Round(a);
        }

    }

    public void OnTakeDamage(int dmg, bool shadowDmg)
    {
        if (Durability)
        {
            float a = dmg * 0.75f;
            dmg = (int)Mathf.Round(a);
        }
        gameObject.GetComponent<HealtManager>().TakeDMG(dmg, shadowDmg);
    }

    public void AddDurability(int counts = 1)
    {
        Durability = true;
        DurabilityCount += counts;
    }
    public void AddDamageStrength(int counts = 1)
    {
        DamageStrength = true;
        DamageStrengthCount += counts;
    }

    #endregion
}
