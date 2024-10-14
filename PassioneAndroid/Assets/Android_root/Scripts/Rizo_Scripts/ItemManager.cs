using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Items_pasivos
    bool Idolo_Menor;
    bool Idolo_Mayor;

    public bool Anillo_de_plagas;
    bool Tarro_de_la_gula;
    int Tarro_de_la_gulaBase=2;
    int Tarro_de_la_gulaIncrement=2;
    #endregion


    #region Items_de_arranque_de_turno

    //los 2 primes turnos con mas fuerza
    bool Anillo_de_Impulso;
    bool Lagrima;
    bool Yelmo;
    bool Escudo_Maestro;
    bool Manzana;
    bool Manzana_Dorada;
    #endregion

    public void PlayerCardAttack(int dmg, bool shadowDmg) 
    {
        if (Idolo_Menor) dmg +=4;
        if (Idolo_Mayor) dmg +=8;
        
        
        gameObject.GetComponent<HealtManager>().TargetAttack(dmg, shadowDmg);
        gameObject.GetComponent<HealtManager>().HealthUp(Tarro_de_la_gulaIncrement);
        if(Tarro_de_la_gulaIncrement<10)Tarro_de_la_gulaIncrement += 2;
    }


    public void CombatStart() 
    {
        if (Anillo_de_Impulso) gameObject.GetComponent<Buffs>().AddDamageStrength(2);
        //if (Lagrima) gameObject.GetComponent<>().AddStartMana();
        if (Yelmo) gameObject.GetComponent<HealtManager>().ArmorUp(5);
        if (Escudo_Maestro) gameObject.GetComponent<HealtManager>().ArmorUp(15);
        if (Manzana) gameObject.GetComponent<HealtManager>().healthMaxAlter = (int)Mathf.Round(gameObject.GetComponent<HealtManager>().healthMaxBase * 1.10f);
        if (Manzana_Dorada) gameObject.GetComponent<HealtManager>().healthMaxAlter = (int)Mathf.Round(gameObject.GetComponent<HealtManager>().healthMaxBase * 1.25f);
    }
}
