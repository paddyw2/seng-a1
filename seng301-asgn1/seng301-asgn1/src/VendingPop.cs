using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{

    public class VendingPop : Pop
    {
        private int cost;

        public VendingPop(string name) : base(name)
        {
            cost = 0;
        }

        public void setCost(int popCost)
        {
            cost = popCost;
            if (cost <= 0)
                throw new Exception("Pop price must be greater than zero");
        }

        public int getCost()
        {
            return cost;
        }

    }
}