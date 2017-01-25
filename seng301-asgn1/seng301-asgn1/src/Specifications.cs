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
        }

        public void initSpecs(List<int> listOfCoins, int machineId, int buttonCount)
        {
            id = machineId;
            popButtons = buttonCount;
            acceptedPops = new List<VendingPop>();
            acceptedCoins = new List<Coin>();
            foreach (int coinKind in listOfCoins)
            {
                // check coin value is valid
                if (coinKind <= 0)
                    throw new Exception("Invalid coin value: " + coinKind);
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
            // to allow machine to be reconfigured
            // to accept different pops
            acceptedPops.Clear();

            if ((popNames.Count) != popButtons)
                throw new Exception("Buttons and pop varieties differ: " + popNames.Capacity + ", " + popButtons);

            if (popNames.Count != popCosts.Count)
                throw new Exception("Number of pops different to number of prices");

            for (int i = 0; i < (popNames.Count); i++)
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

        public VendingPop getPopByIndex(int index)
        {
            if (index >= popButtons)
                throw new Exception("Invalid button: " + index);

            int counter = 0;
            VendingPop returnPop = null;
            foreach(VendingPop pop in acceptedPops)
            {
                if (counter == index)
                {
                    returnPop = pop;
                    break;
                }
                counter++;
            }
            return returnPop;
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