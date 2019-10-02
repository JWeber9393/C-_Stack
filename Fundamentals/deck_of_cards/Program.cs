using System;
using System.Collections.Generic;


namespace deck_of_cards
{
    //============CARD CLASS============//
    public class Card
    {
        //Class Fields
        public string cardName;
        public string cardSuit;
        public int cardValue;

        //Class Properties
        public Card(string name, string suit, int val)
        {
            cardName = name;
            cardSuit = suit;
            cardValue = val;
        }
    }

    //============END CARD CLASS============//

            //===================//
    
    //============DECK CLASS============//
    class Deck
    {
        public List<Card> deckCards;

        public Deck()
        {
            Reset();
        }

        public Deck Reset()
        {
            deckCards = new List<Card>();
            string[] cardSuits = {"Hearts","Diamonds","Spades","Clubs"};
            string[] cardNames = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            foreach(string suit in cardSuits)
            {
                //build out individual cards
                for(int i = 0; i < cardNames.Length; i++)
                {
                    Card aCard = new Card(cardNames[i], suit, i+1);
                    deckCards.Add(aCard);
                }
            }
            return this;
        }

        public Deck Shuffle()
        {
            Random rand= new Random();
            for (int i = 0; i < deckCards.Count; i++)
            {
                int randomIndx = rand.Next(deckCards.Count);
                Card temp = deckCards[i];
                deckCards[i] = deckCards[randomIndx];
                deckCards[randomIndx] = temp;
            }
            return this;
        }

        public Card Deal()
        {
            if(deckCards.Count > 0)
            {
                Card dealt = deckCards[0];
                deckCards.RemoveAt(0);
                return dealt;
            }
            else
            {
                Reset();
                return Deal();
            }
        }
    }

    //============END DECK CLASS============//

            //===================//

    //============PLAYER CLASS============//
    class Player
    {
        public string Name;
        public List<Card> Hand;
        public Player(string playerName)
        {
            string Name = playerName;
            Hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card drawnCard = deck.Deal();
            Hand.Add(drawnCard);
            return drawnCard;   
        }

        public Card Discard(int index)
        {
            if(index < 0 || index > Hand.Count)
            {
                Console.WriteLine("Card index does not exist!!");
                return null;
            }
            else
            {
                Card discarded = Hand[index];
                Hand.RemoveAt(index);
                return discarded;
            }
        }
    }

    //============END PLAYER CLASS============//

            //===================//

    //============MAIN FUNCTION===============//
    class Program
    {
        static void Main(string[] args)
        {
            Deck Bicycle = new Deck();
            Bicycle.Shuffle();
            Player Joey = new Player("Joey");
            Joey.Draw(Bicycle);
            Joey.Draw(Bicycle);
            Joey.Draw(Bicycle);
            Joey.Draw(Bicycle);
            Joey.Draw(Bicycle);
            Joey.Draw(Bicycle);
            Joey.Draw(Bicycle);
            Console.WriteLine(Joey.Hand.Count);
            foreach(var card in Joey.Hand)
            {
                Console.WriteLine($"{card.cardName} of {card.cardSuit}");
            }
        }
    }
}
