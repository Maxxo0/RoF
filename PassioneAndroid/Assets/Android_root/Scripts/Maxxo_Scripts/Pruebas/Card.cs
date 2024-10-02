using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(CardUI))]
public class Card : MonoBehaviour
{


    [field: SerializeField] public ScriptableCard cardData { get; private set; }

    public void SetUp(ScriptableCard data)
    {
        cardData = data;
    }

    
}
