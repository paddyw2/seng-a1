using System;
using System.Collections;
using System.Collections.Generic;

using Frontend1;

namespace seng301_asgn1
{
    public class VendingMachine
    {
        private int id;
        private int popButtons;
        private List<Coin> acceptedCoins;
        public VendingMachine()
        {
            Console.Write("No parameters provided!\n");
        }

        public VendingMachine(int machineId, List<int> listOfCoins, int buttonCount)
        {
            Console.Write("Creating vending machine!\n");
            // assign button numbers and machine id
            id = machineId;
            popButtons = buttonCount;
            // check for coin kind errors
            acceptedCoins = new List<Coin>();
            foreach(int coinKind in listOfCoins)
            {
                // search acceptedCoins for duplicate
                foreach(Coin coin in acceptedCoins)
                {
                    if (coin.Value == coinKind)
                        throw new Exception("Duplicate coin");
                }
                // if no duplicates, then create new coin
                // and add to acceptedCoins list
                Coin newCoin = new Coin(coinKind);
                acceptedCoins.Add(newCoin);
            }
        }

        public int getId()
        {
            return id;
        }
    }
}


