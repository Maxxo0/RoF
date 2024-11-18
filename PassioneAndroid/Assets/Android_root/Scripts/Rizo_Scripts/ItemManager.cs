using Maxxo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Buffs))]
[RequireComponent(typeof(HealtManager))]
public class ItemManager : MonoBehaviour
{
    #region Items_pasivos
    public bool Idolo_Menor;
    public bool Idolo_Mayor;
    public bool Anillo_de_plagas;
    bool Tarro_de_la_gula;
    int Tarro_de_la_gulaBase=2;
    int Tarro_de_la_gulaIncrement=2;
    #endregion


    #region Items_de_arranque_de_turno

    //los 2 primes turnos con mas fuerza
    public bool Anillo_de_Impulso;
    public bool Lagrima;
    public bool Yelmo;
    public bool Escudo_Maestro;
    public bool Manzana;
    public bool Manzana_Dorada;
    #endregion

    public Image Idolo_Menor_Image;
    public Image Idolo_Mayor_Image;
    public Image Anillo_de_plagas_Image;
    public Image Tarro_de_la_gula_Image;
    public Image Anillo_de_Impulso_Image;
    public Image Lagrima_Image;
    public Image Yelmo_Image;
    public Image Escudo_Maestro_Image;
    public Image Manzana_Image;
    public Image Manzana_Dorada_Image;
    public void ActivarItemAleatorio()
    {
        // Diccionario de booleanos y acciones para activar sus imágenes
        var items = new Dictionary<string, System.Action>
        {
            { nameof(Idolo_Menor), () => ActivarItem(ref Idolo_Menor, Idolo_Menor_Image) },
            { nameof(Idolo_Mayor), () => ActivarItem(ref Idolo_Mayor, Idolo_Mayor_Image) },
            { nameof(Anillo_de_plagas), () => ActivarItem(ref Anillo_de_plagas, Anillo_de_plagas_Image) },
            { nameof(Tarro_de_la_gula), () => ActivarItem(ref Tarro_de_la_gula, Tarro_de_la_gula_Image) },
            { nameof(Anillo_de_Impulso), () => ActivarItem(ref Anillo_de_Impulso, Anillo_de_Impulso_Image) },
            { nameof(Lagrima), () => ActivarItem(ref Lagrima, Lagrima_Image) },
            { nameof(Yelmo), () => ActivarItem(ref Yelmo, Yelmo_Image) },
            { nameof(Escudo_Maestro), () => ActivarItem(ref Escudo_Maestro, Escudo_Maestro_Image) },
            { nameof(Manzana), () => ActivarItem(ref Manzana, Manzana_Image) },
            { nameof(Manzana_Dorada), () => ActivarItem(ref Manzana_Dorada, Manzana_Dorada_Image) }
        };

        // Filtrar los ítems que están en false
        var desactivados = items.Where(item =>
        {
            var fieldValue = GetType().GetField(item.Key)?.GetValue(this);
            return fieldValue is bool value && !value;
        }).ToList();

        // Si hay ítems desactivados, activa uno aleatorio
        if (desactivados.Any())
        {
            var random = new System.Random();
            var seleccion = desactivados[random.Next(desactivados.Count)];
            seleccion.Value.Invoke(); // Activa el ítem y su imagen
        }
    }

    /// <summary>
    /// Activa un ítem y su imagen asociada.
    /// </summary>
    private void ActivarItem(ref bool item, Image image)
    {
        item = true;
        if (image != null)
        {
            image.gameObject.SetActive(true); // Activa el GameObject de la imagen
        }
        else
        {
            Debug.LogWarning("Imagen asociada no asignada.");
        }
    }
    public int PlayerCardAttack(int dmg) 
    {
        if (Idolo_Menor) dmg +=4;
        if (Idolo_Mayor) dmg +=8;
        
        if (Tarro_de_la_gula)
        {
            gameObject.GetComponent<HealtManager>().HealthUp(Tarro_de_la_gulaIncrement);
            if (Tarro_de_la_gulaIncrement < 10) Tarro_de_la_gulaIncrement += 2;
        }
        return dmg;
    }


    public void CombatStart() 
    {
        if (Anillo_de_Impulso) gameObject.GetComponent<Buffs>().AddDamageStrength(2);
        if (Lagrima) gameObject.GetComponent<BattleSceneManager>().AddStartMana();
        if (Yelmo) gameObject.GetComponent<HealtManager>().ArmorUp(5);
        if (Escudo_Maestro) gameObject.GetComponent<HealtManager>().ArmorUp(15);
        if (Manzana) gameObject.GetComponent<HealtManager>().healthMaxAlter = (int)Mathf.Round(gameObject.GetComponent<HealtManager>().healthMaxBase * 1.10f);
        if (Manzana_Dorada) gameObject.GetComponent<HealtManager>().healthMaxAlter = (int)Mathf.Round(gameObject.GetComponent<HealtManager>().healthMaxBase * 1.25f);
    }
}
