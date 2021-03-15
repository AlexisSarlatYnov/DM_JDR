using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Guerrier : Character, ICharacter
    {
        public event EventHandler<AppelPowerEventArgs> appelPower;
        public Guerrier(string name)
        {
            this.name = name;
            this.attack = 150;
            this.defense = 105;
            this.attackSpeed = 2.2f;
            this.damages = 150;
            this.maximumLife = 250;
            this.currentLife = 250;
            this.powerSpeed = 0.2f;
        }

        /*public void GuerrierPower()
        {
            AppelPowerEventArgs args = new AppelPowerEventArgs();
            args.bonusAttackSpeed = 0.5f;
            args.guerrier = this;
            OnAppelPower(args);
        }*/

        protected virtual void OnAppelPower(AppelPowerEventArgs e)
        {
            EventHandler<AppelPowerEventArgs> handler = appelPower;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public override void Power(List<Character> characters, List<Character> charactersEaten)
        {
            AppelPowerEventArgs args = new AppelPowerEventArgs();
            args.bonusAttackSpeed = 0.5f;
            args.guerrier = this;
            OnAppelPower(args);
        }

        public override void Passive()
        {
            base.Passive();
        }

        public override int RollDice()
        {
            return base.RollDice();
        }

        public class AppelPowerEventArgs : EventArgs
        {
            public float bonusAttackSpeed { get; set; }
            public Guerrier guerrier { get; set; }
        }
    }
}
