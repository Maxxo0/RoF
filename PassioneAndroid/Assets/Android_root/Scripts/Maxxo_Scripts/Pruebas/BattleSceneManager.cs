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
        [SerializeField] GameObject endTurnButton;
        


        

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
            endTurnButton.SetActive(true);
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

            // Cartas del Player
            if (cardUI.card.cardClass == ScriptableCard.CardClass.Player && energy >= cardUI.card.cardCost.baseAmount && !GameManager.Instance.pStun )
            {
               if (cardUI.card.cardType == ScriptableCard.CardType.Attack && GameManager.Instance.target.tag == "Enemy") 
                {
                    cardActions.PerformAction(cardUI.card, GameManager.Instance.target);
                    Debug.Log("PlayCard");
                    energy -= cardUI.card.GetCardCostAmount();
                    //energyText.text = energy.ToString();

                    //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
                    selectedCard = null;
                    cardUI.gameObject.SetActive(false);
                    cardsInHand.Remove(cardUI.card);
                    DiscardCard(cardUI.card);
                }

                if (cardUI.card.cardType == ScriptableCard.CardType.Shield && GameManager.Instance.target.tag == "Player")
                {
                    cardActions.PerformAction(cardUI.card, GameManager.Instance.target);
                    Debug.Log("PlayCard");
                    energy -= cardUI.card.GetCardCostAmount();
                    //energyText.text = energy.ToString();

                    //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
                    selectedCard = null;
                    cardUI.gameObject.SetActive(false);
                    cardsInHand.Remove(cardUI.card);
                    DiscardCard(cardUI.card);
                }
            }

            if (cardUI.card.cardClass == ScriptableCard.CardClass.Monster && !GameManager.Instance.pStun)
            {
                if (cardUI.card.cardType == ScriptableCard.CardType.Attack && GameManager.Instance.target.tag == "Enemy")
                {
                    cardActions.PerformAction(cardUI.card, GameManager.Instance.target);
                    Debug.Log("PlayCard");
                    energy -= cardUI.card.GetCardCostAmount();
                    //energyText.text = energy.ToString();

                    //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
                    selectedCard = null;
                    cardUI.gameObject.SetActive(false);
                    cardsInHand.Remove(cardUI.card);
                    //DiscardCard(cardUI.card);
                }

                if (cardUI.card.cardType == ScriptableCard.CardType.Shield && GameManager.Instance.target.tag == "Player")
                {
                    cardActions.PerformAction(cardUI.card, GameManager.Instance.target);
                    Debug.Log("PlayCard");
                    energy -= cardUI.card.GetCardCostAmount();
                    //energyText.text = energy.ToString();

                    //Instantiate(cardUI.discardEffect, cardUI.transform.position, Quaternion.identity, topParent);
                    selectedCard = null;
                    cardUI.gameObject.SetActive(false);
                    cardsInHand.Remove(cardUI.card);
                    //DiscardCard(cardUI.card);
                }
            }




        }
        public void DiscardCard(ScriptableCard card)
        {
            discardPile.Add(card);
            //discardPileCountText.text = discardPile.Count.ToString();
        }

        
        void TurnPlayer()
        {
            GameManager.Instance.turn = GameManager.Turn.Player;
            BeginBattle();
        }


        public void ChangeTurn()
        {
            if (GameManager.Instance.turn ==  GameManager.Turn.Player)
            {
                Debug.Log("ChangeTurn");
                if (GameManager.Instance.canE1 == true) {  GameManager.Instance.turn = GameManager.Turn.Enemy1; }
                else if (GameManager.Instance.canE2 == true) {  GameManager.Instance.turn = GameManager.Turn.Enemy2; }
                else if (GameManager.Instance.canE3 == true) { GameManager.Instance.turn = GameManager.Turn.Enemy3; }
                endTurnButton.SetActive(false);

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

            }
            else if (GameManager.Instance.turn == GameManager.Turn.Enemy1)
            {
                if (GameManager.Instance.canE2 == true) { GameManager.Instance.turn = GameManager.Turn.Enemy2; }
                else if (GameManager.Instance.canE3 == true) { GameManager.Instance.turn = GameManager.Turn.Enemy3; }
                else { TurnPlayer(); }
            }
            else if (GameManager.Instance.turn == GameManager.Turn.Enemy2)
            {
                if (GameManager.Instance.canE3 == true) { GameManager.Instance.turn = GameManager.Turn.Enemy3; }
                else { TurnPlayer(); }
            }
            else if (GameManager.Instance.turn == GameManager.Turn.Enemy3)
            {
                TurnPlayer();
            }
            /*else
            {
                foreach (Enemy e in enemies)
                {
                    e.DisplayIntent();
                }
                GameManager.Instance.turn = GameManager.Turn.Player;

                //reset block
                //player.currentBlock = 0;
                //player.fighterHealthBar.DisplayBlock(0);
                energy = maxEnergy;
                //energyText.text = energy.ToString();

                //endTurnButton.enabled = true;
                DrawCards(drawAmount);

                //turnText.text = "Player's Turn";
                //banner.Play("bannerOut");
            }*/
        }

    }

    
} 
