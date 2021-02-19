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
            Character charac1 = new Character();
            Character charac2 = new Character();
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Attack du charac 2 : " + charac2.GetAttack().ToString());
            charac1.SetAttack(2);
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Attack du charac 2 : " + charac2.GetAttack().ToString());
            Console.ReadLine();
        }
    }
}
