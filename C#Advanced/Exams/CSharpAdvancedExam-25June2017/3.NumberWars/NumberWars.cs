using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.NumberWars
{
    class NumberWars
    {
        private const int GAME_END = 1000000;
        static void Main(string[] args)
        {
            Queue<string> playerOne = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Queue<string> playerTwo = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int turns = 0;
            bool gameOver = false;
            while (!gameOver && turns < GAME_END && playerOne.Count != 0 && playerTwo.Count != 0)
            {
                turns++;
                string firstCard = playerOne.Dequeue();
                int firstCardNumber = ExtractNumber(firstCard);

                string secondCard = playerTwo.Dequeue();
                int secondCardNumber = ExtractNumber(secondCard);

                if (firstCardNumber > secondCardNumber)
                {
                    playerOne.Enqueue(firstCard);
                    playerOne.Enqueue(secondCard);
                }
                else if (firstCardNumber < secondCardNumber)
                {
                    playerTwo.Enqueue(secondCard);
                    playerTwo.Enqueue(firstCard);
                }
                else
                {
                    List<string> winnerHand = new List<string> { firstCard, secondCard };
                    while (!gameOver)
                    {
                        if (playerOne.Count < 3 || playerTwo.Count < 3)
                        {
                            gameOver = true;
                            break;
                        }
                        int playerOneSum = 0;
                        int playerTwoSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            playerOneSum += CalculateLetterSum(playerOne.Peek());
                            playerTwoSum += CalculateLetterSum(playerTwo.Peek());

                            winnerHand.Add(playerOne.Dequeue());
                            winnerHand.Add(playerTwo.Dequeue());
                        }

                        if (playerOneSum > playerTwoSum)
                        {
                            foreach (string card in winnerHand.OrderByDescending(x => ExtractNumber(x)).ThenByDescending(x => CalculateLetterSum(x)))
                            {
                                playerOne.Enqueue(card);
                            }
                            break;
                        }
                        else if (playerTwoSum > playerOneSum)
                        {
                            foreach (string card in winnerHand.OrderByDescending(x => ExtractNumber(x)).ThenByDescending(x => CalculateLetterSum(x)))
                            {
                                playerTwo.Enqueue(card);
                            }
                            break;
                        }

                    }
                }
            }
            if (playerOne.Count > playerTwo.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (playerTwo.Count > playerOne.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
        }


        private static int CalculateLetterSum(string card)
        {
            // return cards.TakeLast(3).Select(x => string.Join("", x.Where(y => Char.IsLetter(y))).Select(z => Char.ToLower(z) - 'a').Sum()).Sum();
            return char.ToLower(card[card.Length - 1]) - 'a';
        }

        private static int ExtractNumber(string card)
        {

            //return int.Parse(string.Join("", card.Where(x => Char.IsDigit(x))));
            return int.Parse(card.Substring(0, card.Length - 1));
        }
    }
}