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
            Console.WriteLine("Damages du charac 1 : " + charac1.GetDamages().ToString());
            Console.WriteLine("AttackSpeed du charac 1 : " + charac1.GetAttackSpeed().ToString());
            Console.WriteLine("Vie perdue en une attaque du charac 1 : " + charac1.GetLostLifeInAHit().ToString());
            /*charac1.SetAttack(2);
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Attack du charac 2 : " + charac2.GetAttack().ToString());*/
            charac1.SetLostLifeInAHit(100);
            Console.WriteLine("Vie perdue en une attaque du charac 1 : " + charac1.GetLostLifeInAHit().ToString());
            charac1.SetCurrentLife(charac1.GetCurrentLife() - charac1.GetLostLifeInAHit());
            charac1.BerserkerPower();
            charac1.BerserkerPassive();
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Damages du charac 1 : " + charac1.GetDamages().ToString());
            Console.WriteLine("AttackSpeed du charac 1 : " + charac1.GetAttackSpeed().ToString());
            Console.WriteLine("Charac 1 est affecté par un délai ? " + charac1.GetAffectedByAttackDelay().ToString());
            charac1.SetCurrentLife(charac1.GetCurrentLife() - charac1.GetLostLifeInAHit());
            charac1.BerserkerPassive();
            Console.WriteLine("Charac 1 est affecté par un délai ? " + charac1.GetAffectedByAttackDelay().ToString());
            charac1.SetCurrentLife(charac1.GetCurrentLife() - charac1.GetLostLifeInAHit());
            charac1.BerserkerPassive();
            Console.WriteLine("Charac 1 est affecté par un délai ? " + charac1.GetAffectedByAttackDelay().ToString());
            Console.ReadLine();
        }
    }
}
