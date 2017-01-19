using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class Specifications
    {
        private List<Coin> acceptedCoins;
        private List<VendingPop> acceptedPops;
        int id;
        int popButtons;

        public Specifications()
        {
            Console.WriteLine("Creating specifications");
        }

        public void initSpecs(List<int> listOfCoins, int machineId, int buttonCount)
        {
            id = machineId;
            popButtons = buttonCount;
            acceptedPops = new List<VendingPop>();
            acceptedCoins = new List<Coin>();
            foreach (int coinKind in listOfCoins)
            {
                // search acceptedCoins for duplicate
                foreach (Coin coin in acceptedCoins)
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

            for (int i = 0; i < popNames.Capacity; i++)
            {
                string name = popNames.ElementAt(i);
                int price = popCosts.ElementAt(i);
                VendingPop newPop = new VendingPop(name);
                newPop.setCost(price);
                acceptedPops.Add(newPop);
            }
        }

        public bool checkCoinType(Coin coin)
        {
            bool coinIsValid = false;
            foreach(Coin validCoin in acceptedCoins)
            {
                if (validCoin.Value == coin.Value)
                {
                    coinIsValid= true;
                    break;
                }
            }
            return coinIsValid;
        }

        public List<Coin> getAcceptedCoins()
        {
            return acceptedCoins;
        }

        public int getId()
        {
            return id;
        }
    }
}