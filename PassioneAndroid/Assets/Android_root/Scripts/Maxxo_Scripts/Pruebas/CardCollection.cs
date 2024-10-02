using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardCollection : ScriptableObject
{
    [field: SerializeField] public List<ScriptableCard> cardsInCollection { get; private set; }

    public void RemoveCardFromCollection(ScriptableCard card)
    {
        if (cardsInCollection.Contains(card))
        {
            cardsInCollection.Remove(card);
        }
        else
        {
            Debug.Log("No Card No Remove");
        }
    }

    public void AddCardToCollection(ScriptableCard card)
    {
        cardsInCollection.Add(card);
    }
}
