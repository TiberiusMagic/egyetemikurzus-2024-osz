using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektromosRulettGame
{
    internal class GameLogics : IGameLogics
    {
        public int money { get; set; }
        public List<string> bets { get; set; }
        public string currentBet { get; set; }
        public int currentBetSize { get; set; }
        public int loanCounter { get; set; }
        public IWheel wheel { get; }
        public GameLogics()
        {
            money = 100;
            wheel = new Wheel();
            bets = new List<string>();
            for (int i = 0; i < 37; i++)
            {
                bets.Add(i.ToString());
            }
            bets.Add("Piros");
            bets.Add("Fekete");
            bets.Add("Zöld");
            bets.Add("Tucat 1");
            bets.Add("Tucat 2");
            bets.Add("Tucat 3");
            bets.Add("Páros");
            bets.Add("Páratlan");
            bets.Add("Kicsi");
            bets.Add("Nagy");
            currentBet = "";
            currentBetSize = 0;
            loanCounter = 0;
        }

        public bool PlaceBet(int amount, string betType)
        {
            if ((amount > this.money) || (!bets.Contains(betType)) || amount <= 0)
            {
                return false;
            }
            else
            {
                money -= amount;
                currentBet = betType;
                currentBetSize = amount;
                return true;
            }
        }

        public void CancelBet()
        {
            if (currentBet != "")
            {
                money += currentBetSize;
                currentBet = "";
                currentBetSize = 0;
            }
        }

        public void CalculateWin(int multiplier)
        {
            money += multiplier * currentBetSize;
            currentBetSize = 0;
            currentBet = "";
            Console.WriteLine($"NYERTÉL! Ehhez pedig gratulálok neked kedves barátom. Az új egyenleged: {money} kredit");
        }

        public void CalculateLose()
        {
            currentBetSize = 0;
            currentBet = "";
            Console.WriteLine($"Sajnálom, ezúttal VESZTETTÉL :( Az új egyenleged: {money} kredit");
        }

        public void ConfirmBetAndStartGame()
        {
            if (currentBet != "" && currentBetSize > 0)
            {
                IField winningField = wheel.Spin();
                Console.WriteLine($"És kipörgött aaaaaaa... {winningField.color}, {winningField.number}");
                for (int i = 0; i < 37; i++)
                {
                    if (currentBet == i.ToString())
                    {
                        CalculateWinOrLoseForThirtySixers(currentBet == winningField.number.ToString());
                    }
                }

                if(currentBet == "Zöld")
                {
                    CalculateWinOrLoseForThirtySixers(currentBet == winningField.color);
                }

                if(currentBet == "Piros")
                {
                    CalculateWinOrLoseForDoublers(currentBet == winningField.color);
                }

                if(currentBet == "Fekete")
                {
                    CalculateWinOrLoseForDoublers(currentBet == winningField.color);
                }

                if(currentBet == "Kicsi")
                {
                    CalculateWinOrLoseForDoublers(winningField.number > 0 && winningField.number <= 18);
                }

                if (currentBet == "Nagy")
                {
                    CalculateWinOrLoseForDoublers(winningField.number > 18);
                }

                if (currentBet == "Páros")
                {
                    CalculateWinOrLoseForDoublers(winningField.number % 2 == 0);
                }

                if (currentBet == "Páratlan")
                {
                    CalculateWinOrLoseForDoublers(winningField.number % 2 == 1);
                }

                if (currentBet == "Tucat 1")
                {
                    CalculateWinOrLoseForTriplers(winningField.number != 0 && winningField.number <= 12);
                }

                if (currentBet == "Tucat 2")
                {
                    CalculateWinOrLoseForTriplers(winningField.number > 12 && winningField.number <= 24);
                }

                if (currentBet == "Tucat 3")
                {
                    CalculateWinOrLoseForTriplers(winningField.number > 24);
                }
            }
        }

        public void CalculateWinOrLoseForDoublers(bool condition)
        {
            if (condition)
            {
                CalculateWin(2);
            }
            else
            {
                CalculateLose();
            }
        }

        public void CalculateWinOrLoseForTriplers(bool condition)
        {
            if (condition)
            {
                CalculateWin(3);
            }
            else
            {
                CalculateLose();
            }
        }

        public void CalculateWinOrLoseForThirtySixers(bool condition)
        {
            if (condition)
            {
                CalculateWin(36);
            }
            else
            {
                CalculateLose();
            }
        }

        public void TakeOutALoan()
        {
            loanCounter++;
            if(loanCounter >= 5)
            {
                money = 0;
                Console.WriteLine("Sajnos elvesztetted az összes kreditedet, KIBUKTÁL AZ EGYETEMRŐL");
                return;
            }
            money += 100;
            Console.WriteLine($"Kölcsön felvéve! Az új egyenleged: {money} kredit");
        }
    }
}
