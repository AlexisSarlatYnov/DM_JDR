using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Assassin : Character, ICharacter
    {
        Object _lock = new Object();
        Object _lock2 = new Object();

        public Assassin(string name)
        {
            this.name = name;
            this.attack = 150;
            this.defense = 100;
            this.attackSpeed = 1.0f;
            this.damages = 100;
            this.maximumLife = 185;
            this.currentLife = 185;
            this.powerSpeed = 0.5f;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);

            this.Reset();
        }

        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            lock (_lock)
            {
                this.SetIsHidden(false);
                if (persosAAttaquer.Count > 0)
                {
                    int index = rand.Next(persosAAttaquer.Count);
                    while (index == persosAAttaquer.IndexOf(this) && persosAAttaquer.Count > 0 || persosAAttaquer[index].GetCurrentLife() <= 0 && persosAAttaquer.Count > 0 || persosAAttaquer[index].GetIsHidden() == true && persosAAttaquer.Count > 0)
                    {
                        index = rand.Next(persosAAttaquer.Count);
                    }
                    Console.WriteLine("Liste.Count = " + persosAAttaquer.Count.ToString());
                    Console.WriteLine("Index = " + index.ToString());
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
                        if (persoAAttaquer.GetIsUndead() == false && persoAAttaquer.GetCanBePoisoned() == true)
                        {
                            persoAAttaquer.SetStackPoison(persoAAttaquer.GetStackPoison() + (int)(damagesSubis * 0.1f));
                            Console.WriteLine("Stack de poison de " + persoAAttaquer.GetName() + "  est de " + persoAAttaquer.GetStackPoison() + " dégâts empoisonnés !");
                        }
                        else
                        {
                            Console.WriteLine(persoAAttaquer.GetName() + " ne peut pas être empoisonné !");
                        }
                        if ((persoAAttaquer.GetCurrentLife() / 2) < damagesSubis)
                        {
                            persoAAttaquer.SetCurrentLife(0);
                            Console.WriteLine(persoAAttaquer.GetName() + " a pris un coup critique de l'assassin " + this.GetName() + " !");
                        }
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
            if (this.GetCurrentLife() > 0)
            {
                int cptVivants = 0;
                for (int i = 0; i < characters.Count; i++)
                {
                    if (characters[i].GetCurrentLife() > 0)
                    {
                        cptVivants++;
                    }
                }
                if (cptVivants >= 5)
                {
                    this.SetIsHidden(true);
                    Console.WriteLine(this.GetName() + " est camouflé !");
                }
                else
                {
                    this.SetIsHidden(false);
                    Console.WriteLine(this.GetName() + " ne peut se camoufler car pas assez de combattants !");
                }
            }
        }
    }
}
