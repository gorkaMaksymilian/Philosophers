using System;
using System.Threading;

namespace Philosophers {
    class Program {
        static void Main(string[] args) {
            // Creating five philosophers and setting them at the table 
            Philosopher Aristotle = new Philosopher("Arystoteles", 6, Table.OakChopstick, Table.PineChopstick);
            Philosopher Plato = new Philosopher("Platon", 5, Table.PineChopstick, Table.FirChopstick);
            Philosopher Socrates = new Philosopher("Sokrates", 5, Table.FirChopstick, Table.AshChopstick);
            Philosopher Pythagoras = new Philosopher("Pitagoras", 9, Table.AshChopstick, Table.BeechChopstick);
            Philosopher Epicurus = new Philosopher("Epikur", 3, Table.BeechChopstick, Table.OakChopstick);

            // Creating Threads (each philosopher starts thinking)
            new Thread(Aristotle.Think).Start();
            new Thread(Plato.Think).Start();
            new Thread(Socrates.Think).Start();
            new Thread(Pythagoras.Think).Start();
            new Thread(Epicurus.Think).Start();

        }
    }
}
