using System;
using System.Collections.Generic;

namespace hm42
{
    class HomeWork42
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Playing(true);
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();
        private Deck _deck = new Deck();

        public void Playing(bool isPlaying)
        {
            _deck.DenoteCards();
            Console.WriteLine("Что бы взять карту введите 1");
            Console.WriteLine("Если хотите взять больше карт введите их кол-во");
            Console.WriteLine("Что бы вывести все ваши карты введите myCards");

            while (isPlaying)
            {
                string userInput = Console.ReadLine();

                if(int.TryParse(userInput, out int number))
                {
                    GetCard(number);
                }
                else if(userInput == "myCards")
                {
                    ShowAllCards();
                }
            }
        }

        void GetCard(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                _cards.Add(_deck.Cards[_cards.Count]);
            }
        }

        void ShowAllCards()
        {
            for(int i = 0; i < _cards.Count; i++)
            {
                Console.WriteLine(_cards[i].Name + " " + _cards[i].Suit);
            }
        }
    }

    class Deck
    {
        private string[] _suits = new string[] { "Пики", "Крести", "Черви", "Буби" };
        private string[] _cardNames = new string[] { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
        public List<Card> Cards { get; private set; } = new List<Card>();

        public void DenoteCards()
        {
            for(int i = 0; i < _cardNames.Length; i++)
            {
                for(int j = 0; j < _suits.Length; j++)
                {
                    Card card = new Card(_suits[j], _cardNames[i]);
                    Cards.Add(card);
                }
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Name { get; private set; }

        public Card(string suit, string cardName)
        {
            Suit = suit;
            Name = cardName;
        }
    }
}
