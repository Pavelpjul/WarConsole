namespace War
{
    internal class Tools
    {
        static public void DisplayCard(Player player, double card)
        {
            string[] suits = { "♣", "♦", "♥", "♠" };
            string[] cardsValue = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            
            string value = cardsValue[(int)card];
            int suitValue = (int)(card - Math.Round(card)) * 10;
            string suit = suits[suitValue];
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"{player.name} your card is |{suit}{value}|");
        }


        static public int IfInt(string test)
        {
            int one;
            bool ifInt = int.TryParse(test, out one);
            
            

            while (!ifInt)
            {
                Console.WriteLine("Please enter an integer");
                test = Console.ReadLine();
                ifInt = int.TryParse(test, out one);
                if (ifInt) break;

            }
            return one;
        }
        static public List<double> GenerateCards()
        {
            double[] cards = new double[416];
            int countCards = 0;
            double card = 0.00;
            for (int i = 0; i < 13; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        cards[countCards] = (double)i + (double)j / 10;
                        countCards++;
                    }

                }

            }
            List<double> cardsList = new List<double>();
            Random random = new Random();

            while (true)
            {
                int index = random.Next(cards.Length);
                if (cards[index] != 100.0)
                {
                    cardsList.Add(cards[index]);
                    cards[index] = 100.0;

                }
                if (cardsList.Count == 416) break;
            }
            return cardsList;

        }
    }
}
