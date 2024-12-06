using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektromosRulettGame
{
    internal interface IGameLogics
    {
        int money { get; set; }
        List<string> bets { get; set; }
        string currentBet { get; set; }
        int currentBetSize { get; set; }
        int loanCounter { get; set; }
        IWheel wheel { get; }
        bool PlaceBet(int amount, string betType);
        void CancelBet();
        void ConfirmBetAndStartGame();
        void CalculateWin(int multiplier);
        void CalculateLose();
        void TakeOutALoan();
    }
}
