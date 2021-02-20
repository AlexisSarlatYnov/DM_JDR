using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Berserker : Character
    {

        public int lostLifeInAHit = 0;
        public int lostLifeTotal = 0;
        public float initialAttackSpeed = 1f;
        public Berserker()
        {
            this.attack = 50;
            this.defense = 50;
            this.attackSpeed = 1.1f;
            this.damages = 20;
            this.maximumLife = 400;
            this.currentLife = 400;
            this.powerSpeed = 1f;
            this.lostLifeInAHit = 0;
            this.lostLifeTotal = 0;
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

        public void BerserkerPower()
        {
            this.SetAttack(this.GetAttack() + (int)Math.Round(this.GetLostLifeInAHit() / 2f));
            this.SetDefense(this.GetDefense() + (int)Math.Round(this.GetLostLifeInAHit() / 2f));
            int dixPourcentMaxLife = (int)(this.GetMaximumLife() * 0.1f);
            
        }



        //TO DO Passif
    }
}
