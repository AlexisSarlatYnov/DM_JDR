﻿using DM_JDR_Console.Characters;
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
        public static List<Character> charactersEaten = new List<Character>();
        static void Main(string[] args)
        {
            //TestBerserker();
            //TestZombie();
            //TestEvent();
            //TestGuerrier();
            //TestPaladin();
            //TestRobot();
            //TestVampire();
            //TestPretre();
            //TestMagicien();
            //TestIllusioniste();
            //TestAlchimiste();
            //TestAssassin();
            //TestNecromancien();
            //CombatV1();
            //CombatV2();
            CombatV3();
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
            charac1.Power(characters, charactersEaten);
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
            zombie1.Power(characters, charactersEaten);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.Power(characters, charactersEaten);
            Console.WriteLine("Zombie1 est mangé : " + zombie1.GetIsEaten());
            Console.WriteLine("Zombie2 est mangé : " + zombie2.GetIsEaten());
            Console.WriteLine("Berserker1 est mangé : " + berserker1.GetIsEaten());
            Console.WriteLine("Berserker2 est mangé : " + berserker2.GetIsEaten());
            Console.WriteLine("Berserker3 est mangé : " + berserker3.GetIsEaten());
            zombie1.Power(characters, charactersEaten);
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
            guerrier1.Power(characters, charactersEaten);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(1000);
            guerrier1.Power(characters, charactersEaten);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(1000);
            guerrier1.Power(characters, charactersEaten);
            Console.WriteLine("AttackSpeed de guerrier1 : " + guerrier1.GetAttackSpeed().ToString());
            Console.WriteLine("AttackSpeed de guerrier2 : " + guerrier2.GetAttackSpeed().ToString());
            Thread.Sleep(1000);
            guerrier1.Power(characters, charactersEaten);
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
            paladin2.Power(characters, charactersEaten);
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
            paladin2.Power(characters, charactersEaten);
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
            robot.Power(characters, charactersEaten);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            robot.Power(characters, charactersEaten);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            robot.Power(characters, charactersEaten);
            Console.WriteLine("Attack de " + robot.GetName() + " est de " + robot.GetAttack() + " !");
            robot.Power(characters, charactersEaten);
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
            vampire.Power(characters, charactersEaten);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters, charactersEaten);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters, charactersEaten);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters, charactersEaten);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters, charactersEaten);
            charac.AttackTest(vampire, 100, 0);
            vampire.Power(characters, charactersEaten);
            Console.ReadLine();
        }

        public static void TestPretre()
        {
            Pretre pretre = new Pretre("A");
            Vampire vampire = new Vampire("V");
            Zombie zombie = new Zombie("Z");
            Berserker berserker = new Berserker("B");
            characters.Add(pretre);
            characters.Add(vampire);
            characters.Add(zombie);
            characters.Add(berserker);
            pretre.SetCurrentLife(100);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.Power(characters, charactersEaten);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.Power(characters, charactersEaten);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.Power(characters, charactersEaten);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.Power(characters, charactersEaten);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.Power(characters, charactersEaten);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.Power(characters, charactersEaten);
            Console.WriteLine("Vie de " + pretre.GetName() + " est de " + pretre.GetCurrentLife() + " !");
            pretre.AttackGenerale(characters, charactersEaten);
            pretre.AttackGenerale(characters, charactersEaten);
            pretre.AttackGenerale(characters, charactersEaten);
            pretre.AttackGenerale(characters, charactersEaten);
            pretre.AttackGenerale(characters, charactersEaten);
            Console.ReadLine();
        }

        public static void TestMagicien()
        {
            Magicien magicien = new Magicien("A");
            Pretre pretre = new Pretre("P");
            Vampire vampire = new Vampire("V");
            Zombie zombie = new Zombie("Z");
            Berserker berserker = new Berserker("B");
            characters.Add(magicien);
            characters.Add(pretre);
            characters.Add(vampire);
            characters.Add(zombie);
            characters.Add(berserker);
            Console.WriteLine("Le Magicien " + magicien.GetName() + " utilise son pouvoir !");
            magicien.Power(characters, charactersEaten);
            /*Console.WriteLine("Le Magicien " + magicien.GetName() + " utilise son pouvoir !");
            magicien.Power(characters, charactersEaten);
            Console.WriteLine("Le Magicien " + magicien.GetName() + " utilise son pouvoir !");
            magicien.Power(characters, charactersEaten);*/
            Console.ReadLine();
        }

        public static void TestIllusioniste()
        {
            Illusioniste illusioniste = new Illusioniste("A");
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            illusioniste.appelPowerIllusioniste += i_IllusionOfDead;
            Character character = new Character("C");
            //characters.Add(illusioniste);
            //characters.Add(character);
            illusioniste.Power(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            illusioniste.Power(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            illusioniste.Power(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            illusioniste.Power(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.WriteLine(character.GetName() + " attaque !");
            character.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(illusioniste.GetNbIllusionOf() + " illusions de " + illusioniste.GetName());
            Console.WriteLine(illusioniste.GetName() + " a une attack de " + illusioniste.GetAttack() + " !");
            Console.ReadLine();
        }

        static void i_IllusionOfDead(object sender, EventArgs e)
        {
            Console.WriteLine("A IllusionOf died !");
        }


        public static void TestAlchimiste()
        {
            Alchimiste alchimiste = new Alchimiste("A");
            Character character1 = new Character("C1");
            Character character2 = new Character("C2");
            Character character3 = new Character("C3");
            Character character4 = new Character("C4");
            Character character5 = new Character("C5");
            Zombie zombie = new Zombie("Z");
            characters.Add(alchimiste);
            characters.Add(character1);
            characters.Add(character2);
            characters.Add(character3);
            characters.Add(character4);
            characters.Add(character5);
            characters.Add(zombie);
            alchimiste.SetCurrentLife(50);
            Console.WriteLine(alchimiste.GetName() + " utilise son pouvoir !");
            alchimiste.Power(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.ReadLine();
        }

        public static void TestAssassin()
        {
            Assassin assassin = new Assassin("A");
            //Character character1 = new Character("C1");
            Character character2 = new Character("C2");
            Alchimiste alchimiste = new Alchimiste("B");
            Zombie zombie = new Zombie("Z");
            characters.Add(assassin);
            //characters.Add(character1);
            characters.Add(character2);
            characters.Add(alchimiste);
            characters.Add(zombie);
            assassin.Power(characters, charactersEaten);
            Console.WriteLine(zombie.GetName() + " attaque !");
            zombie.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(zombie.GetName() + " attaque !");
            zombie.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(zombie.GetName() + " attaque !");
            zombie.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(zombie.GetName() + " attaque !");
            zombie.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(zombie.GetName() + " attaque !");
            zombie.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(zombie.GetName() + " attaque !");
            zombie.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(alchimiste.GetName() + " attaque !");
            alchimiste.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.WriteLine(assassin.GetName() + " attaque !");
            assassin.AttackGenerale(characters, charactersEaten);
            Console.ReadLine();
        }

        public static void TestNecromancien()
        {
            Necromancien necromancien = new Necromancien("A");
            Console.WriteLine(necromancien.GetName() + " a une attack de " + necromancien.GetAttack() + " !");
            necromancien.appelPowerNecro += n_NecroPassive;
            Character character1 = new Character("C1");
            Character character2 = new Character("C2");
            Character character3 = new Character("C3");
            Character character4 = new Character("C4");
            Character character5 = new Character("C5");
            characters.Add(necromancien);
            characters.Add(character1);
            characters.Add(character2);
            characters.Add(character3);
            characters.Add(character4);
            characters.Add(character5);
            Console.WriteLine(necromancien.GetName() + " utilise son pouvoir !");
            necromancien.Power(characters, charactersEaten);
            while (character2.GetCurrentLife() > 0)
            {
                Console.WriteLine(character1.GetName() + " va attaquer !");
                character1.AttackGenerale(characters, charactersEaten);
                Console.WriteLine("Attack de " + necromancien.GetName() + " est de " + necromancien.GetAttack() + " !");
            }
            Console.WriteLine(necromancien.GetName() + " va attaquer !");
            necromancien.AttackGenerale(characters, charactersEaten);
            Console.WriteLine("Attack de " + necromancien.GetName() + " est de " + necromancien.GetAttack() + " !");
            Console.WriteLine(necromancien.GetName() + " va attaquer !");
            necromancien.AttackGenerale(characters, charactersEaten);
            Console.WriteLine("Attack de " + necromancien.GetName() + " est de " + necromancien.GetAttack() + " !");
            Console.WriteLine(necromancien.GetName() + " va attaquer !");
            necromancien.AttackGenerale(characters, charactersEaten);
            Console.WriteLine("Attack de " + necromancien.GetName() + " est de " + necromancien.GetAttack() + " !");
            Console.WriteLine(necromancien.GetName() + " va attaquer !");
            necromancien.AttackGenerale(characters, charactersEaten);
            Console.WriteLine("Attack de " + necromancien.GetName() + " est de " + necromancien.GetAttack() + " !");
            Console.ReadLine();
        }
        static void n_NecroPassive(object sender, EventArgs e)
        {
            Console.WriteLine("All necromancians use their passive !");
        }

        public static void CombatV1()
        {
            Alchimiste alchimiste = new Alchimiste("alchimiste");
            Assassin assassin = new Assassin("assassin");
            Berserker berserker = new Berserker("berserker");
            Guerrier guerrier = new Guerrier("guerrier");
            Illusioniste illusioniste = new Illusioniste("illusioniste");
            Magicien magicien = new Magicien("magicien");
            Necromancien necromancien = new Necromancien("necromancien");
            Paladin paladin = new Paladin("paladin");
            Pretre pretre = new Pretre("Pretre");
            Robot robot = new Robot("robot");
            Vampire vampire = new Vampire("vampire");
            Zombie zombie = new Zombie("zombie");
            List<Character> characters = new List<Character> { alchimiste, assassin, berserker, guerrier, illusioniste, magicien, necromancien, paladin, pretre, robot, vampire, zombie };
            FightManager fightManager = new FightManager(characters, 0);
            fightManager.StartCombat();
            Console.ReadLine();
        }

        public static void CombatV2()
        {
            int nbFightManager = 5;            
            FightManager[] fightManagers = new FightManager[nbFightManager];
            for (int i = 0; i < fightManagers.Length; i++)
            {
                Alchimiste alchimiste = new Alchimiste("alchimiste");
                Assassin assassin = new Assassin("assassin");
                Berserker berserker = new Berserker("berserker");
                Guerrier guerrier = new Guerrier("guerrier");
                Illusioniste illusioniste = new Illusioniste("illusioniste");
                Magicien magicien = new Magicien("magicien");
                Necromancien necromancien = new Necromancien("necromancien");
                Paladin paladin = new Paladin("paladin");
                Pretre pretre = new Pretre("Pretre");
                Robot robot = new Robot("robot");
                Vampire vampire = new Vampire("vampire");
                Zombie zombie = new Zombie("zombie");
                List<Character> characters = new List<Character> { alchimiste, assassin, berserker, guerrier, illusioniste, magicien, necromancien, paladin, pretre, robot, vampire, zombie };
                fightManagers[i] = new FightManager(characters, 0);
                fightManagers[i].StartCombat();
                Thread.Sleep(2000);
            }
            Console.ReadLine();
        }

        public static void CombatV3()
        {
            int nbFightManager = 5;
            FightManager[] fightManagers = new FightManager[nbFightManager];
            for (int i = 0; i < fightManagers.Length; i++)
            {
                Alchimiste alchimiste = new Alchimiste("alchimiste");
                Assassin assassin = new Assassin("assassin");
                Berserker berserker = new Berserker("berserker");
                Guerrier guerrier = new Guerrier("guerrier");
                Illusioniste illusioniste = new Illusioniste("illusioniste");
                Magicien magicien = new Magicien("magicien");
                Necromancien necromancien = new Necromancien("necromancien");
                Paladin paladin = new Paladin("paladin");
                Pretre pretre = new Pretre("Pretre");
                Robot robot = new Robot("robot");
                Vampire vampire = new Vampire("vampire");
                Zombie zombie = new Zombie("zombie");
                List<Character> characters = new List<Character> { alchimiste, assassin, berserker, guerrier, illusioniste, magicien, necromancien, paladin, pretre, robot, vampire, zombie };
                fightManagers[i] = new FightManager(characters, 0);
                fightManagers[i].StartCombat();
                Thread.Sleep(2000);
            }            
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
