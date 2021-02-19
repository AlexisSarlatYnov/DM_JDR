using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Character
    {
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
        }

        public Character(int pattack, int pdefense, float pattackSpeed, int pdamages, int pmaximumLife, int pcurrentLife, float ppowerSpeed)
        {
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
        }

        public Character(int pattack, int pdefense, float pattackSpeed, int pdamages, int pmaximumLife, int pcurrentLife, float ppowerSpeed, bool pisUndead, bool phitRadiantDamages, bool pisHidden)
        {
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
    }
}
