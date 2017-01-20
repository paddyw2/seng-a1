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
            Console.WriteLine("Creating pop chute");
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

        public bool removePop(Pop pop)
        {
            bool success = false;
            foreach(PopSlot slot in slots)
            {
                Console.WriteLine(slot.getName() + " : " + slot.getQuantity());
                if(pop.Name.Equals(slot.getName()) && slot.getQuantity() > 0)
                {
                    slot.decQuantity();
                    success = true;
                    break;
                }
            }
            return success;
        }

        public List<Pop> emptyPopSlots()
        {
            List<Pop> allPops = new List<Pop>();
            foreach(PopSlot slot in slots)
            {
                int counter = slot.getQuantity();
                for(int i = 0; i<counter; i++)
                {
                    allPops.Add(slot.getType());
                    slot.decQuantity();
                }
            }
            return allPops;
        }



    }
}