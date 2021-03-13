﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Pretre : Character, ICharacter
    {
        public Pretre(string name)
        {
            this.name = name;
            this.attack = 100;
            this.defense = 125;
            this.attackSpeed = 1.5f;
            this.damages = 90;
            this.maximumLife = 150;
            this.currentLife = 150;
            this.powerSpeed = 1.0f;
            this.hitRadiantDamages = true;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }

        public override void Attack(Character persoAAttaquer)
        {
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
            int jetAttaque = this.GetAttack() + RollDice();
            Console.WriteLine("Jet d'attaque : " + jetAttaque.ToString());
            int jetDefense = persoAAttaquer.GetDefense() + RollDice();
            Console.WriteLine("Jet de défense : " + jetDefense.ToString());
            if (jetAttaque - jetDefense > 0)
            {
                //touché
                persoAAttaquer.SetIsHited(true);
                int damagesSubis = (jetAttaque - jetDefense) * this.GetDamages() / 100;
                if (persoAAttaquer.GetIsUndead() == true)
                {
                    damagesSubis = damagesSubis * 2;
                }
                persoAAttaquer.SetCurrentLife(persoAAttaquer.GetCurrentLife() - damagesSubis);
                if (persoAAttaquer.GetAffectedByAttackDelay() == true)
                {
                    if (persoAAttaquer.GetCurrentLife() > 0)
                    {
                        persoAAttaquer.SetDelay(damagesSubis);
                    }
                }
            }
            else
            {
                //pas touché

            }
        }

        public override void AttackGenerale(List<Character> persosAAttaquer)
        {
            List<Character> UndeadList = UndeadPriority(persosAAttaquer);
            int index = rand.Next(persosAAttaquer.Count);
            while (index == persosAAttaquer.IndexOf(this))
            {
                index = rand.Next(persosAAttaquer.Count);
            }
            Character persoAAttaquer = persosAAttaquer[index];
            Console.WriteLine("Le perso initialement attaqué est " + persoAAttaquer.GetName() + " !");
            if (UndeadList.Count != 0)
            {
                Console.WriteLine("Il y a " + UndeadList.Count + " morts-vivants dans la liste de characters !");
                index = rand.Next(UndeadList.Count);
                persoAAttaquer = UndeadList[index];
                Console.WriteLine("Le mort-vivant attaqué par " + this.GetName() + " est " + persoAAttaquer.GetName() + " !");
            }
            else
            {
                Console.WriteLine("Il y a " + UndeadList.Count + " morts-vivants dans la liste de characters !");
            }
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
            int jetAttaque = this.GetAttack() + RollDice();
            Console.WriteLine("Jet d'attaque : " + jetAttaque.ToString());
            int jetDefense = persoAAttaquer.GetDefense() + RollDice();
            Console.WriteLine("Jet de défense : " + jetDefense.ToString());
            if (jetAttaque - jetDefense > 0)
            {
                //touché
                persoAAttaquer.SetIsHited(true);
                int damagesSubis = (jetAttaque - jetDefense) * this.GetDamages() / 100;
                persoAAttaquer.TakeDamages(damagesSubis);
                if (persoAAttaquer.GetAffectedByAttackDelay() == true)
                {
                    if (persoAAttaquer.GetCurrentLife() > 0)
                    {
                        persoAAttaquer.SetDelay(damagesSubis);
                    }
                }
            }
            else
            {
                //pas touché

            }
        }

        public override void AttackTest(Character persoAAttaquer, int jetAttaque, int jetDefense)
        {
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
            if (jetAttaque - jetDefense > 0)
            {
                //touché
                persoAAttaquer.SetIsHited(true);
                int damagesSubis = (jetAttaque - jetDefense) * this.GetDamages() / 100;
                if (persoAAttaquer.GetIsUndead() == true)
                {
                    damagesSubis = damagesSubis * 2;
                }
                //persoAAttaquer.SetCurrentLife(persoAAttaquer.GetCurrentLife() - damagesSubis);
                persoAAttaquer.TakeDamages(damagesSubis);
                if (persoAAttaquer.GetAffectedByAttackDelay() == true)
                {
                    if (persoAAttaquer.GetCurrentLife() > 0)
                    {
                        persoAAttaquer.SetDelay(damagesSubis);
                    }
                }
            }
            else
            {
                //pas touché

            }
        }

        public override void Passive()
        {
            base.Passive();
        }

        public override void Power(List<Character> characters)
        {
            this.SetCurrentLife(this.GetCurrentLife() + (int)(this.GetMaximumLife() * 0.1f));
            if (this.GetCurrentLife() > this.GetMaximumLife())
            {
                this.SetCurrentLife(this.GetMaximumLife());
            }
        }

        public List<Character> UndeadPriority(List<Character> characters)
        {
            List<Character> UndeadList = new List<Character>();
            for (int i = 0; i < characters.Count; i++)
            {
                if(characters[i].GetIsUndead() == true)
                {
                    UndeadList.Add(characters[i]);
                }
            }
            return UndeadList;
        }
    }
}
