using System;
using System.Collections;
using System.Collections.Generic;

using Frontend1;

namespace seng301_asgn1 {
    /// <summary>
    /// Represents the concrete virtual vending machine factory that you will implement.
    /// This implements the IVendingMachineFactory interface, and so all the functions
    /// are already stubbed out for you.
    /// 
    /// Your task will be to replace the TODO statements with actual code.
    /// 
    /// Pay particular attention to extractFromDeliveryChute and unloadVendingMachine:
    /// 
    /// 1. These are different: extractFromDeliveryChute means that you take out the stuff
    /// that has already been dispensed by the machine (e.g. pops, money) -- sometimes
    /// nothing will be dispensed yet; unloadVendingMachine is when you (virtually) open
    /// the thing up, and extract all of the stuff -- the money we've made, the money that's
    /// left over, and the unsold pops.
    /// 
    /// 2. Their return signatures are very particular. You need to adhere to this return
    /// signature to enable good integration with the other piece of code (remember:
    /// this was written by your boss). Right now, they return "empty" things, which is
    /// something you will ultimately need to modify.
    /// 
    /// 3. Each of these return signatures returns typed collections. For a quick primer
    /// on typed collections: https://www.youtube.com/watch?v=WtpoaacjLtI -- if it does not
    /// make sense, you can look up "Generic Collection" tutorials for C#.
    /// </summary>
    public class VendingMachineFactory : IVendingMachineFactory {

        private int totalMachines;
        private List<VendingMachine> createdMachines;

        public VendingMachineFactory() {
            // creates a VendingMachineFactory
            // and sets the default variable values
            totalMachines = 0;
            createdMachines = new List<VendingMachine>();
        }

        public int createVendingMachine(List<int> coinKinds, int selectionButtonCount) {
            // creates a vending machine with coin types and number of buttons
            // as specifications
            // returns the machine id
            int newId = totalMachines;
            totalMachines++;
            VendingMachine newMachine = new VendingMachine(newId, coinKinds, selectionButtonCount);
            createdMachines.Add(newMachine);
            return newMachine.getId();
        }

        public void configureVendingMachine(int vmIndex, List<string> popNames, List<int> popCosts) {
            // configures the chosen machine with accepted pops by name, along
            // with their costs
            //Console.WriteLine("VF: Configuring...");
            VendingMachine machine = getMachineById(vmIndex);
            machine.configurePop(popNames, popCosts);
        }

        public void loadCoins(int vmIndex, int coinKindIndex, List<Coin> coins) {
            // loads the chosen machine with a float, i.e. change
            VendingMachine machine = getMachineById(vmIndex);
            machine.loadCoins(coinKindIndex, coins);
        }

        public void loadPops(int vmIndex, int popKindIndex, List<Pop> pops) {
            // loads the chosen machine with pops that can be sold
            VendingMachine machine = getMachineById(vmIndex);
            machine.loadPops(popKindIndex, pops);
        }

        public void insertCoin(int vmIndex, Coin coin) {
            // inserts a coin into the chosen machine
            VendingMachine machine = getMachineById(vmIndex);
            machine.insertCoin(coin);
        }

        public void pressButton(int vmIndex, int value) {
            // presses a button (indicating a pop) on the
            // chosen machine
            //Console.WriteLine("VF: Pressing button...");
            VendingMachine machine = getMachineById(vmIndex);
            machine.pressButton(value);
        }

        public List<Deliverable> extractFromDeliveryChute(int vmIndex) {
            // returns both the purchased pop and appropriate change
            // that is sitting inside the delivery chute
            //Console.WriteLine("VF: Extracting deliverable from chute");
            VendingMachine machine = getMachineById(vmIndex);
            List<Deliverable> items = machine.extractItems();
            return items;
        }

        public List<IList> unloadVendingMachine(int vmIndex) {
            // removes inserted money, remaining change, and unsold
            // pops from the chosen machine
            //Console.WriteLine("VF: Unloading/teardown");
            VendingMachine machine = getMachineById(vmIndex);
            List<IList> teardownItems = machine.teardown();
            return teardownItems;
        }

        // Helper Methods

        private VendingMachine getMachineById(int id)
        {
            // gets a previously created vending machine
            // by machine id
            VendingMachine machine = null;
            foreach (VendingMachine vend in createdMachines)
            {
                if (vend.getId() == id)
                {
                    machine = vend;
                    break;
                }
            }
            if (machine == null)
                throw new Exception("Invalid machine ID: " + id);

            return machine;
        }


    }
}