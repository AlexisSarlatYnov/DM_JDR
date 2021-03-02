using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Paladin : Character, ICharacter
    {
        public Paladin()
        {
            this.attack = 60;
            this.defense = 145;
            this.attackSpeed = 1.6f;
            this.damages = 40;
            this.maximumLife = 250;
            this.currentLife = 250;
            this.powerSpeed = 0.5f;
            this.hitRadiantDamages = true;
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
            persoAAttaquer.SetAffectedByAttackDelay(true);
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
            Random rand = new Random();
            int jetAttaque = this.GetAttack() + rand.Next(1, 100);
            Console.WriteLine("Jet d'attaque : " + jetAttaque.ToString());
            int jetDefense = persoAAttaquer.GetDefense() + rand.Next(1, 100);
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

        public override void AttackTest(Character persoAAttaquer, int jetAttaque, int jetDefense)
        {
            persoAAttaquer.SetAffectedByAttackDelay(true);
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

        public override void Power(List<Character> characters)
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
    }
}
