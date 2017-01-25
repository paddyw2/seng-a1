using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class PopSlot
    {
        private List<Pop> popItems;
        private int quantity;
        private Pop popType;

        public PopSlot(Pop pop)
        {
            popType = new Pop(pop.Name);
            quantity = 0;
            popItems = new List<Pop>();
        }

        public void loadPops(List<Pop> pops)
        {
            // this presumes each pop is of
            // correct type
            foreach(Pop pop in pops)
            {
                Console.WriteLine("Loading pop: " + pop.Name);
                popItems.Add(pop);
                incQuantity();
            }
        }

        public List<Pop> getSlotContents()
        {
            return popItems;
        }

        public string getName()
        {
            return popType.Name;
        }

        public Pop removePop()
        {
            Pop item = null;
            if (quantity == 0)
                return item;
            item = popItems.First();
            popItems.Remove(popItems.First());
            decQuantity();
            return item;
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