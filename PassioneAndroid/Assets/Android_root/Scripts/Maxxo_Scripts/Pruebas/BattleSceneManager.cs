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
        CardActions cardActions;

        [Header("Stats")]
        public int drawAmount = 5;
        public int cardN = 0;
        public int maxEnergy;
        public int energy;
        public int cardUIN;
        public Turn turn;
        public enum Turn { Player, Enemy1, Enemy2, Enemy3 };
        


        [Header("Enemies")]
        public GameObject[] possibleEnemies;
        public GameObject[] possibleElites;
        bool eliteFight;

        private void Awake()
        {
            cardActions = GetComponent<CardActions>();
        }

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
                Debug.Log(drawPile.Count);
                // drawPileCountText.text = drawPile.Count.ToString();
                cardN++;
                cardsDrawn++;
            }


        }

        public void DrawnEnemyCard(int amountToDraw)
        {
            
            
            
        }

        public void DisplayCardInHand(ScriptableCard card)
        {
            CardUI cardUI = cardsInHandGameObjects[cardsInHand.Count - 1];
            cardUI.LoadCard(card);
            cardUI.gameObject.SetActive(true);
        }

        public void DisplayCardEnemy(ScriptableCard card)
        {
            if (cardUIN < 10)
            {
                CardUI cardUI = cardsInHandGameObjects[cardUIN];
                cardUIN++;
                cardUI.LoadCard(card);
                cardUI.gameObject.SetActive(true);
                
                if (cardUIN == 10)
                {
                    cardUIN = 5;
                }
            }
           
        }

        public void PlayCard(CardUI cardUI)
        {
            //Debug.Log("played card");
            //GoblinNob is enraged
            if (cardUI.card.cardType == ScriptableCard.CardType.Attack)
            {
                cardActions.PerformAction(cardUI.card, GameManager.Instance.target);
                Debug.Log("PlayCard");
                //energy -= cardUI.card.GetCardCostAmount();
                //energyText.text = energy.ToString();

                //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
                selectedCard = null;
                cardUI.gameObject.SetActive(false);
                cardsInHand.Remove(cardUI.card);
                DiscardCard(cardUI.card);
            }


        }
        public void DiscardCard(ScriptableCard card)
        {
            discardPile.Add(card);
            //discardPileCountText.text = discardPile.Count.ToString();
        }

        



        public void ChangeTurn()
        {
            if (turn == Turn.Player)
            {
                turn = Turn.Enemy1;
                //endTurnButton.enabled = false;

                #region discard hand
                foreach (ScriptableCard card in cardsInHand)
                {
                    DiscardCard(card);
                }
                foreach (CardUI cardUI in cardsInHandGameObjects)
                {
                    if (cardUI.gameObject.activeSelf)
                    //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);

                    cardUI.gameObject.SetActive(false);
                    cardsInHand.Remove(cardUI.card);
                }
                #endregion

                /*foreach (Enemy e in enemies)
                {
                    if (e.thisEnemy == null)
                        e.thisEnemy = e.GetComponent<Fighter>();

                    //reset block
                    e.thisEnemy.currentBlock = 0;
                    e.thisEnemy.fighterHealthBar.DisplayBlock(0);
                }*/

                //player.EvaluateBuffsAtTurnEnd();
                //StartCoroutine(HandleEnemyTurn());
            }
            else
            {
                /*foreach (Enemy e in enemies)
                {
                    e.DisplayIntent();
                }*/
                turn = Turn.Player;

                //reset block
                //player.currentBlock = 0;
                //player.fighterHealthBar.DisplayBlock(0);
                energy = maxEnergy;
                //energyText.text = energy.ToString();

                //endTurnButton.enabled = true;
                DrawCards(drawAmount);

                //turnText.text = "Player's Turn";
                //banner.Play("bannerOut");
            }
        }

    }
} 
