namespace War
{
    internal class Player
    {
        internal string name;
        internal int cash = 100;

        public int SeeCash() { return cash; }

        public void SetCash(int cash)
        {
            this.cash = this.cash + cash;
        }

        public void GetCash(int cash)
        {
            this.cash = this.cash - cash;
        }

        public void SetName(string name) { this.name = name; }

        public string GetName() { return this.name; }

        public int Bet()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"You have {this.cash}, How much do you bet {this.name}: ");
            int cashBet = Tools.IfInt(Console.ReadLine());
            while (cashBet > this.cash || cashBet < 0)
            {
                if (cashBet > this.cash)
                {
                    Console.WriteLine($"You only have {this.cash}! How much do you bet { this.name}: ");
                    cashBet = Tools.IfInt(Console.ReadLine());
                } else if (cashBet < 0) 
                {
                    Console.WriteLine($"{ this.name} entered numbere below zero, please enter positive number : ");
                    cashBet = Tools.IfInt(Console.ReadLine());
                }
            }
            return cashBet;
        }
    }

        internal class Casino : Player
        {
            public Casino()
            {
                cash = 1000000;
                name = "$$$$ Casino $$$$";
            }
        }

    
}
