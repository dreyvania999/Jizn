using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        struct population
        {
            public double[] hisn;
            public double[] gertvi;
            public double alfa;//коэфицент рождаимости жертв
            public double betta;//коэфицент убийства жертв
            public double gamma;//коэфицент убыли хищников
            public double delta;//коэфицент воспроизводства хищников
        }

        public static void Main(string[] args)
        {
            int x0, g0, colvoIter;
            double alfa, betta, gamma, delta;
            Console.WriteLine("Введите количество хищников");
            x0 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество жертв");
            g0 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите количество итераций");
            colvoIter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите альфа");
            alfa = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите бета");
            betta = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите гамма");
            gamma = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите делта");
            delta = Convert.ToDouble(Console.ReadLine());
            population jer = Jizn(x0, g0, alfa, betta, gamma, delta, colvoIter);

            for (int i = 0; i < colvoIter; i++)
            {
                if (Convert.ToInt32(Math.Round(jer.gertvi[i], 1) * 10) % 10 >= 5)
                {
                    jer.gertvi[i] = (int)Math.Ceiling(jer.gertvi[i]);
                }
                else
                {
                    jer.gertvi[i] = (int)Math.Floor(jer.gertvi[i]);
                }

                if (Convert.ToInt32(Math.Round(jer.hisn[i], 1) * 10) % 10 >= 5)
                {
                    jer.hisn[i] = (int)Math.Ceiling(jer.hisn[i]);
                }
                else
                {
                    jer.hisn[i] = (int)Math.Floor(jer.hisn[i]);
                }
                Console.WriteLine((int)Math.Truncate(jer.gertvi[i])+"||"+ (int)Math.Truncate(jer.hisn[i]));
            }


        }

        static population Jizn(int x0, int g0, double alfa, double betta, double gamma, double delta, int colvoIter)
        {
            population obj = new population();
            obj.betta = betta;
            obj.gamma = gamma;
            obj.delta = delta;
            obj.alfa = alfa;
            obj.hisn = new double[colvoIter];
            obj.hisn[0] = x0;
            obj.gertvi = new double[colvoIter];
            obj.gertvi[0] = g0;
            for (int i = 1; i < colvoIter; i++)
            {
                obj.gertvi[i] = obj.gertvi[i - 1] + obj.alfa * obj.gertvi[i - 1] - obj.betta * obj.gertvi[i - 1] * obj.hisn[i - 1];
                obj.hisn[i] = obj.hisn[i - 1] - obj.gamma * obj.hisn[i - 1] + obj.delta * obj.gertvi[i - 1] * obj.hisn[i - 1];
            }
            
                return obj;
        }
    }
}