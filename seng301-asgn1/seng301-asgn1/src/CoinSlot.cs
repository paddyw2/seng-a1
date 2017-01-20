using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class CoinSlot
    {
        int quantity;
        Coin coinType;

        public CoinSlot(Coin coin)
        {
            quantity = 0;
            coinType = new Coin(coin.Value);
        }

        public void loadCoins(List<Coin> coins)
        {
            // this presumes each coin is of
            // correct type
            int coinVal = coinType.Value;
            foreach(Coin coin in coins)
            {
                Console.WriteLine("Loading coin: " + coinType.Value);
                incQuantity();
            }
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