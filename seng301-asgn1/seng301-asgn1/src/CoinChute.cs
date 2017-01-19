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
        
        public CoinChute(List<Coin> listOfCoins)
        {
            Console.WriteLine("Creating coin chute");
            slots = new List<CoinSlot>();
            insertValue = 0;
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
            foreach(CoinSlot slot in slots)
            {
                Coin type = slot.getType();
                int val = type.Value;
                if (coin.Value == val)
                {
                    insertValue = insertValue + val;
                    slot.incQuantity();
                    break;
                }
            }
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

        public int getInsertValue()
        {
            return insertValue;
        }

        public void resetInsertValue()
        {
            insertValue = 0;
        }
    }
}