using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Structural
{
    class Program
    {
        /// <summary>
        /// Creates a ConcreteCommand object and set its receiver
        /// </summary>
        static void Main()
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.Executecommand();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Declares an interface for executing an operation
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// Extends the Command interface, implementing the Execute method by invoking the
    /// corresponding operations on Receiver. It defines a link between the Receiver and the action.
    /// </summary>
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    /// Knows how to perform the operations
    /// </summary>
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// Asks the command to carry out the request
    /// </summary>
    class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void Executecommand()
        {
            _command.Execute();
        }
    }
}
