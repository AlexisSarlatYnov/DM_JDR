﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Berserker : Character, ICharacter
    {

        public int lostLifeInAHit = 0;
        public int lostLifeTotal = 0;
        public float initialAttackSpeed = 1.1f;
        Object _lock = new Object();

        public Berserker(string name)
        {
            this.name = name;
            this.attack = 50;
            this.defense = 50;
            this.attackSpeed = 1.1f;
            this.damages = 20;
            this.maximumLife = 400;
            this.currentLife = 400;
            this.powerSpeed = 1f;
            this.affectedByAttackDelay = false;
            this.lostLifeInAHit = 0;
            this.lostLifeTotal = 0;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);

            this.Reset();
        }

        public int GetLostLifeInAHit()
        {
            return this.lostLifeInAHit;
        }

        public void SetLostLifeInAHit(int pLostLifeInAHit)
        {
            this.lostLifeInAHit = pLostLifeInAHit;
        }

        public int GetLostLifeTotal()
        {
            return this.lostLifeTotal;
        }

        public void SetLostLifeTotal(int pLostLifeTotal)
        {
            this.lostLifeTotal = pLostLifeTotal;
        }

        /*public void BerserkerPower()
        {
            this.SetAttack(this.GetAttack() + (int)Math.Round(this.GetLostLifeInAHit() / 2f));
            this.SetDamages(this.GetDamages() + (int)Math.Round(this.GetLostLifeInAHit() / 2f));
            int dixPourcentMaxLife = (int)(this.GetMaximumLife() * 0.1f);
            Console.WriteLine(dixPourcentMaxLife.ToString());
            int bonusAttackSpeed = this.GetCurrentLife() / dixPourcentMaxLife;
            int reste = this.GetCurrentLife() % dixPourcentMaxLife;
            Console.WriteLine(bonusAttackSpeed.ToString());
            this.SetAttackSpeed(initialAttackSpeed);
            for (int i = 10; i > 0; i--)
            {
                if (bonusAttackSpeed < i)
                {
                    this.SetAttackSpeed(this.GetAttackSpeed() + 0.3f);
                }
            }
            if(reste != 0)
            {
                this.SetAttackSpeed(this.GetAttackSpeed() - 0.3f);
            }
        }*/

        /*public void BerserkerPassive()
        {
            this.SetAffectedByAttackDelay(false);
            if(this.GetLostLifeInAHit() > (int)Math.Round(this.GetCurrentLife() / 2f))
            {
                this.SetAffectedByAttackDelay(true);
            }
        }*/

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            lock (_lock)
            {
                if (this.GetCurrentLife() > 0)
                {
                    this.SetAttack(this.GetAttack() + (int)Math.Round(this.GetLostLifeInAHit() / 2f));
                    this.SetDamages(this.GetDamages() + (int)Math.Round(this.GetLostLifeInAHit() / 2f));
                    int dixPourcentMaxLife = (int)(this.GetMaximumLife() * 0.1f);
                    Console.WriteLine(dixPourcentMaxLife.ToString());
                    int bonusAttackSpeed = this.GetCurrentLife() / dixPourcentMaxLife;
                    int reste = this.GetCurrentLife() % dixPourcentMaxLife;
                    Console.WriteLine(bonusAttackSpeed.ToString());
                    this.SetAttackSpeed(initialAttackSpeed);
                    for (int i = 10; i > 0; i--)
                    {
                        if (bonusAttackSpeed < i)
                        {
                            this.SetAttackSpeed(this.GetAttackSpeed() + 0.3f);
                        }
                    }
                    if (reste != 0)
                    {
                        this.SetAttackSpeed(this.GetAttackSpeed() - 0.3f);
                    }
                }
            }
        }

        public override void Passive()
        {
            this.SetAffectedByAttackDelay(false);
            if (this.GetLostLifeInAHit() > (int)Math.Round(this.GetCurrentLife() / 2f))
            {
                this.SetAffectedByAttackDelay(true);
            }
        }

        public override int RollDice()
        {
            return base.RollDice();
        }

        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            base.AttackGenerale(persosAAttaquer, charactersEaten);
        }

        public override void Reset()
        {
            base.Reset();
            this.SetLostLifeInAHit(0);
            this.SetLostLifeTotal(0);
        }
    }
}
