using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{

    private Card _card;

    //  [Header("Prefabs Elements")]
    // [SerializeField] private Image _cardimage;
    public void Attack()
    {
        Destroy(gameObject);
    }
}
