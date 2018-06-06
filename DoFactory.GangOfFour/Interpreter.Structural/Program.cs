using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.RealWorld
{
    class Program
    {
        static void Main()
        {
            Context context = new Context();
            ArrayList list = new ArrayList();

            list.Add(new TerminalExpression());
            list.Add(new NonSerializedAttribute());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            // wait for user
            Console.ReadKey();
        }
    }

    class Context {
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called. Nonterminal.Interpret()");
        }
    }
}
