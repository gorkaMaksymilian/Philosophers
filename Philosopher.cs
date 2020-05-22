using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Philosophers {
    class Philosopher {
        // Philosopher name
        public string name { get; set; }
       
        public enum PhilosopherState { Eating, Thinking };
        // Philosopher current state (he is eating or thinking)
        public PhilosopherState state { get; set; }

        // Counter (how many times Philosopher was thinkin in a row)
        int thinkingCombo;


        // Maximum thinking combo before starving
        public int starvationTreshold;

        // Chopstick objects
        public Chopstick LeftChopstick;
        public Chopstick RightChopstick;

        // Constructor
        public Philosopher(string name, int starvationTreshold, Chopstick Left, Chopstick Right) {
            this.name = name;
            this.starvationTreshold = starvationTreshold;
            LeftChopstick = Left;
            RightChopstick = Right;
            state = PhilosopherState.Thinking;
        }

        // Try to grab chopstick in left hand [true if succeed/false if fails]
        private bool GrabInLeftHand() {
            return LeftChopstick.Take(name);
        }

        // Try to grab chopstick in right hand [true if succeed/false if fails]
        private bool GrabInRightHand() {
            return RightChopstick.Take(name);
        }

       // Try to grab chopstick in both hands and start eating [succees resets the thinkingCombo]
        public void Eat() {
            //  Try to grab chopstick in right hand
            if (GrabInRightHand()) {
                // After success try to grab chopstick in left hand
                if (GrabInLeftHand()) {
                    canEat();
                }
                // Philosopher got chopstick in his right hand but was unable to grab the left one
                else {
                    // Wait some time and try to grab chopstick with left hand again
                    Thread.Sleep(new Random().Next(200, 500));
                    if (GrabInLeftHand()) {
                        canEat();
                    }
                    // Philosopher was unalbe to grab second chopstick even after waiting so he puts back the right chopstick
                    else {
                        RightChopstick.Put();
                    }
                }
            }
            // Philosopher could not grab chopstick with right hand
            else {
                // Try to grab chopstick in left hand
                if (GrabInLeftHand()) {
                    Thread.Sleep(new Random().Next(200, 500));
                    // If he grabbed a chopstick with left hand he yet again tries to grab right chopstick (after delay)
                    if (GrabInRightHand()) {
                        canEat();
                    }
                    // Philosopher was unalbe to grab second chopstick even after waiting so he puts back the left chopstick
                    else {
                        LeftChopstick.Put();
                    }
                }
            }
            // Regardless the outcome (eating or not) Philosopher starts thinking again
            Think();

        }

        public void canEat() {
            // Philosopher is holding chopsticks in both hands so he can start eating
            this.state = PhilosopherState.Eating;
            Console.WriteLine("{0} je uzywajac w lewej rece {1} a w prawej {2}", name, LeftChopstick.name, RightChopstick.name);
            // Eating takes some time
            Thread.Sleep(new Random().Next(3000, 10000));
            // Reset thinking counter
            thinkingCombo = 0;

            // Place back the chopsticks
            RightChopstick.Put();
            LeftChopstick.Put();
        }

        public void Think() {
            // Start thinking (it takes some time)
            this.state = PhilosopherState.Thinking;
            Console.WriteLine("{0} mysli", name);
            Thread.Sleep(new Random().Next(6000, 20000));
            thinkingCombo++;

            if (thinkingCombo > starvationTreshold) {
                Console.WriteLine("{0} zaczyna glodowac :-(", name);
            }

            Eat();

        }


    }
}
