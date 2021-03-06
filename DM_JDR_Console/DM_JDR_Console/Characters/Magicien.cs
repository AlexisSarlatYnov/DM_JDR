﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Magicien : Character, ICharacter
    {
        Object _lock = new Object();
        Object _lock2 = new Object();
        public Magicien(string name)
        {
            this.name = name;
            this.attack = 75;
            this.defense = 125;
            this.attackSpeed = 1.5f;
            this.damages = 100;
            this.maximumLife = 125;
            this.currentLife = 125;
            this.powerSpeed = 0.1f;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);

            this.Reset();
        }
        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            base.AttackGenerale(persosAAttaquer, charactersEaten);
        }

        public override void Passive()
        {
            base.Passive();
        }

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            lock (_lock)
            {
                if (this.GetCurrentLife() > 0)
                {
                    int damagesPower = this.GetDamages() * 5;
                    int attackPower = this.GetAttack() * 5;
                    Console.WriteLine("DamagesPower est égal à " + damagesPower.ToString());
                    if (characters.Count > 0)
                    {
                        int index = rand.Next(characters.Count);
                        while (index == characters.IndexOf(this) && characters.Count > 0 || characters[index].GetCurrentLife() <= 0 && characters.Count > 0)
                        {
                            index = rand.Next(characters.Count);
                        }
                        Character persoAAttaquer = characters[index];
                        Console.WriteLine("Le perso attaqué par l'attaque principale est " + persoAAttaquer.GetName() + " !");
                        persoAAttaquer.SetIsHited(false);
                        persoAAttaquer.SetDelay(0);
                        int jetAttaque = attackPower + RollDice();
                        Console.WriteLine("Jet d'attaque : " + jetAttaque.ToString());
                        int jetDefense = persoAAttaquer.GetDefense() + RollDice();
                        Console.WriteLine("Jet de défense : " + jetDefense.ToString());
                        if (jetAttaque - jetDefense > 0)
                        {
                            //touché
                            persoAAttaquer.SetIsHited(true);
                            if (persoAAttaquer.GetIsHidden() == true)
                            {
                                persoAAttaquer.SetIsHidden(false);
                                Console.WriteLine(persoAAttaquer.GetName() + " n'est plus camouflé !");
                            }
                            int damagesSubis = (jetAttaque - jetDefense) * damagesPower / 100;
                            persoAAttaquer.TakeDamages(damagesSubis);
                            if (persoAAttaquer.GetCurrentLife() <= 0)
                            {
                                if (persoAAttaquer is IllusionOf)
                                {
                                    Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                }
                                else
                                {
                                    Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                    nbMorts++;
                                    persoAAttaquer.Score(nbMorts);
                                }
                                OnAppelPowerNecro(EventArgs.Empty);
                                for (int j = 0; j < characters.Count; j++)
                                {
                                    if (characters[j] is Necromancien)
                                    {
                                        characters[j].Passive();
                                    }
                                }
                            }
                            if (persoAAttaquer is IllusionOf)
                            {
                                lock (_lock2)
                                {
                                    OnAppelPowerIllusioniste(EventArgs.Empty);
                                    persoAAttaquer.GetIllusionisteParent().SetNbIllusionOf(persoAAttaquer.GetIllusionisteParent().GetNbIllusionOf() - 1);
                                    persoAAttaquer.GetIllusionisteParent().Passive();
                                    charactersEaten.Add(persoAAttaquer);
                                    characters.Remove(persoAAttaquer);
                                    Console.WriteLine("Illusion " + persoAAttaquer.GetName() + " éliminée !");
                                }
                            }
                            if (persoAAttaquer.GetAffectedByAttackDelay() == true && persoAAttaquer.GetCurrentLife() > 0)
                            {
                                persoAAttaquer.SetDelay(damagesSubis);
                            }                            
                            bool attackContinue = true;
                            int currentDamagesPower = damagesPower;
                            bool tousMort = false;
                            
                            while (attackContinue == true && currentDamagesPower > 0 && tousMort == false)
                            {
                                currentDamagesPower = currentDamagesPower - (int)(damagesPower * 0.1f);
                                Console.WriteLine("CurrentDamagesPower est égal à " + currentDamagesPower.ToString());
                                if (currentDamagesPower <= 0 || tousMort == true)
                                {
                                    attackContinue = false;
                                }
                                if (attackContinue == true)
                                {
                                    int cptMorts = 0;
                                    for (int i = 0; i < characters.Count; i++)
                                    {
                                        if (characters[i].GetCurrentLife() <= 0)
                                        {
                                            cptMorts++;
                                        }
                                    }
                                    index = rand.Next(characters.Count);
                                    //while (index == characters.IndexOf(this) && characters.Count > 0 && tousMort == false || characters[index].GetCurrentLife() <= 0 && characters.Count > 0 && tousMort == false
                                    while (index == characters.IndexOf(this) && characters.Count > 1 && tousMort == false || characters[index].GetCurrentLife() <= 0 && characters.Count > 1 && tousMort == false)
                                    {
                                        Console.WriteLine("Nombre de morts est de : " + cptMorts.ToString() + " morts !");
                                        if (cptMorts == (characters.Count - 1))
                                        {
                                            tousMort = true;
                                            Console.WriteLine("Tous les persos sauf " + this.GetName() + " sont morts !");
                                        }
                                        if (tousMort == false)
                                        {
                                            index = rand.Next(characters.Count);
                                        }
                                    }
                                    if (tousMort == false)
                                    {
                                        persoAAttaquer = characters[index];
                                        Console.WriteLine("Le perso attaqué par l'attaque secondaire est " + persoAAttaquer.GetName() + " !");
                                        Console.WriteLine("La currentlife de " + persoAAttaquer.GetName() + " est de " + persoAAttaquer.GetCurrentLife() + " points de vie !");
                                        persoAAttaquer.SetIsHited(false);
                                        persoAAttaquer.SetDelay(0);
                                        jetAttaque = attackPower + RollDice();
                                        Console.WriteLine("Jet d'attaque : " + jetAttaque.ToString());
                                        jetDefense = persoAAttaquer.GetDefense() + RollDice();
                                        Console.WriteLine("Jet de défense : " + jetDefense.ToString());
                                        if (jetAttaque - jetDefense > 0)
                                        {
                                            //touché
                                            if (persoAAttaquer.GetIsHidden() == true)
                                            {
                                                persoAAttaquer.SetIsHidden(false);
                                                Console.WriteLine(persoAAttaquer.GetName() + " n'est plus camouflé !");
                                            }
                                            persoAAttaquer.SetIsHited(true);
                                            damagesSubis = (jetAttaque - jetDefense) * damagesPower / 100;
                                            persoAAttaquer.TakeDamages(damagesSubis);
                                            if (persoAAttaquer.GetCurrentLife() <= 0)
                                            {
                                                if (persoAAttaquer is IllusionOf)
                                                {
                                                    Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                                    nbMorts++;
                                                    persoAAttaquer.Score(nbMorts);
                                                }
                                                OnAppelPowerNecro(EventArgs.Empty);
                                                for (int i = 0; i < characters.Count; i++)
                                                {
                                                    if (characters[i] is Necromancien)
                                                    {
                                                        characters[i].Passive();
                                                    }
                                                }
                                            }
                                            if (persoAAttaquer is IllusionOf)
                                            {
                                                lock (_lock2)
                                                {
                                                    OnAppelPowerIllusioniste(EventArgs.Empty);
                                                    persoAAttaquer.GetIllusionisteParent().SetNbIllusionOf(persoAAttaquer.GetIllusionisteParent().GetNbIllusionOf() - 1);
                                                    persoAAttaquer.GetIllusionisteParent().Passive();
                                                    charactersEaten.Add(persoAAttaquer);
                                                    characters.Remove(persoAAttaquer);
                                                    Console.WriteLine("Illusion " + persoAAttaquer.GetName() + " éliminée !");
                                                }
                                            }
                                            if (persoAAttaquer.GetAffectedByAttackDelay() == true && persoAAttaquer.GetCurrentLife() > 0)
                                            {
                                                persoAAttaquer.SetDelay(damagesSubis);
                                            }                                            
                                        }
                                        else
                                        {
                                            attackContinue = false;
                                            Console.WriteLine("Le personnage " + persoAAttaquer.GetName() + " ciblé par l'attaque secondaire s'est défendu !");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il n'y a plus de persos à tuer pour le Magicien " + this.GetName() + " !");
                                    }
                                }
                            }
                        }
                        else
                        {
                            // pas touché
                            Console.WriteLine("Le personnage " + persoAAttaquer.GetName() + " ciblé par l'attaque principale s'est défendu !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Il n'y a plus de persos à attaquer !");
                    }
                }
            }
        }

        public override int RollDice()
        {
            return base.RollDice();
        }

        public override void TakeDamages(int damagesSubis)
        {
            base.TakeDamages(damagesSubis);
        }
    }
}
