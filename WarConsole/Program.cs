namespace War
{   
    class Program
    {
        static List<Player> listPlayers = new List<Player>();
        static List<double> decks = new List<double>();

        static void Main()
        {
            Casino casino = new Casino();

            Console.WriteLine("Welcome to war, how many players are you (Max 8)");
            int players = Tools.IfInt(Console.ReadLine());
            while (players > 8)
            {
                Console.WriteLine("Over 8! Max 8 players!");
                players = Tools.IfInt(Console.ReadLine());
                if (players < 9) break;
            }

            for (int i = 0; i < players; i++)
            {
                int playerNumber = i + 1;
                Player player = new Player();
                Console.Write($"Player {playerNumber} please enter your name: ");
                player.SetName($"Player {playerNumber} " + Console.ReadLine());
                listPlayers.Add(player);
            }
            decks = Tools.GenerateCards();

            while (true)
            {                
                for (int i = 0;i < listPlayers.Count; i++)
                {
                    if (listPlayers[i].SeeCash() == 0)
                    {
                        Console.Write($" I am sorry, {listPlayers[i].GetName()} dont have any money left, Good bye. Press any key to continue.");
                        Console.ReadLine();
                        listPlayers.RemoveAt(i);
                        i--;
                        if( listPlayers.Count == 0 ) System.Environment.Exit(1);
                    }
                }

                int[] bets = new int[listPlayers.Count];
                for (int i = 0; i < listPlayers.Count; i++)
                {
                    bets[i] = listPlayers[i].Bet();
                }
                double[] playingCards = new double[listPlayers.Count];
                for (int i = 0; i < listPlayers.Count; i++)
                {
                    playingCards[i] = decks[0];
                    Tools.DisplayCard(listPlayers[i], playingCards[i]);
                    decks.RemoveAt(0);
                }
                double casinoCard = decks[0];
                decks.RemoveAt(0);                
                Tools.DisplayCard(casino, casinoCard);

                int[] winLoss = new int[listPlayers.Count];  // 0 player lost, 1 player won, 2 null 
                bool equals = false;
                for (int i = 0; i < listPlayers.Count; i++)
                {
                    if (playingCards[i] < casinoCard) winLoss[i] = 0;              
                    else if (playingCards[i] > casinoCard) winLoss[i] = 1;                    
                    else
                    {
                        winLoss[i] = 2;
                        equals = true;
                    }
                }

                if (equals)
                {
                    casinoCard = decks[0];
                    Console.WriteLine("--------------------------------------------------------------");
                    Tools.DisplayCard(casino, casinoCard);
                    decks.RemoveAt(0);
                    for (int i = 0; i < listPlayers.Count; i++)
                    {
                        if (winLoss[i] == 2)
                        {
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine($"{listPlayers[i].GetName()} Do you want to double the bet, if no you lose (Y/N): ");
                            string choice = Console.ReadLine();
                            while (choice != "Y" || choice != "N")
                            {
                                Console.WriteLine("Invalide response, please enter Y or N");
                                choice = Console.ReadLine();
                                if (choice == "Y" || choice == "N") break;
                            }
                            int playerCash = listPlayers[i].SeeCash();
                            
                            if (choice == "N" && playerCash < (bets[i] * 2)) winLoss[i] = 0;                           
                            else
                            {
                                double newCard = decks[0];
                                Tools.DisplayCard(listPlayers[i], newCard);
                                decks.RemoveAt(0);
                                bets[i] = bets[i] * 2;

                                if (newCard > casinoCard) winLoss[i] = 1;                                
                                else winLoss[i] = 0;            
                            }
                        }
                    }
                    equals = false;
                }
                for (int i = 0; i < listPlayers.Count; i++)
                {
                    if (winLoss[i] == 0)
                    {
                        casino.SetCash(bets[i]);
                        listPlayers[i].GetCash(bets[i]);
                    }
                    else
                    {
                        listPlayers[i].SetCash(bets[i]);
                        casino.GetCash(bets[i]);
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}