using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class CoinChute
    {
        private List<CoinSlot> slots;
        private int insertValue;
        private int bankedValue;
        private List<Coin> bankedCoins;
        private List<Coin> insertedCoins;
        
        public CoinChute(List<Coin> listOfCoins)
        {
            slots = new List<CoinSlot>();
            insertValue = 0;
            bankedValue = 0;
            bankedCoins = new List<Coin>();
            insertedCoins = new List<Coin>();
            foreach (Coin coin in listOfCoins)
            {
                CoinSlot newSlot = new CoinSlot(coin);
                slots.Add(newSlot);
            }
        }

        public void loadCoins(int index, List<Coin> coins)
        {
            int counter = 0;
            foreach (CoinSlot slot in slots)
            {
                if (counter == index)
                {
                    slot.loadCoins(coins);
                    break;
                }
                counter++;
            }
        }

        public void insertCoin(Coin coin)
        {
            Console.WriteLine("Inserting coin: " + coin.Value);
            insertValue = insertValue + coin.Value;
            insertedCoins.Add(coin);
        }

        public void bankInsertValue()
        {
            bankedValue = bankedValue + insertValue;
            foreach(Coin coin in insertedCoins)
            {
                bankedCoins.Add(coin);
            }
            resetInsertValue();
        }

        public List<Coin> releaseChange(int val)
        {
            List<Coin> coinChange = new List<Coin>();
            int upperBound = val + 1;
            int largestCoinVal = 0;

            // loop
            while (true)
            {
                CoinSlot largestSlot = null;
                foreach (CoinSlot slot in slots)
                {
                    Coin type = slot.getType();
                    if (type.Value >= largestCoinVal && type.Value < upperBound)
                    {
                        largestCoinVal = type.Value;
                        largestSlot = slot;
                    }
                }

                // now we have next largest coin
                // decrease until target met
                bool runLoop = true;
                bool changeFinished = false;
                while (runLoop)
                {
                    val = val - largestCoinVal;
                    if(val>=0)
                    {
                        coinChange.Add(largestSlot.getType());
                        Console.WriteLine("Dispensing change: " + (largestSlot.getType()).Value);
                        largestSlot.decQuantity();
                        if (val == 0)
                        {
                            runLoop = false;
                            changeFinished = true;
                        }
                    } else
                    {
                        val = val + largestCoinVal;
                        runLoop = false;
                    }
                }

                if (changeFinished)
                    break;

                upperBound = largestCoinVal;
                largestCoinVal = 0;
            }

            // run whole loop again until remainder = 0
            return coinChange;
        }

        public List<Coin> getBankedCoins()
        {
            return bankedCoins;
        }

        public List<Coin> emptyCoinSlots()
        {
            List<Coin> allCoins = new List<Coin>();
            // for each coin slot, add that coin to
            // the list a number of times that matches
            // the quantity
            // decrement the slot quantity to reflect
            // the emptying
            foreach(CoinSlot slot in slots)
            {
                int counter = slot.getQuantity();
                for(int i = 0; i<counter; i++)
                {
                    allCoins.Add(slot.getType());
                    slot.decQuantity();
                }
            }
            return allCoins;
        }

        public int getInsertValue()
        {
            return insertValue;
        }

        public void resetInsertValue()
        {
            insertValue = 0;
            insertedCoins.Clear();
        }
    }
}