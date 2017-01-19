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

    }
}