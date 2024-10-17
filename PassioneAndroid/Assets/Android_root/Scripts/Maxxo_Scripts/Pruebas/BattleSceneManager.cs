using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Maxxo
{
    public class BattleSceneManager : MonoBehaviour
    {
        [Header("Cards")]
        public List<ScriptableCard> deck;
        public List<ScriptableCard> drawPile = new List<ScriptableCard>();
        public List<ScriptableCard> cardsInHand = new List<ScriptableCard>();
        public List<ScriptableCard> discardPile = new List<ScriptableCard>();
        public CardUI selectedCard;
        public List<CardUI> cardsInHandGameObjects = new List<CardUI>();

        [Header("Stats")]
        public int drawAmount = 5;
        public int maxEnergy;
        public int energy;
        public Turn turn;
        public enum Turn { Player, Enemy };

        [Header("Enemies")]
        public GameObject[] possibleEnemies;
        public GameObject[] possibleElites;
        bool eliteFight;

        public void StartHallwayFight()
        {
            BeginBattle(/*possibleEnemies*/);
        }
        public void StartEliteFight()
        {
            eliteFight = true;
            BeginBattle(/*possibleElites*/);
        }
        public void BeginBattle(/*GameObject[] prefabsArray*/)
        {
            Debug.Log("BeginBattle activa");
            foreach (ScriptableCard card in cardsInHand)
            {
                DiscardCard(card);
            }
            foreach (CardUI cardUI in cardsInHandGameObjects)
            {
                cardUI.gameObject.SetActive(false);
                //cardsInHand.Remove(cardUI.card);
            }

            discardPile = new List<ScriptableCard>();
            drawPile = new List<ScriptableCard>();
            cardsInHand = new List<ScriptableCard>();

            discardPile.AddRange(GameManager.Instance.playerDeck);
            ShuffleCards();
            DrawCards(drawAmount);
            energy = maxEnergy;
            //energyText.text = energy.ToString();
        }

        public void ShuffleCards()
        {
            Debug.Log("ShuffleCards Activa");
            discardPile.Shuffle();
            drawPile = discardPile;
            discardPile = new List<ScriptableCard>();
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

        public void DisplayCardInHand(ScriptableCard card)
        {
            CardUI cardUI = cardsInHandGameObjects[cardsInHand.Count - 1];
            cardUI.LoadCard(card);
            cardUI.gameObject.SetActive(true);
        }

        public void PlayCard(CardUI cardUI)
        {
            //Debug.Log("played card");
            //GoblinNob is enraged
            if (cardUI.card.cardType != ScriptableCard.CardType.Attack)

                //cardActions.PerformAction(cardUI.card, cardTarget);

                energy -= cardUI.card.GetCardCostAmount();
            //energyText.text = energy.ToString();

            //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
            selectedCard = null;
            cardUI.gameObject.SetActive(false);
            cardsInHand.Remove(cardUI.card);
            DiscardCard(cardUI.card);
        }
        public void DiscardCard(ScriptableCard card)
        {
            discardPile.Add(card);
            //discardPileCountText.text = discardPile.Count.ToString();
        }

    }
} 
