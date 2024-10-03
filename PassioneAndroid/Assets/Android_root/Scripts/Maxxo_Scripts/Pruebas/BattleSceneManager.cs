using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Maxxo.BattleSceneManager;

public class BattleSceneManager : MonoBehaviour
{
    [Header("Cards")]
    public List<Card> deck;
    public List<Card> drawPile = new List<Card>();
    public List<Card> cardsInHand = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public CardUI selectedCard;
    public List<CardUI> cardsInHandGameObjects = new List<CardUI>();

    [Header("Stats")]
    public int drawAmount = 5;
    public Turn turn;
    public enum Turn { Player, Enemy };



    public void BeginBattle(GameObject[] prefabsArray)
    {
        foreach (Card card in cardsInHand)
        {
            DiscardCard(card);
        }
        foreach (CardUI cardUI in cardsInHandGameObjects)
        {
            cardUI.gameObject.SetActive(false);
            //cardsInHand.Remove(cardUI.card);
        }

        discardPile.AddRange(GameManager.Instance.playerDeck);
        ShuffleCards();
        DrawCards(drawAmount);
    }

    public void ShuffleCards()
    {
        discardPile.Shuffle();
        drawPile = discardPile;
        discardPile = new List<Card>();
        //discardPileCountText.text = discardPile.Count.ToString();
    }

    public void DrawCards(int amountToDraw)
    {
        int cardsDrawn = 0;
        while (cardsDrawn < amountToDraw && cardsInHand.Count <= 10)
        {
            if (drawPile.Count < 1)
                ShuffleCards();

            cardsInHand.Add(drawPile[0]);
            DisplayCardInHand(drawPile[0]);
            drawPile.Remove(drawPile[0]);
           // drawPileCountText.text = drawPile.Count.ToString();
            cardsDrawn++;
        }
    }

    public void DisplayCardInHand(Card card)
    {
        CardUI cardUI = cardsInHandGameObjects[cardsInHand.Count - 1];
        cardUI.LoadCard(card);
        cardUI.gameObject.SetActive(true);
    }
    public void DiscardCard(Card card)
    {
        discardPile.Add(card);
        //discardPileCountText.text = discardPile.Count.ToString();
    }

}
