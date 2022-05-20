using System;
using System.Collections.Generic;

namespace hm42
{
    class HomeWork42
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Play(true);
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();
        private Deck _deck = new Deck();

        public void Play(bool isPlaying)
        {
            Console.WriteLine("Что бы взять карту введите 1");
            Console.WriteLine("Если хотите взять больше карт введите их кол-во");
            Console.WriteLine("Что бы вывести все ваши карты введите myCards");

            while (isPlaying)
            {
                string userInput = Console.ReadLine();

                if(int.TryParse(userInput, out int number))
                {
                    if(number <= _deck.ShowAllCards())
                    {
                        for (int i = 0; i < number; i++)
                        {
                            _cards.Add(_deck.GiveCard());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы пытаетесь взять слишком много карт");
                        Console.WriteLine("Карт в колоде - " + _deck.ShowAllCards());
                    }
                }
                else if(userInput == "myCards")
                {
                    ShowAllCards();
                }
            }
        }

        private void ShowAllCards()
        {
            for(int i = 0; i < _cards.Count; i++)
            {
                Console.WriteLine(_cards[i].Rank + " " + _cards[i].Suit);
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            string[] _suits = new string[] { "Пики", "Крести", "Черви", "Буби" };
            string[] _cardRanks = new string[] { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            int numberOfShuffles = 50;
            Random random = new Random();

            for (int i = 0; i < _cardRanks.Length; i++)
            {
                for(int j = 0; j < _suits.Length; j++)
                {
                    Card card = new Card(_suits[j], _cardRanks[i]);
                    _cards.Add(card);
                }
            }

            for (int i = 0; i < numberOfShuffles; i++)
            {
                int randomIndex = random.Next(0, _cards.Count);
                Card tempCard = _cards[randomIndex];
                _cards[randomIndex] = _cards[i];
                _cards[i] = tempCard;
            }
        }

        public Card GiveCard()
        {
            Card uppderCard = _cards[0];
            _cards.RemoveAt(0);
            return uppderCard;
        }

        public int ShowAllCards()
        {
            return _cards.Count;
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }

        public Card(string suit, string cardRank)
        {
            Suit = suit;
            Rank = cardRank;
        }
    }
}
