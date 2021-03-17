using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Necromancien : Character, ICharacter
    {
        Object _lock = new Object();
        Object _lock2 = new Object();

        public Necromancien(string name)
        {
            this.name = name;
            this.attack = 0;
            this.defense = 10;
            this.attackSpeed = 1.0f;
            this.damages = 0;
            this.maximumLife = 275;
            this.currentLife = 275;
            this.powerSpeed = 5.0f;
            this.isUndead = true;
            this.canBePoisoned = false;
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
                        persoAAttaquer.TakeDamages(damagesSubis);
                        if (persoAAttaquer.GetIsUndead() == false && persoAAttaquer.GetCanBePoisoned() == true)
                        {
                            persoAAttaquer.SetStackPoison(persoAAttaquer.GetStackPoison() + (int)(damagesSubis * 0.5f));
                            Console.WriteLine("Stack de poison de " + persoAAttaquer.GetName() + "  est de " + persoAAttaquer.GetStackPoison() + " dégâts empoisonnés !");
                        }
                        else
                        {
                            Console.WriteLine(persoAAttaquer.GetName() + " ne peut pas être empoisonné !");
                        }
                        if (persoAAttaquer.GetCurrentLife() <= 0)
                        {
                            Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                            OnAppelPowerNecro(EventArgs.Empty);
                            for (int i = 0; i < persosAAttaquer.Count; i++)
                            {
                                if (persosAAttaquer[i] is Necromancien)
                                {
                                    persosAAttaquer[i].Passive();
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
            this.SetAttack(this.GetAttack() + 5);
            this.SetDefense(this.GetDefense() + 5);
            this.SetDamages(this.GetDamages() + 5);
            this.SetCurrentLife(this.GetCurrentLife() + 50);
            this.SetMaximumLife(this.GetMaximumLife() + 50);
        }

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            lock (_lock)
            {
                if (this.GetCurrentLife() > 0)
                {
                    int cptMorts = 0;
                    for (int i = 0; i < characters.Count; i++)
                    {
                        if (characters[i].GetCurrentLife() <= 0)
                        {
                            cptMorts++;
                        }
                    }
                    if (charactersEaten.Count > 0)
                    {
                        cptMorts = cptMorts + charactersEaten.Count;
                    }
                    if (cptMorts == 0 && characters.Count >= 5)
                    {
                        this.SetIsHidden(true);
                        Console.WriteLine(this.GetName() + " est camouflé !");
                    }
                    else
                    {
                        this.SetIsHidden(false);
                        Console.WriteLine(this.GetName() + " ne peut pas être camouflé !");
                    }
                }
            }
        }

        public override int RollDice()
        {
            return rand.Next(1, 151);
        }

        public override void TakeDamages(int damagesSubis)
        {
            damagesSubis = (int)(damagesSubis * 0.5f);
            Console.WriteLine(this.GetName() + " subit " + damagesSubis.ToString() + " dégâts !");
            this.SetCurrentLife(this.GetCurrentLife() - damagesSubis);
        }
    }
}
