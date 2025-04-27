using System;
using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;

        public State()
        {
            Transitions = new Dictionary<char, State>();
        }
    }

    // DFA for exactly one '0' and at least one '1'
    public class FA1
    {
        private State q0 = new State { Name = "q0", IsAcceptState = false };
        private State q1 = new State { Name = "q1", IsAcceptState = false };
        private State q2 = new State { Name = "q2", IsAcceptState = true };
        private State q3 = new State { Name = "q3", IsAcceptState = false };
        private State q4 = new State { Name = "q4", IsAcceptState = false };

        private State InitialState;

        public FA1()
        {
            InitialState = q0;
            // q0: no 0s, no 1s
            q0.Transitions['0'] = q1;  // saw first 0
            q0.Transitions['1'] = q3;  // saw 1
            // q1: one 0, no 1s
            q1.Transitions['0'] = q4;  // saw second 0 (reject)
            q1.Transitions['1'] = q2;  // saw 1 (accept)
            // q2: one 0, at least one 1
            q2.Transitions['0'] = q4;  // saw second 0 (reject)
            q2.Transitions['1'] = q2;  // saw more 1s (accept)
            // q3: no 0s, at least one 1
            q3.Transitions['0'] = q2;  // saw first 0 (accept)
            q3.Transitions['1'] = q3;  // saw more 1s
            // q4: reject state (more than one 0)
            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    // DFA for odd number of 0s and odd number of 1s
    public class FA2
    {
        private State q00 = new State { Name = "q00", IsAcceptState = false }; // even 0s, even 1s
        private State q01 = new State { Name = "q01", IsAcceptState = false }; // even 0s, odd 1s
        private State q10 = new State { Name = "q10", IsAcceptState = false }; // odd 0s, even 1s
        private State q11 = new State { Name = "q11", IsAcceptState = true };  // odd 0s, odd 1s

        private State InitialState;

        public FA2()
        {
            InitialState = q00;
            // q00: even 0s, even 1s
            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;
            // q01: even 0s, odd 1s
            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;
            // q10: odd 0s, even 1s
            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;
            // q11: odd 0s, odd 1s
            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    // DFA for strings containing '11'
    public class FA3
    {
        private State q0 = new State { Name = "q0", IsAcceptState = false };
        private State q1 = new State { Name = "q1", IsAcceptState = false };
        private State q2 = new State { Name = "q2", IsAcceptState = true };

        private State InitialState;

        public FA3()
        {
            InitialState = q0;
            
            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;
            
            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;
            
            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            FA1 fa1 = new FA1();
            FA2 fa2 = new FA2();
            FA3 fa3 = new FA3();

            string test = "101";
            Console.WriteLine($"FA1 result for {test}: {fa1.Run(test)}");
            Console.WriteLine($"FA2 result for {test}: {fa2.Run(test)}");
            Console.WriteLine($"FA3 result for {test}: {fa3.Run(test)}");
        }
    }
}
