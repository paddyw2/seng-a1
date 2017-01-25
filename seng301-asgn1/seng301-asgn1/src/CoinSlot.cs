using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class CoinSlot
    {
        List<Coin> slotItems;
        int quantity;
        Coin coinType;

        public CoinSlot(Coin coin)
        {
            quantity = 0;
            coinType = new Coin(coin.Value);
            slotItems = new List<Coin>();
        }

        public void loadCoins(List<Coin> coins)
        {
            // this presumes each coin is of
            // correct type
            int coinVal = coinType.Value;
            foreach(Coin coin in coins)
            {
                //Console.WriteLine("Loading coin: " + coin.Value);
                slotItems.Add(coin);
                incQuantity();
            }
        }

        public Coin removeCoin()
        {
            Coin coin = null;
            if (quantity == 0)
                return null;
            coin = slotItems.First();
            slotItems.Remove(slotItems.First());
            decQuantity();
            return coin;
        }

        public List<Coin> getSlotContents()
        {
            return slotItems;
        }

        public void setQuantity(int val)
        {
            quantity = val;
        }

        public void incQuantity()
        {
            quantity++;
        }

        public void decQuantity()
        {
            quantity--;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public Coin getType()
        {
            return coinType;
        }
    }
}