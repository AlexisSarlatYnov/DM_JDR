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
        public bool isEaten;
        public bool affectedByAttackDelay;
        public bool isHited;
        public int delay;
        
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
            this.isEaten = false;
            this.affectedByAttackDelay = true;
            this.isHited = false;
            this.delay = 0;
        }

        public Character(int pattack, int pdefense, float pattackSpeed, int pdamages, int pmaximumLife, int pcurrentLife, float ppowerSpeed, bool pisUndead, bool phitRadiantDamages, bool pisHidden, bool pisEaten, bool pAffectedByAttackDelay, bool pIsHited, int pdelay)
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
            this.isEaten = pisEaten;
            this.affectedByAttackDelay = pAffectedByAttackDelay;
            this.isHited = pIsHited;
            this.delay = pdelay;
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












        //TO DO ATTACK()
        public virtual void Attack(Character persoAAttaquer)
        {
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
            Random rand = new Random();
            int jetAttaque = this.GetAttack() + rand.Next(1,100);
            Console.WriteLine("Jet d'attaque : " + jetAttaque.ToString());
            int jetDefense = persoAAttaquer.GetDefense() + rand.Next(1, 100);
            Console.WriteLine("Jet de défense : " + jetDefense.ToString());
            if (jetAttaque - jetDefense > 0)
            {
                //touché
                persoAAttaquer.SetIsHited(true);
                int damagesSubis = (jetAttaque - jetDefense) * this.GetDamages() / 100;
                persoAAttaquer.SetCurrentLife(persoAAttaquer.GetCurrentLife() - damagesSubis);
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
    }
}
