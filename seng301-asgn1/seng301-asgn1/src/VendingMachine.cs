using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class VendingMachine
    {
        private Specifications specs;
        private CoinChute coinChute;
        private PopChute popChute;
        private Dispenser dispenser;
        public VendingMachine()
        {
            Console.WriteLine("No parameters provided!");
        }

        public VendingMachine(int machineId, List<int> listOfCoins, int buttonCount)
        {
            specs = new Specifications();
            specs.initSpecs(listOfCoins, machineId, buttonCount);
            coinChute = new CoinChute(specs.getAcceptedCoins());
            popChute = new PopChute();
            dispenser = new Dispenser();
        }

        public void configurePop(List<string> popNames, List<int> popCosts)
        {
            specs.configurePop(popNames, popCosts);
        }

        public void loadCoins(int coinKindIndex, List<Coin> coins)
        {
            coinChute.loadCoins(coinKindIndex, coins);

        }

        public void loadPops(int popKindIndex, List<Pop> pops)
        {
            popChute.loadPops(popKindIndex, pops);
        }

        public void insertCoin(Coin coin)
        {
            // first check coin type
            bool validCoin = specs.checkCoinType(coin);

            // if valid, then insert into chute
            if (validCoin)
                coinChute.insertCoin(coin);
            else
                dispenser.dispenseItems(null, new List<Coin> { coin });
        }

        public void pressButton(int buttonIndex)
        {
            // get pop by button index
            VendingPop pop = specs.getPopByIndex(buttonIndex);
            Console.WriteLine("Pop: " + pop.Name);

            // get pop price
            int price = pop.getCost();

            // get inserted amount
            int val = coinChute.getInsertValue();

            if(val < price)
            {
                // do nothing
                Console.WriteLine("Not enough money: swallowing change");
            } else
            {
                // calc change and dispense pop
                int change = val - price;
                Console.WriteLine("Price: " + price + " Change: " + change);
                List<Coin> changeCoins = coinChute.releaseChange(change);
                // decrement pop from chute
                bool success = popChute.removePop(pop);
                if (success) {
                    dispenser.dispenseItems(pop, changeCoins);
                }
                else
                {
                    // if either no matching pop found, or
                    // not enough pops then
                    // only dispense change

                    Console.WriteLine("Not enough pops: swallowing change");
                    pop = null;
                    dispenser.dispenseItems(pop, changeCoins);
                }
            }

            // bank inserted money and reset inserted value
            coinChute.bankInsertValue();
        }

        public List<Deliverable> extractItems()
        {
            return dispenser.extractItems();
        }

        public List<IList> teardown()
        {
            List<Coin> change = coinChute.emptyCoinSlots();
            List<Coin> bank = coinChute.getBankedCoins();
            List<Pop> pops = popChute.emptyPopSlots();

            List<IList> returnList = new List<IList> { change, bank, pops };

            return returnList;
        }

        public int getId()
        {
            return specs.getId();
        }
    }
}


