using DM_JDR_Console.Characters;
using DM_JDR_Console.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DM_JDR_Console.Characters.Guerrier;

namespace DM_JDR_Console
{
    class Program
    {
        public static List<Character> characters = new List<Character>();
        static void Main(string[] args)
        {
            //TestBerserker();
            //TestZombie();
            //TestEvent();
            //TestGuerrier();
            //TestPaladin();
            //TestRobot();
            TestVampire();
        }

        public static void TestBerserker()
        {
            Berserker charac1 = new Berserker("A");
            //Berserker charac2 = new Berserker("B");
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
            charac1.Power(characters);
            charac1.Passive();
            Console.WriteLine("Attack du charac 1 : " + charac1.GetAttack().ToString());
            Console.WriteLine("Damages du charac 1 : " + charac1.GetDamages().ToString());
            Console.WriteLine("AttackSpeed du charac 1 : " + charac1.GetAttackSpeed().ToString());
            Console.WriteLine("Charac 1 est affecté par un délai ? " + charac1.GetAffectedByAttackDelay().ToString());
            charac1.SetCurrentLife(charac1.GetCurrentLife() - charac1.GetLostLifeInAHit());
            charac1.Passive();
            Console.WriteLine("Charac 1 est affecté par un délai ? " + charac1.GetAffectedByAttackDelay().ToString());
            charac1.SetCurrentLife(charac1.GetCurrentLife() - charac1.GetLostLifeInAHit());
            charac1.Passive();
            Console.WriteLine("Charac 1 est affecté par un délai ? " + charac1.GetAffectedByAttackDelay().ToString());
            Console.ReadLine();
        }

        public static void TestZombie()
        {
            Zombie zombie1 = new Zombie("Y");
            Zombie zombie2 = new Zombie("Z");
            Berserker berserker1 = new Berserker("A");
            Berserker berserker2 = new Berserker("B");
            Berserker berserker3 = new Berserker("C");
            characters.Add(zombie1);
            characters.Add(zombie2);
            characters.Add(berserker1);
            characters.Add(berserker2);
            characters.Add(berserker3);
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
            zombie1.Power(characters);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.Power(characters);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.Power(characters);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            Console.WriteLine("Défense de Zombie1 : " + zombie1.GetDefense());
            zombie1.SetDefense(100);
            Console.WriteLine("Défense de Zombie1 : " + zombie1.GetDefense());
            zombie1.Passive();
            Console.WriteLine("Défense de Zombie1 : " + zombie1.GetDefense());
            Console.ReadLine();
        }
                
        public static void TestGuerrier()
        {
            Guerrier guerrier1 = new Guerrier("A");
            Guerrier guerrier2 = new Guerrier("B");
            guerrier1.appelPower += g_appelPower;
            guerrier2.appelPower += g_appelPower;
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            guerrier1.Power(characters);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(1000);
            guerrier1.Power(characters);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(1000);
            guerrier1.Power(characters);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(1000);
            guerrier1.Power(characters);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(4000);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Console.ReadLine();
        }

        static async void g_appelPower(object sender, AppelPowerEventArgs e)
        {
            Console.WriteLine(e.bonusAttackSpeed);
            Console.WriteLine(e.guerrier);
            Task debBonus = Task.Run(() => DebBonus(e.guerrier, e.bonusAttackSpeed));
            await Task.Delay(3000);
            Task endBonus = Task.Run(() => EndBonus(e.guerrier, e.bonusAttackSpeed));
        }

        public static void DebBonus(Guerrier guerrier, float bonus)
        {
            guerrier.SetAttackSpeed(guerrier.GetAttackSpeed() + bonus);
        }
        public static void EndBonus(Guerrier guerrier, float bonus)
        {
            guerrier.SetAttackSpeed(guerrier.GetAttackSpeed() - bonus);
        }


