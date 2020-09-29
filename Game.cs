using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Item _Longsword;
        private Item[] _shopInventory;
        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }
            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            
        }

        //Displays three options and a query for the player to choose
        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            input = ' ';
            //Prints the query
            Console.WriteLine(query);
            //Prints out the options
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);

            //Checks the player input incase there is a miss input
            while(input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        void Traverse(int roomNum)
        {
            switch(roomNum)
            {
                case 1:
                    {
                        Console.WriteLine("A lone Wolf leaps in front of you and starts to growl.");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("A Goblin bumps into you and quickly raises its spear ready to stab you");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("As you approach the shop a theif stops you with a knife telling you to give him your hard earned gold for your life");
                        break;
                    }
            }
        }
        //Repeated until the game ends
        public void Update()
        {
            Traverse(1);
            Traverse(2);
            Traverse(3);
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
