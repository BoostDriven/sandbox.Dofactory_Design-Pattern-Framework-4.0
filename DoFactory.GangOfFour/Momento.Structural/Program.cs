using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Structural
{
    class Program
    {
        static void Main()
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Catetaker c = new Catetaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            // Wait for user
            Console.ReadKey();
        }
    }

    class Originator
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    class Memento
    {
        private string _state;

        public Memento (string state)
        {
            this._state = state;
        }

        public string State
        {
            get { return _state; }
        }
    }

    class Catetaker
    {
        private Memento _memento;

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
