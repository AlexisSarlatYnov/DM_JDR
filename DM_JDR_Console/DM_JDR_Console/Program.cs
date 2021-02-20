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
            TestBerserker();
            TestZombie();
            
        }

        public static void TestBerserker()
        {
            Berserker charac1 = new Berserker();
            //Berserker charac2 = new Berserker();
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

        public static void TestZombie()
        {
            List<Character> list = new List<Character>();
            Zombie zombie1 = new Zombie();
            Zombie zombie2 = new Zombie();
            Berserker berserker1 = new Berserker();
            Berserker berserker2 = new Berserker();
            Berserker berserker3 = new Berserker();
            list.Add(zombie1);
            list.Add(zombie2);
            list.Add(berserker1);
            list.Add(berserker2);
            list.Add(berserker3);
            zombie2.SetCurrentLife(0);
            berserker1.SetCurrentLife(0);
            berserker2.SetCurrentLife(0);
            berserker2.SetIsEaten(true);
            Console.WriteLine("Santé zombie1 : " + zombie1.GetCurrentLife());
            Console.WriteLine("Santé zombie2 : " + zombie2.GetCurrentLife());
            Console.WriteLine("Santé berserker1 : " + berserker1.GetCurrentLife());
            Console.WriteLine("Santé berserker2 : " + berserker2.GetCurrentLife());
            Console.WriteLine("Santé berserker3 : " + berserker3.GetCurrentLife());
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.ZombiePower(list);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.ZombiePower(list);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.ZombiePower(list);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            Console.WriteLine("Défense de Zombie1 : " + zombie1.GetDefense());
            zombie1.SetDefense(100);
            Console.WriteLine("Défense de Zombie1 : " + zombie1.GetDefense());
            zombie1.ZombiePassive();
            Console.WriteLine("Défense de Zombie1 : " + zombie1.GetDefense());
            Console.ReadLine();
        }
    }
}
