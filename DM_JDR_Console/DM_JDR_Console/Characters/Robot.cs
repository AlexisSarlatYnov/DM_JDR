using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Robot : Character, ICharacter
    {
        Object _lock = new Object();
        public Robot(string name)
        {
            this.name = name;
            this.attack = 25;
            this.defense = 100;
            this.attackSpeed = 1.2f;
            this.damages = 50;
            this.maximumLife = 275;
            this.currentLife = 275;
            this.powerSpeed = 0.5f;
            this.canBePoisoned = false;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);

            this.Reset();
        }

        public override void AttackGenerale(List<Character> persosAAttaquer, List<Character> charactersEaten)
        {
            base.AttackGenerale(persosAAttaquer, charactersEaten);
        }

        public override void Passive()
        {
            base.Passive();
        }

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            lock (_lock)
            {
                if (this.GetCurrentLife() > 0)
                {
                    this.SetAttack((int)Math.Round(this.GetAttack() * 1.5f));
                }
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.SetAttack(25);
        }

        public override int RollDice()
        {
            return 50;
        }
    }
}
