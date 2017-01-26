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
        // coins that will be returned
        // on teardown
        private List<Coin> bankedCoins;
        // coins that are "in limbo" until
        // a valid pop choice/money combo
        // is made
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
            //Console.WriteLine("Inserting coin: " + coin.Value);
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

            // loop change process until either
            // no more valid coins, or change
            // value is met (where the loop will
            // be broken)
            while (true)
            {
                // loop through coin slots to find
                // next denomination
                // if found, sets the largestSlot
                // to a Coin, which has a value
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

                // check if largest coin is null
                // if so, then we have not found
                // a suitable change coin (we will
                // short change them)
                if (largestSlot == null)
                    return coinChange;

                // now we have next largest coin
                // decrease until target met, each
                // time removing a coin from the
                // coin slot, and adding it to the
                // coin change list
                bool runLoop = true;
                bool changeFinished = false;
                while (runLoop && largestSlot.getQuantity() > 0)
                {
                    // decrement change total by coin
                    // denomination
                    val = val - largestCoinVal;
                    if(val>=0)
                    {
                        // returned coin may be "incorrect" if the
                        // slot was loaded incorrectly - this is
                        // the desired functionality
                        Coin changeCoin = largestSlot.removeCoin();
                        coinChange.Add(changeCoin);
                        //Console.WriteLine("Dispensing coin: " + changeCoin.Value);

                        // if new change value is zero, all change
                        // has been added to the coin change list
                        // so terminate loop
                        if (val == 0)
                        {
                            runLoop = false;
                            changeFinished = true;
                        }
                    } else
                    {
                        // if change value is negative, reverse
                        // last decrement and move to lower
                        // denomination
                        val = val + largestCoinVal;
                        runLoop = false;
                    }
                }

                // if change finished flag is set, then
                // exit main loop
                if (changeFinished)
                    break;

                // else, reset variables and start next
                // loop to find lower denomination
                upperBound = largestCoinVal;
                largestCoinVal = 0;
            }

            return coinChange;
        }

        public List<Coin> emptyBankedCoins()
        {
            List<Coin> returnItems = new List<Coin>();
            foreach(Coin coin in bankedCoins)
            {
                returnItems.Add(coin);
            }
            bankedCoins.Clear();
            return returnItems;
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
                for(int i=0;i<counter;i++)
                {
                    allCoins.Add(slot.removeCoin());
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