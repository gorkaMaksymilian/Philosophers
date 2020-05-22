using System;
using System.Collections.Generic;
using System.Text;

namespace Philosophers {
    class Table {
        // Create five different chopsticks and place them on table
        internal static Chopstick OakChopstick = new Chopstick() { name = "paleczka z debu", state = Chopstick.ChopstickState.Available };
        internal static Chopstick PineChopstick = new Chopstick() { name = "paleczka z sosny", state = Chopstick.ChopstickState.Available };
        internal static Chopstick FirChopstick = new Chopstick() { name = "paleczka z jodly", state = Chopstick.ChopstickState.Available };
        internal static Chopstick AshChopstick = new Chopstick() { name = "paleczka z jesionu", state = Chopstick.ChopstickState.Available };
        internal static Chopstick BeechChopstick = new Chopstick() { name = "paleczka z buku", state = Chopstick.ChopstickState.Available };
    }
}