        public static void TestPaladin()
        {
            Paladin paladin1 = new Paladin("A");
            Paladin paladin2 = new Paladin("B");
            Zombie zombie = new Zombie("Z");
            Console.WriteLine("Paladin 1 est touché ? " + paladin1.GetIsHited().ToString());
            Console.WriteLine("Paladin 2 est touché ? " + paladin2.GetIsHited().ToString());
            Console.WriteLine("Paladin 1 est affecté par un délai ? " + paladin1.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 2 est affecté par un délai ? " + paladin2.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 1 a un délai ? " + paladin1.GetDelay().ToString());
            Console.WriteLine("Paladin 2 a un délai ? " + paladin2.GetDelay().ToString());
            Console.WriteLine("Vie du paladin 1 : " + paladin1.GetCurrentLife().ToString());
            Console.WriteLine("Vie du paladin 2 : " + paladin2.GetCurrentLife().ToString());
            Console.WriteLine("L'attaque va réussir !");
            paladin1.AttackTest(paladin2, 100, 10);
            paladin2.Power(characters);
            Console.WriteLine("Paladin 1 est touché ? " + paladin1.GetIsHited().ToString());
            Console.WriteLine("Paladin 2 est touché ? " + paladin2.GetIsHited().ToString());
            Console.WriteLine("Paladin 1 est affecté par un délai ? " + paladin1.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 2 est affecté par un délai ? " + paladin2.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 1 a un délai ? " + paladin1.GetDelay().ToString());
            Console.WriteLine("Paladin 2 a un délai ? " + paladin2.GetDelay().ToString());
            Console.WriteLine("Vie du paladin 1 : " + paladin1.GetCurrentLife().ToString());
            Console.WriteLine("Vie du paladin 2 : " + paladin2.GetCurrentLife().ToString());
            Console.WriteLine("L'attaque va réussir !");
            paladin1.AttackTest(paladin2, 100, 10);
            Console.WriteLine("Paladin 1 est touché ? " + paladin1.GetIsHited().ToString());
            Console.WriteLine("Paladin 2 est touché ? " + paladin2.GetIsHited().ToString());
            Console.WriteLine("Paladin 1 est affecté par un délai ? " + paladin1.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 2 est affecté par un délai ? " + paladin2.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 1 a un délai ? " + paladin1.GetDelay().ToString());
            Console.WriteLine("Paladin 2 a un délai ? " + paladin2.GetDelay().ToString());
            Console.WriteLine("Vie du paladin 1 : " + paladin1.GetCurrentLife().ToString());
            Console.WriteLine("Vie du paladin 2 : " + paladin2.GetCurrentLife().ToString());
            Console.WriteLine("L'attaque va échouer !");
            paladin1.AttackTest(paladin2, 10, 100);
            paladin2.Power(characters);
            Console.WriteLine("Paladin 1 est touché ? " + paladin1.GetIsHited().ToString());
            Console.WriteLine("Paladin 2 est touché ? " + paladin2.GetIsHited().ToString());
            Console.WriteLine("Paladin 1 est affecté par un délai ? " + paladin1.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 2 est affecté par un délai ? " + paladin2.GetAffectedByAttackDelay().ToString());
            Console.WriteLine("Paladin 1 a un délai ? " + paladin1.GetDelay().ToString());
            Console.WriteLine("Paladin 2 a un délai ? " + paladin2.GetDelay().ToString());
            Console.WriteLine("Vie du paladin 1 : " + paladin1.GetCurrentLife().ToString());
            Console.WriteLine("Vie du paladin 2 : " + paladin2.GetCurrentLife().ToString());
            Console.WriteLine("L'attaque sur le zombie va réussir !");
            paladin1.AttackTest(zombie, 100, 10);
            Console.WriteLine("Vie du paladin 1 : " + paladin1.GetCurrentLife().ToString());
            Console.WriteLine("Vie du zombie : " + zombie.GetCurrentLife().ToString());
            Console.ReadLine();
        }

        public static void TestRobot()
        {
            Robot robot = new Robot("A");
            Console.WriteLine("Attack de " + robot.GetName() +" est de " + robot.GetAttack()+ " !");
            robot.Power(characters);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            robot.Power(characters);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            robot.Power(characters);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            robot.Power(characters);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            Console.ReadLine();
        }

        public static void TestVampire()
        {
            Vampire vampire = new Vampire("V");
            vampire.SetCurrentLife(50);
            Character charac = new Character("C");
            //Zombie zombie = new Zombie("Z");
            Character charac2 = new Character("C2");
            characters.Add(vampire);
            characters.Add(charac);
            //characters.Add(zombie);
            characters.Add(charac2);
            Console.WriteLine("CurrentLife de " + vampire.GetName() + " est de " + vampire.GetCurrentLife() + " !");
            //vampire.AttackTest(zombie, 100, 0);
            //vampire.AttackTest(charac, 100, 0);
            Console.WriteLine("CurrentLife de " + vampire.GetName() + " est de " + vampire.GetCurrentLife() + " !");
            //vampire.AttackTest(charac2, 100, 0);
            Console.WriteLine("CurrentLife de " + vampire.GetName() + " est de " + vampire.GetCurrentLife() + " !");
            vampire.Power(characters);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters);
            Console.ReadLine();
        }












        public static void TestEvent()
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
