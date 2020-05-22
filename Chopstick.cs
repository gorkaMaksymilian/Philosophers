using System;
using System.Collections.Generic;
using System.Text;

namespace Philosophers {
    class Chopstick {
        // Chopstick name
        public string name { get; set; }

        public enum ChopstickState { Taken, Available };
        // Chopstick current state (taken by philosopher or it is still on table)
        public ChopstickState state { get; set; }

        // Current chopstick owner (Philosopher using this particular chopstick)
        public string owner { get; set; }

        // Try to take chopstick into particular hand (Philosopher calls this function)
        public bool Take(string takenBy) {
            // Lock block the current object for other threads
            lock (this) {
                // If chopstick lies on the table
                if (this.state == ChopstickState.Available) {
                    // Change Chopstick status to taken
                    state = ChopstickState.Taken;
                    // Set Chopstick owner to Philosopher who grabs it
                    owner = takenBy;
                    Console.WriteLine("{0} jest uzywana przez {1}", name, owner);
                    return true;
                }
                // If chopsitck is already taken
                else {
                    state = ChopstickState.Taken;
                    return false;
                }
            }
        }

        // Put back current chopstick on table
        public void Put() {
            // Set chopstick state back to available
            state = ChopstickState.Available;
            Console.WriteLine("{0} odklada {1}", owner, name);
            // Reset chopstick owner
            owner = String.Empty;

        }
    }
}
