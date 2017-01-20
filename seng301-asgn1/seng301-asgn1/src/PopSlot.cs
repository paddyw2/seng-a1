using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class PopSlot
    {
        private int quantity;
        private Pop popType;

        public PopSlot(Pop pop)
        {
            popType = new Pop(pop.Name);
            quantity = 0;
        }

        public void loadPops(List<Pop> pops)
        {
            // this presumes each coin is of
            // correct type
            foreach(Pop pop in pops)
            {
                incQuantity();
            }
        }

        public string getName()
        {
            return popType.Name;
        }

        public Pop getType()
        {
            return popType;
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
    }
}