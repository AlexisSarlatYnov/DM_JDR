using DM_JDR_Console.Characters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DM_JDR_Console
{
    class FightManager
    {
        public List<Character> charactersList = new List<Character>();
        public List<Character> charactersEaten = new List<Character>();
        public int round = 0;
        public DateTime startTime;
        public int StartNumberFighter = 0;
        public System.Timers.Timer timer1 = new System.Timers.Timer();
        public bool estFini = false;

        public FightManager(List<Character> charactersList, int round)
        {
            this.charactersList = charactersList;
            this.round = round;
            foreach (Character character in charactersList)
            {
                character.SetFightManager(this);
            }
        }

        public void StartCombat()
        {
            startTime = DateTime.Now;
            round = 0;
            StartNumberFighter = charactersList.Count;
            //Thread[] threads = new Thread[StartNumberFighter];
            //faire en sorte que les personnages ne soient pas blessé avant le début du combat
            for (int i = 0; i < charactersList.Count; i++)
            {
                Console.WriteLine("Index : " + i.ToString());
                /*charactersList[i].Reset();
                threads[i] = new Thread(() =>Figth(charactersList[i]));
                threads[i].Start();*/
                Console.WriteLine("A new challenger is coming : " + charactersList[i].GetName());
                //ThreadPool.QueueUserWorkItem(new WaitCallback(state => Figth(charactersList[i])));
                ThreadPool.QueueUserWorkItem(new WaitCallback(state => FigthPower(charactersList[i])));
                Thread.Sleep(5);                
            }
            MyLog("----- Debut du combat -----");
            //a commenter pour enchainer les rounds à la main
            //faire des rounds tant qu'il y a plus d'un combattant vivant
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(poisonRoundEvent);
            timer1.Interval = 5000;
            timer1.Start();
            while(estFini == false){}
            timer1.Stop();
        }

        public void Figth(Character character)
        {
            Console.WriteLine(character.GetName() + " combat !");
            while (character.GetCurrentLife() > 0)
            {
                int delay = (int)(1000 / character.GetAttackSpeed()) - character.RollDice() + character.GetDelay();
                Thread.Sleep(delay);
                Console.WriteLine(character.GetName() + " attaque !");
                character.AttackGenerale(charactersList, charactersEaten);
            }
        }

        public void FigthPower(Character character)
        {
            Console.WriteLine(character.GetName() + " va utiliser un pouvoir !");
            while (character.GetCurrentLife() > 0 && estFini == false)
            {
                int delay = (int)(1000 / character.GetPowerSpeed()) - character.RollDice() + character.GetDelay();
                Thread.Sleep(delay);
                if(character.GetCurrentLife() > 0 && estFini == false)
                {
                    Console.WriteLine(character.GetName() + " utilise son pouvoir !");
                    character.Power(charactersList, charactersEaten);
                }
            }
        }

        public void poisonRoundEvent(object sender, System.Timers.ElapsedEventArgs e)
        {            
            if (charactersList.Count > 1 && GetNbVivants() > 1)
            {
                round++;
                MyLog("---------- Round " + round + " ----------");

                for (int i = 0; i < charactersList.Count; i++)
                {
                    if (charactersList[i].GetStackPoison() > 0)
                    {
                        charactersList[i].SetCurrentLife(charactersList[i].GetCurrentLife() - charactersList[i].GetStackPoison());
                    }
                }
                MyLog("---------- Fin du round ----------");
            }
            else
            {
                foreach(Character character in charactersList)
                {
                    if (character.GetCurrentLife() > 0)
                    {
                        MyLog(character.GetName() + " remporte le battle royale");
                    }
                }                
                MyLog("---------- Fin du combat ----------");
                estFini = true;
            }
        }

        public int GetNbVivants()
        {
            int cpt = charactersList.Count;
            for (int i = 0; i < charactersList.Count; i++)
            {
                if(charactersList[i].GetCurrentLife() <= 0)
                {
                    cpt--;
                }
            }
            return cpt;
        }

        public void MyLog(string text)
        {
            Console.WriteLine(text);
        }
    }
}
