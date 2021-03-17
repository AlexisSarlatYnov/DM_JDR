using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Alchimiste : Character, ICharacter
    {
        Object _lock = new Object();
        Object _lock2 = new Object();
        public Alchimiste(string name)
        {
            this.name = name;
            this.attack = 50;
            this.defense = 50;
            this.attackSpeed = 1.0f;
            this.damages = 30;
            this.maximumLife = 150;
            this.currentLife = 150;
            this.powerSpeed = 0.1f;
            this.hitRadiantDamages = true;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);

            this.Reset();
        }

        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            lock (_lock)
            {
                if (persosAAttaquer.Count > 0)
                {
                    List<Character> listCibles = new List<Character>();
                    for (int i = 0; i < persosAAttaquer.Count; i++)
                    {
                        if (EstCible() == true && persosAAttaquer[i] != this && persosAAttaquer[i].GetCurrentLife() > 0)
                        {
                            listCibles.Add(persosAAttaquer[i]);
                        }
                    }

                    for (int i = 0; i < listCibles.Count; i++)
                    {
                        Character persoAAttaquer = listCibles[i];
                        Console.WriteLine("Le perso ciblé attaqué est " + persoAAttaquer.GetName() + " !");
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
                            if (persoAAttaquer.GetIsHidden() == true)
                            {
                                persoAAttaquer.SetIsHidden(false);
                                Console.WriteLine(persoAAttaquer.GetName() + " n'est plus camouflé !");
                            }
                            int damagesSubis = (int)((jetAttaque - jetDefense) * this.GetDamages() / 100 * 0.5f);
                            if (persoAAttaquer.GetIsUndead() == true)
                            {
                                damagesSubis = damagesSubis * 2;
                            }
                            else
                            {
                                if (persoAAttaquer.GetCanBePoisoned() == true)
                                {
                                    persoAAttaquer.SetStackPoison(persoAAttaquer.GetStackPoison() + damagesSubis);
                                    Console.WriteLine("Stack de poison de " + persoAAttaquer.GetName() + "  est de " + persoAAttaquer.GetStackPoison() + " dégâts empoisonnés !");

                                }
                                else
                                {
                                    Console.WriteLine(persoAAttaquer.GetName() + " ne peut pas être empoisonné !");
                                }
                            }
                            persoAAttaquer.TakeDamages(damagesSubis);
                            if (persoAAttaquer.GetCurrentLife() <= 0)
                            {
                                Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                OnAppelPowerNecro(EventArgs.Empty);
                                for (int j = 0; j < persosAAttaquer.Count; j++)
                                {
                                    if (persosAAttaquer[j] is Necromancien)
                                    {
                                        persosAAttaquer[j].Passive();
                                    }
                                }
                            }
                            if (persoAAttaquer.GetAffectedByAttackDelay() == true && persoAAttaquer.GetCurrentLife() > 0)
                            {
                                persoAAttaquer.SetDelay(damagesSubis);
                            }
                            if (persoAAttaquer is IllusionOf)
                            {
                                lock (_lock2)
                                {
                                    OnAppelPowerIllusioniste(EventArgs.Empty);
                                    persoAAttaquer.GetIllusionisteParent().SetNbIllusionOf(persoAAttaquer.GetIllusionisteParent().GetNbIllusionOf() - 1);
                                    persoAAttaquer.GetIllusionisteParent().Passive();
                                    charactersEaten.Add(persoAAttaquer);
                                    persosAAttaquer.Remove(persoAAttaquer);
                                    Console.WriteLine("Illusion " + persoAAttaquer.GetName() + " éliminée !");
                                }
                            }
                        }
                        else
                        {
                            //pas touché
                            Console.WriteLine(persoAAttaquer.GetName() + " se défend !");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Il n'y a plus de persos à attaquer !");
                }
            }
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
                    Character persoTransfertCurrentLife = new Character();
                    for (int i = 0; i < characters.Count; i++)
                    {
                        if (i == 0)
                        {
                            persoTransfertCurrentLife = characters[i];
                        }
                        else
                        {
                            if (characters[i].GetCurrentLife() > persoTransfertCurrentLife.GetCurrentLife())
                            {
                                persoTransfertCurrentLife = characters[i];
                            }
                        }
                    }
                    int currentLifeTranfertAlchimiste = this.GetCurrentLife();
                    this.SetCurrentLife(persoTransfertCurrentLife.GetCurrentLife());
                    persoTransfertCurrentLife.SetCurrentLife(currentLifeTranfertAlchimiste);
                    if (this.GetCurrentLife() > this.GetMaximumLife())
                    {
                        this.SetCurrentLife(this.GetMaximumLife());
                    }
                    Console.WriteLine(this.GetName() + " a échangé ses points de vie avec " + persoTransfertCurrentLife.GetName() + " !");
                    Console.WriteLine(this.GetName() + " a maintenant " + this.GetCurrentLife().ToString() + " points de vie !");
                    Console.WriteLine("Et " + persoTransfertCurrentLife.GetName() + " a maintenant " + persoTransfertCurrentLife.GetCurrentLife().ToString() + " points de vie !");
                }
            }
        }

        public override int RollDice()
        {
            return rand.Next(1, 201);
        }

        public override void TakeDamages(int damagesSubis)
        {
            base.TakeDamages(damagesSubis);
        }

        public bool EstCible()
        {
            int piece = rand.Next(1, 3);
            if (piece == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
