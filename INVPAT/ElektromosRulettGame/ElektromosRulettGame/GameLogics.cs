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
        public Wheel wheel { get; }
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
            Console.WriteLine($"NYERTÉL! Ehhez pedig gratulálok neked kedves barátom. Az új egyenleged: {money}");
        }

        public void CalculateLose()
        {
            currentBetSize = 0;
            currentBet = "";
            Console.WriteLine($"Sajnálom, ezúttal VESZTETTÉL :( Az új egyenleged: {money}");
        }

        public void ConfirmBetAndStartGame()
        {
            if (currentBet != "" && currentBetSize > 0)
            {
                IField winningField = wheel.Spin();
                for (int i = 0; i < 37; i++)
                {
                    if (currentBet == i.ToString())
                    {
                        if (currentBet == winningField.number.ToString())
                        {
                            CalculateWin(36);
                        }
                        else
                        {
                            CalculateLose();
                        }
                    }
                }

                if(currentBet == "Zöld")
                {
                    if(currentBet == winningField.color)
                    {
                        CalculateWin(36);
                    }
                    else
                    {
                        CalculateLose();
                    }
                }

                if(currentBet == "Piros")
                {
                    if(currentBet == winningField.color)
                    {
                        CalculateWin(2);
                    }
                    else
                    {
                        CalculateLose();
                    }
                }

                if(currentBet == "Fekete")
                {
                    if(currentBet == winningField.color)
                    {
                        CalculateWin(2);
                    }
                    else
                    {
                        CalculateLose();
                    }
                }

                if(currentBet == "Tucat 1")
                {
                    if(winningField.number != 0 && winningField.number <= 12)
                    {
                        CalculateWin(3);
                    }
                    else
                    {
                        CalculateLose();
                    }
                }

                if (currentBet == "Tucat 2")
                {
                    if (winningField.number > 12 && winningField.number <= 24)
                    {
                        CalculateWin(3);
                    }
                    else
                    {
                        CalculateLose();
                    }
                }

                if (currentBet == "Tucat 3")
                {
                    if (winningField.number > 24)
                    {
                        CalculateWin(3);
                    }
                    else
                    {
                        CalculateLose();
                    }
                }
            }
        }

        public void TakeOutALoan()
        {
            money += 100;
            loanCounter++;
            if(loanCounter >= 5)
            {
                money = int.MinValue;
                Console.WriteLine("Csődbe mentél, a Bank elvitte a házadat, és a feleséged elvált tőled, és vitte a kocsit és a gyerekeket nálad hagyta.");
            }
        }
    }
}
