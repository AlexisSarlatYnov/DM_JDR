using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Illusioniste : Character, ICharacter
    {
        public Illusioniste(string name)
        {
            this.name = name;
            this.attack = 75;
            this.defense = 75;
            this.attackSpeed = 1.0f;
            this.damages = 50;
            this.maximumLife = 100;
            this.currentLife = 100;
            this.powerSpeed = 0.5f;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }

        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            base.AttackGenerale(persosAAttaquer, charactersEaten);
        }

        public override void Passive()
        {
            this.SetAttack(75 + 10 * nbIllusionOf);
        }

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            nbIllusionOf++;
            this.Passive();
            IllusionOf illusionOf = new IllusionOf(this, nbIllusionOf);
            characters.Add(illusionOf);
            Console.WriteLine("Illusion " + illusionOf.GetName() + " créée !");
        }

        
    }
}
