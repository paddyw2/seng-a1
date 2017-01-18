using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class VendingMachine
    {
        private int id;
        private int popButtons;
        private List<Coin> acceptedCoins;
        private List<VendingPop> acceptedPops;
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
            acceptedPops = new List<VendingPop>();
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

        public void configurePop(List<string> popNames, List<int> popCosts)
        {
            if (popNames.Capacity != popButtons)
                throw new Exception("Buttons and pop varieties differ");

            if (popNames.Capacity != popCosts.Capacity)
                throw new Exception("Number of pops different to number of prices");

            for(int i = 0; i<popNames.Capacity;i++)
            {
                string name = popNames.ElementAt(i);
                int price = popCosts.ElementAt(i);
                VendingPop newPop = new VendingPop(name);
                newPop.setCost(price);
                acceptedPops.Add(newPop);
            }


        }

        public int getId()
        {
            return id;
        }
    }
}


