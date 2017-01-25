using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frontend1;

namespace seng301_asgn1
{
    public class PopChute
    {
        List<PopSlot> slots;
        public PopChute()
        {
            slots = new List<PopSlot>();
        }

        public void createSlots(List<Pop> listOfPops)
        {
            // reset slots so that machine can
            // be reconfigured to accept different
            // pops
            slots.Clear();

            // create new slots for specified pops
            foreach(Pop pop in listOfPops)
            {
                PopSlot newSlot = new PopSlot(pop);
                slots.Add(newSlot);
            }
        }

        public void loadPops(int index, List<Pop> pops)
        {
            int counter = 0;
            foreach (PopSlot slot in slots)
            {
                if (counter == index)
                {
                    slot.loadPops(pops);
                    break;
                }
                counter++;
            }
        }

        public Pop removePop(Pop pop)
        {
            Pop chosenPop = null;
            foreach(PopSlot slot in slots)
            {
                if((pop.Name).Equals(slot.getName()))
                {
                    //Console.WriteLine("Requested: " + slot.getName() + " Our Stock: " + slot.getQuantity());
                    chosenPop = slot.removePop();
                    break;
                }
            }

            return chosenPop;
        }

        public List<Pop> emptyPopSlots()
        {
            List<Pop> allPops = new List<Pop>();
            foreach(PopSlot slot in slots)
            {
                int counter = slot.getQuantity();
                for(int i=0;i<counter;i++)
                {
                    allPops.Add(slot.removePop());
                }
            }
            return allPops;
        }
    }
}