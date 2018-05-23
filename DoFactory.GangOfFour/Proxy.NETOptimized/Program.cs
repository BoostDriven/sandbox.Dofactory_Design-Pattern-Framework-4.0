using System;

namespace Proxy.NETOptimized
{
    class Program
    {
        static void Main()
        {
            // Create math proxy
            MathProxy proxy = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

            // Wait for user
            Console.ReadKey();
        }
    }

    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    class Math : MarshalByRefObject, IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
    }

    class MathProxy : IMath
    {
        private Math _math;

        public MathProxy()
        {
            var ad = AppDomain.CreateDomain("MathDomain", null, null);

            var o = ad.CreateInstance(
                "Proxy.NETOptimized",
                "Proxy.NETOptimized.Math");

            _math = (Math)o.Unwrap();
        }

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }

        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }
    }
}
