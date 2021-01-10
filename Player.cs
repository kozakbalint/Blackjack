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

        public Player(int balance)
        {
            this.balance = balance;
        }

        public string GetName => name;
        public int GetBalance => balance;
        public string SetName { set => name = value; }
        public string SetBalance { set => balance = Int32.Parse(value); }
    }
}
