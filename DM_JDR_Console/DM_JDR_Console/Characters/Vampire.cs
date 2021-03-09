using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Vampire : Character, ICharacter
    {
        public int totalDamagesBetweenPower = 0;
        public int soins = 0;
        public Random rand;
        public Vampire(string name)
        {
            this.name = name;
            this.attack = 125;
            this.defense = 125;
            this.attackSpeed = 2f;
            this.damages = 50;
            this.maximumLife = 150;
            this.currentLife = 150;
            this.powerSpeed = 0.2f;
            this.isUndead = true;
            this.canBePoisoned = false;
            this.totalDamagesBetweenPower = 0;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }

        public int GetTotalDamagesBetweenPower()
        {
            return this.totalDamagesBetweenPower;
        }

        public void SetTotalDamagesBetweenPower(int pTotalDamagesBetweenPower)
        {
            this.totalDamagesBetweenPower = pTotalDamagesBetweenPower;
        }

        public override void Passive()
        {
            this.SetCurrentLife(this.GetCurrentLife() + soins);
            if(this.GetCurrentLife() > this.GetMaximumLife())
            {
                this.SetCurrentLife(this.GetMaximumLife());
            }
        }

        public override void Power(List<Character> characters)
        {
            int indexPersoANiquer = rand.Next(characters.Count);
            bool persoAffectedByPower = false;
            for (int i = 0; i < characters.Count; i++)
            {
                if(characters[i].GetAffectedByAttackDelay() == true)
                {
                    persoAffectedByPower = true;
                }
            }
            while (indexPersoANiquer == characters.IndexOf(this) && persoAffectedByPower == true)
            {
                indexPersoANiquer = rand.Next(characters.Count);
            }
            Console.WriteLine("Le perso à niquer par le vampire " + this.GetName() + " est " + characters.ElementAt(indexPersoANiquer).GetName() + " !");
            if(characters.ElementAt(indexPersoANiquer).GetAffectedByAttackDelay() == true)
            {
                characters.ElementAt(indexPersoANiquer).SetDelay(characters.ElementAt(indexPersoANiquer).GetDelay() + this.GetTotalDamagesBetweenPower());
                Console.WriteLine("Perso niqué !");
                Console.WriteLine(characters.ElementAt(indexPersoANiquer).GetName() + " a pris un délai supplémentaire de " + this.GetTotalDamagesBetweenPower() + " millisecondes !");
            }
            else
            {
                Console.WriteLine("Perso insensible au délai d'attaque...");
            }
            this.SetTotalDamagesBetweenPower(0);

        }

        public override void TakeDamages(int damagesSubis)
        {
            base.TakeDamages(damagesSubis);
            if(this is Vampire)
            {
                this.SetTotalDamagesBetweenPower(this.GetTotalDamagesBetweenPower() + damagesSubis);
            }
        }

        public int SoinsVampiriques(int degatsDonnes)
        {
            return (int)Math.Round(degatsDonnes * 0.5f);
        }

        public override void Attack(Character persoAAttaquer)
        {
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
                persoAAttaquer.TakeDamages(damagesSubis);
                soins = SoinsVampiriques(damagesSubis);
                this.Passive();
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
            persoAAttaquer.SetIsHited(false);
            persoAAttaquer.SetDelay(0);
            if (jetAttaque - jetDefense > 0)
            {
                //touché
                persoAAttaquer.SetIsHited(true);
                int damagesSubis = (jetAttaque - jetDefense) * this.GetDamages() / 100;
                persoAAttaquer.TakeDamages(damagesSubis);
                soins = SoinsVampiriques(damagesSubis);
                this.Passive();
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

        public int NameToInt()
        {
            int result = 0;
            foreach (char c in this.GetName())
            {
                result += c;
            }

            return result;
        }
    }
}
