using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Magicien : Character, ICharacter
    {
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
        }
        public override void AttackGenerale(List<Character> persosAAttaquer)
        {
            base.AttackGenerale(persosAAttaquer);
        }

        public override void Passive()
        {
            base.Passive();
        }

        public override void Power(List<Character> characters)
        {
            int damagesPower = this.GetDamages() * 5;
            int attackPower = this.GetAttack() * 5;
            Console.WriteLine("DamagesPower est égal à " + damagesPower.ToString());
            int index = rand.Next(characters.Count);
            while (index == characters.IndexOf(this))
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
                int damagesSubis = (jetAttaque - jetDefense) * damagesPower / 100;
                persoAAttaquer.TakeDamages(damagesSubis);
                if (persoAAttaquer.GetAffectedByAttackDelay() == true && persoAAttaquer.GetCurrentLife() > 0)
                {
                    persoAAttaquer.SetDelay(damagesSubis);
                }
                else
                {
                    Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                }
                bool attackContinue = true;
                int currentDamagesPower = damagesPower;
                bool tousMort = false;
                int cptMorts = 0;
                for (int i = 0; i < characters.Count; i++)
                {
                    if (characters[i].GetCurrentLife() <= 0)
                    {
                        cptMorts++;
                    }
                }
                while (attackContinue == true && currentDamagesPower > 0 && tousMort == false)
                {
                    currentDamagesPower = currentDamagesPower - (int)(damagesPower * 0.1f);
                    Console.WriteLine("CurrentDamagesPower est égal à " + currentDamagesPower.ToString());
                    if(currentDamagesPower <= 0 || tousMort == true)
                    {
                        attackContinue = false;
                    }
                    if (attackContinue == true)
                    {
                        index = rand.Next(characters.Count);
                        while (index == characters.IndexOf(this) && tousMort == false || characters[index].GetCurrentLife() <= 0 && tousMort == false)
                        {
                            Console.WriteLine("Nombre de morts est de : " + cptMorts.ToString() + " morts !");
                            if(cptMorts == (characters.Count - 1))
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
                                persoAAttaquer.SetIsHited(true);
                                damagesSubis = (jetAttaque - jetDefense) * damagesPower / 100;
                                persoAAttaquer.TakeDamages(damagesSubis);
                                if (persoAAttaquer.GetAffectedByAttackDelay() == true && persoAAttaquer.GetCurrentLife() > 0)
                                {
                                    persoAAttaquer.SetDelay(damagesSubis);
                                }
                                else
                                {
                                    Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                    cptMorts++;
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
