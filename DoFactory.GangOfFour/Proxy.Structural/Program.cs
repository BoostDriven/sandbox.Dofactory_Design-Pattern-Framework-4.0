using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Structural
{
    class Program
    {
        static void Main()
        {
            // create proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();

            Console.ReadKey();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }
    }
}
