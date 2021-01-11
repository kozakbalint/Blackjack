using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        private string name;
        private int balance;
        private List<Result> results = new List<Result>();

        public Player()
        {
            balance = 1000;
        }

        public string GetName => name;
        public int GetBalance => balance;
        public string SetName { set => name = value; }
        public int SetBalance { set => balance = value; }
        public Result SetResult { set => results.Add(value); }
        public void ClearResult() => results.Clear(); 
    }
}
