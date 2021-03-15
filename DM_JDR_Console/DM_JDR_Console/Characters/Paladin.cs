using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Paladin : Character, ICharacter
    {
        Object _lock = new Object();
        public Paladin(string name)
        {
            this.name = name;
            this.attack = 60;
            this.defense = 145;
            this.attackSpeed = 1.6f;
            this.damages = 40;
            this.maximumLife = 250;
            this.currentLife = 250;
            this.powerSpeed = 0.5f;
            this.hitRadiantDamages = true;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }

        /*public void PaladinPower()
        {
            this.SetAffectedByAttackDelay(true);
            if (this.GetIsHited() == true)
            {
                this.SetAffectedByAttackDelay(false);
                this.SetDelay(0);
            }
        }*/



        public override void Attack(Character persoAAttaquer)
        {
            //persoAAttaquer.SetAffectedByAttackDelay(true);
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
                if(persoAAttaquer.GetIsUndead() == true)
                {
                    damagesSubis = damagesSubis * 2;
                }
                //persoAAttaquer.SetCurrentLife(persoAAttaquer.GetCurrentLife() - damagesSubis);
                TakeDamages(damagesSubis);
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
            //persoAAttaquer.SetAffectedByAttackDelay(true);
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

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            this.SetAffectedByAttackDelay(true);
            if (this.GetIsHited() == true)
            {
                this.SetAffectedByAttackDelay(false);
                this.SetDelay(0);
            }
        }

        public override void Passive()
        {
            base.Passive();
        }

        public override int RollDice()
        {
            return base.RollDice();
        }

        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            if (persosAAttaquer.Count > 0)
            {
                int index = rand.Next(persosAAttaquer.Count);
                while (index == persosAAttaquer.IndexOf(this) && persosAAttaquer.Count > 0 && persosAAttaquer[index].GetIsHidden() == true)
                {
                    index = rand.Next(persosAAttaquer.Count);
                }
                Character persoAAttaquer = persosAAttaquer[index];
                Console.WriteLine("Le perso attaqué est " + persoAAttaquer.GetName() + " !");
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
                    persoAAttaquer.TakeDamages(damagesSubis);
                    if (persoAAttaquer is IllusionOf)
                    {
                        lock (_lock)
                        {
                            OnAppelPowerIllusioniste(EventArgs.Empty);
                            persoAAttaquer.GetIllusionisteParent().SetNbIllusionOf(persoAAttaquer.GetIllusionisteParent().GetNbIllusionOf() - 1);
                            persoAAttaquer.GetIllusionisteParent().Passive();
                            charactersEaten.Add(persoAAttaquer);
                            persosAAttaquer.Remove(persoAAttaquer);
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
                    //pas touché
                    Console.WriteLine(persoAAttaquer.GetName() + " se défend !");
                }
            }
            else
            {
                Console.WriteLine("Il n'y a plus de persos à attaquer !");
            }
        }
    }
}
