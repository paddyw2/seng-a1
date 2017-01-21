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
            foreach(Pop pop in listOfPops)
            {
                PopSlot newSlot = new PopSlot(pop);
                slots.Add(newSlot);
            }
        }

        public void loadPops(int index, List<Pop> pops)
        {
            // first create slots
            createSlots(pops);
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
                Console.WriteLine("Requested: " + slot.getName() + " Our Stock: " + slot.getQuantity());
                if(pop.Name.Equals(slot.getName()) && slot.getQuantity() > 0)
                {
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

                List<Pop> slotPops = slot.getSlotContents();
                foreach(Pop pop in slotPops)
                {
                    allPops.Add(pop);
                    slot.decQuantity();
                }
            }
            return allPops;
        }



    }
}