﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Character
    {
        public string name;
        public int attack;
        public int defense;
        public float attackSpeed;
        public int damages;
        public int maximumLife;
        public int currentLife;
        public float powerSpeed;
        public bool isUndead;
        public bool hitRadiantDamages;
        public bool isHidden;
        public bool isEaten;
        public bool affectedByAttackDelay;
        public bool isHited;
        public int delay;
        public bool canBePoisoned;
        public int stackPoison = 0;
        public Random rand;
        Object _lock = new Object();
        Object _lock2 = new Object();
        public event EventHandler appelPowerIllusioniste;
        public Character illusionisteParent;
        public int nbIllusionOf = 0;
        public event EventHandler appelPowerNecro;
        public FightManager fightManager;
        public int scoring = 0;
        public int nbMorts = 0;

        public Character()
        {
            this.attack = 75;
            this.defense = 75;
            this.attackSpeed = 1f;
            this.damages = 30;
            this.maximumLife = 200;
            this.currentLife = 200;
            this.powerSpeed = 1f;
            this.isUndead = false;
            this.hitRadiantDamages = false;
            this.isHidden = false;
            this.isEaten = false;
            this.affectedByAttackDelay = true;
            this.isHited = false;
            this.delay = 0;
            this.canBePoisoned = true;
            this.stackPoison = 0;
            this.illusionisteParent = null;
        }

        public Character(string name)
        {
            this.name = name;
            this.attack = 75;
            this.defense = 75;
            this.attackSpeed = 1f;
            this.damages = 2;
            this.maximumLife = 200;
            this.currentLife = 200;
            this.powerSpeed = 1f;
            this.isUndead = false;
            this.hitRadiantDamages = false;
            this.isHidden = false;
            this.isEaten = false;
            this.affectedByAttackDelay = true;
            this.isHited = false;
            this.delay = 0;
            this.canBePoisoned = true;
            this.stackPoison = 0;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
            this.illusionisteParent = null;
            this.nbIllusionOf = 0;
            this.scoring = 0;

            this.Reset();
        }

        public Character(string name, int pattack, int pdefense, float pattackSpeed, int pdamages, int pmaximumLife, int pcurrentLife, float ppowerSpeed)
        {
            this.name = name;
            this.attack = pattack;
            this.defense = pdefense;
            this.attackSpeed = pattackSpeed;
            this.damages = pdamages;
            this.maximumLife = pmaximumLife;
            this.currentLife = pcurrentLife;
            this.powerSpeed = ppowerSpeed;
            this.isUndead = false;
            this.hitRadiantDamages = false;
            this.isHidden = false;
            this.isEaten = false;
            this.affectedByAttackDelay = true;
            this.isHited = false;
            this.delay = 0;
            this.canBePoisoned = true;
            this.stackPoison = 0;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }

        public Character(string name, int pattack, int pdefense, float pattackSpeed, int pdamages, int pmaximumLife, int pcurrentLife, float ppowerSpeed, bool pisUndead, bool phitRadiantDamages, bool pisHidden, bool pisEaten, bool pAffectedByAttackDelay, bool pIsHited, int pdelay, bool pcanBePoisoned, int pstackPoison)
        {
            this.name = name;
            this.attack = pattack;
            this.defense = pdefense;
            this.attackSpeed = pattackSpeed;
            this.damages = pdamages;
            this.maximumLife = pmaximumLife;
            this.currentLife = pcurrentLife;
            this.powerSpeed = ppowerSpeed;
            this.isUndead = pisUndead;
            this.hitRadiantDamages = phitRadiantDamages;
            this.isHidden = pisHidden;
            this.isEaten = pisEaten;
            this.affectedByAttackDelay = pAffectedByAttackDelay;
            this.isHited = pIsHited;
            this.delay = pdelay;
            this.canBePoisoned = pcanBePoisoned;
            this.stackPoison = pstackPoison;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }
        
        public string GetName()
        {
            return this.name;
        }

        public void SetName(string pName)
        {
            this.name = pName;
        }

        public int GetAttack()
        {
            return this.attack;
        }

        public void SetAttack(int pAttack)
        {
            this.attack = pAttack;
        }

        public int GetDefense()
        {
            return this.defense;
        }

        public void SetDefense(int pDefense)
        {
            this.defense = pDefense;
        }

        public float GetAttackSpeed()
        {
            return this.attackSpeed;
        }

        public void SetAttackSpeed(float pAttackSpeed)
        {
            this.attackSpeed = pAttackSpeed;
        }

        public int GetDamages()
        {
            return this.damages;
        }

        public void SetDamages(int pDamages)
        {
            this.damages = pDamages;
        }

        public int GetMaximumLife()
        {
            return this.maximumLife;
        }

        public void SetMaximumLife(int pMaximumLife)
        {
            this.maximumLife = pMaximumLife;
        }

        public int GetCurrentLife()
        {
            return this.currentLife;
        }

        public void SetCurrentLife(int pCurrentLife)
        {
            this.currentLife = pCurrentLife;
        }

        public float GetPowerSpeed()
        {
            return this.powerSpeed;
        }

        public void SetPowerSpeed(float pPowerSpeed)
        {
            this.powerSpeed = pPowerSpeed;
        }

        public bool GetIsUndead()
        {
            return this.isUndead;
        }

        public void SetIsUndead(bool pIsUndead)
        {
            this.isUndead = pIsUndead;
        }

        public bool GetHitRadiantDamages()
        {
            return this.hitRadiantDamages;
        }

        public void SetHitRadiantDamages(bool pHitRadiantDamages)
        {
            this.hitRadiantDamages = pHitRadiantDamages;
        }

        public bool GetIsHidden()
        {
            return this.isHidden;
        }

        public void SetIsHidden(bool pIsHidden)
        {
            this.isHidden = pIsHidden;
        }

        public bool GetIsEaten()
        {
            return this.isEaten;
        }

        public void SetIsEaten(bool pIsEaten)
        {
            this.isEaten = pIsEaten;
        }

        public bool GetAffectedByAttackDelay()
        {
            return this.affectedByAttackDelay;
        }

        public void SetAffectedByAttackDelay(bool pAffectedByAttackDelay)
        {
            this.affectedByAttackDelay = pAffectedByAttackDelay;
        }

        public bool GetIsHited()
        {
            return this.isHited;
        }

        public void SetIsHited(bool pIsHited)
        {
            this.isHited = pIsHited;
        }

        public int GetDelay()
        {
            return this.delay;
        }

        public void SetDelay(int pDelay)
        {
            this.delay = pDelay;
        }

        public bool GetCanBePoisoned()
        {
            return this.canBePoisoned;
        }

        public void SetCanBePoisoned(bool pCanBePoisoned)
        {
            this.canBePoisoned = pCanBePoisoned;
        }

        public int GetStackPoison()
        {
            return this.stackPoison;
        }

        public void SetStackPoison(int pStackPoison)
        {
            this.stackPoison = pStackPoison;
        }
        public Character GetIllusionisteParent()
        {
            return this.illusionisteParent;
        }

        public int GetNbIllusionOf()
        {
            return this.nbIllusionOf;
        }
        public void SetNbIllusionOf(int pNbIllusionOf)
        {
            this.nbIllusionOf = pNbIllusionOf;
        }

        public int GetScoring()
        {
            return this.scoring;
        }

        public void SetScoring(int pScoring)
        {
            this.scoring = pScoring;
        }


        public virtual void Power(List<Character> characters, List<Character> charactersEaten)
        {
            Console.WriteLine("Power de " + this.name + " activé !");
        }

        public virtual void Passive()
        {
            Console.WriteLine("Passive de " + this.name + " activé !");
        }

        public virtual int RollDice()
        {
            return rand.Next(1, 101);
        }

        public void Score(int nbMorts)
        {
            this.SetScoring(nbMorts);
            Console.WriteLine("Score de " + this.GetName() + " est de " + this.GetScoring().ToString() + " !");
        }
        






        //TO DO ATTACK()
        public virtual void Attack(Character persoAAttaquer)
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
                persoAAttaquer.TakeDamages(damagesSubis);
                if (persoAAttaquer.GetAffectedByAttackDelay() == true)
                {
                    if(persoAAttaquer.GetCurrentLife() > 0)
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

        public virtual void AttackTest(Character persoAAttaquer, int jetAttaque, int jetDefense)
        {
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
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

        public virtual void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            lock (_lock)
            {
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
                        if (persoAAttaquer.GetCurrentLife() <= 0)
                        {
                            if(persoAAttaquer is IllusionOf) {
                                Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                            }
                            else
                            {
                                Console.WriteLine(persoAAttaquer.GetName() + " est mort !");
                                nbMorts++;
                                persoAAttaquer.Score(nbMorts);
                            }
                            
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

        public virtual void TakeDamages(int damagesSubis)
        {
            Console.WriteLine(this.GetName() + " subit " + damagesSubis.ToString() + " dégâts !");
            this.SetCurrentLife(this.GetCurrentLife() - damagesSubis);
        }

        public virtual int NameToInt()
        {
            int result = 0;
            foreach (char c in this.GetName())
            {
                result += c;
            }

            return result;
        }

        public virtual void OnAppelPowerIllusioniste(EventArgs e)
        {
            EventHandler handler = appelPowerIllusioniste;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public virtual void OnAppelPowerNecro(EventArgs e)
        {
            EventHandler handler = appelPowerNecro;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SetFightManager(FightManager fightManager)
        {
            this.fightManager = fightManager;
        }

        public virtual void Reset()
        {
            this.SetCurrentLife(this.GetMaximumLife());
            this.SetDelay(0);
            this.SetStackPoison(0);
            this.SetNbIllusionOf(0);
        }
    }
}
