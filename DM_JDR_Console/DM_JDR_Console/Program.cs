using DM_JDR_Console.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            
        }

        public static void Test()
        {
            Berserker charac1 = new Berserker();
            Berserker charac2 = new Berserker();
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Attack du charac 2 : " + charac2.GetAttack().ToString());
            Console.WriteLine("Vie perdue en une attaque du charac 1 : " + charac1.GetLostLifeInAHit().ToString());
            charac1.SetAttack(2);
            charac1.SetLostLifeInAHit(100);
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Attack du charac 2 : " + charac2.GetAttack().ToString());
            Console.WriteLine("Vie perdue en une attaque du charac 1 : " + charac1.GetLostLifeInAHit().ToString());
            Console.ReadLine();
        }
    }
}
