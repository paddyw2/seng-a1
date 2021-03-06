﻿using System;
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
            dispensedItems = new List<Deliverable>();
        }

        public void dispenseItems(Pop pop, List<Coin> changeList)
        {
            if (pop != null)
            {
                dispensedItems.Add(pop);
                //Console.WriteLine("Delivery chute: " + pop.Name);
            }
            foreach(Coin coin in changeList)
            {
                //Console.WriteLine("Delivery chute: " + coin.Value);
                dispensedItems.Add(coin);
            }
        }

        public List<Deliverable> extractItems()
        {
            // copy dispensed items to a new list
            // to allow instance variable to be
            // reset before returning list
            List<Deliverable> dispenserItems = new List<Deliverable>();
            foreach(Deliverable item in dispensedItems)
            {
                dispenserItems.Add(item);
            }
            clearDispenser(); 
            return dispenserItems;
        }

        public void clearDispenser()
        {
            dispensedItems.Clear();
        }
    }
}