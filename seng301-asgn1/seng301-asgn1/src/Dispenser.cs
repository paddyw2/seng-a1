using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class Dispenser
    {
        private List<Deliverable> dispensedItems;
        public Dispenser()
        {
            Console.WriteLine("Creating dispenser...");
            dispensedItems = new List<Deliverable>();
        }

        public void dispenseItems(Pop pop, List<Coin> changeList)
        {
            if (pop != null)
            {
                dispensedItems.Add(pop);
                Console.WriteLine("Dispensing " + pop.Name);
            }
            foreach(Coin coin in changeList)
            {
                Console.WriteLine("Dispensing " + coin.Value);
                dispensedItems.Add(coin);
            }
        }

        public List<Deliverable> extractItems()
        {
            return dispensedItems;
        }

        public void clearDispenser()
        {
            dispensedItems.Clear();
        }
    }
}