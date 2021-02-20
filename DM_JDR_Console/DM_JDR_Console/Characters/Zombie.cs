﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class Zombie : Character
    {
        Object _lock = new Object();

        public Zombie()
        {
            this.attack = 150;
            this.defense = 0;
            this.attackSpeed = 1f;
            this.damages = 20;
            this.maximumLife = 1500;
            this.currentLife = 1500;
            this.powerSpeed = 0.1f;
            this.isUndead = true;
            this.affectedByAttackDelay = false;
        }

        public void ZombiePower(List<Character> characsAManger)
        {
            Character characAManger;
            List<Character> characsSelection = new List<Character>();
            Random random = new Random();
            foreach (Character personnage in characsAManger) {
                if (personnage.GetIsEaten() == false && personnage.GetCurrentLife() == 0)
                {
                    characsSelection.Add(personnage);
                }
            }

            if (characsSelection.Count == 0)
            {
                Console.WriteLine("Pas de personnage à manger !");
            }
            else
            {
                int index = random.Next(characsSelection.Count);
                characAManger = characsSelection[index];
                Console.WriteLine(characsSelection[index]);

                if (characAManger.GetIsEaten() == false && characAManger.GetCurrentLife() == 0)
                {
                    lock (_lock)
                    {
                        characAManger.SetIsEaten(true);
                    }
                    this.SetCurrentLife(this.GetCurrentLife() + characAManger.GetMaximumLife());
                    if (this.GetCurrentLife() > this.GetMaximumLife())
                    {
                        this.SetCurrentLife(this.GetMaximumLife());
                    }
                }
            }
        }

        public void ZombiePassive()
        {
            if(this.GetDefense() > 0)
            {
                this.SetDefense(0);
            }
            if(this.GetAffectedByAttackDelay() != false)
            {
                this.SetAffectedByAttackDelay(false);
            }
            if (this.GetIsUndead() != true)
            {
                this.SetIsUndead(true);
            }
        }
    }
}