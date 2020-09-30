using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Item[] _shopInventory;
        private Character _wolf;
        private Character _goblin;
        private Character _theif;
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
            OpenMainMenu();
            InitalizeCharacters();
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
        public void GetInput(out char input, string option1, string option2, string query)
        {
            input = ' ';
            //Prints the query
            Console.WriteLine(query);
            //Prints out the options
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);

            //Checks the player input incase there is a miss input
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        public void Save()
        {
            //creates a new stream writer
            StreamWriter writer = new StreamWriter("SaveData.txt");
            //call save for the player
            _player1.Save(writer);
            //closes stream
            writer.Close();
        }

        public void Load()
        {
            StreamReader reader = new StreamReader("SavedData.txt");
            _player1.Load(reader);
            reader.Close();
        }
        public void OpenMainMenu()
        {
            char input;
            GetInput(out input, "create character", "load character", "what doyou want to do");
            if (input == '2')
            {
                _player1 = new Player();
                Load();
                return;
            }
            CreateCharacter(ref _player1);
        }
        public void CreateCharacter(ref Player player)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            player = new Player(name, 100, 10, 5);
        }

        //starts a battle for each floor
        public bool startBattle(Player player, Character enemy)
        {
            //while both characters are alive the battle continues looping
            while(player.GetIsAlive() && enemy.GetIsAlive())
            {
                //prints the stats of the player and enemy
                player.PrintStats();
                enemy.PrintStats();
                //players choice of attack, and swapping weapons
                char input;
                GetInput(out input, "Attack", "Swap Weapon", player.GetName() + "'s turn");
                if(input=='1')
                {
                    //the player attacks the enemy
                    Console.Clear();
                    float damageTaken = player.Attack(enemy);
                    Console.WriteLine(player.GetName() + " did " + damageTaken + " damage.");
                }
                else if(input == '2')
                {
                    //the player switches weapons
                    Console.Clear();
                    SwitchWeapons(player);
                }
                //checks if the enemy died
                if(enemy.GetIsAlive(false))
                {
                    Console.WriteLine(enemy.GetName() + " has been killed.");
                    Console.WriteLine("Press any button to continue");
                    Console.WriteLine(">");
                    Console.ReadKey();
                    
                    return _gameOver = false;
                }
                //prints the stats of the player and enemy
                Console.WriteLine("[" + player.GetName() + "'s stats");
                player.PrintStats();
                Console.WriteLine("[" + enemy.GetName() + "'s stats");
                enemy.PrintStats();
                Console.WriteLine("[Press any button to continue]");
                Console.ReadKey();
                Console.Clear();

                //enemy attacks the player
                float PlayerDamageTaken = enemy.Attack(player);
                Console.WriteLine(enemy.GetName() + " did " + PlayerDamageTaken + " damage.");

                //checks if the player dies
                if (player.GetIsAlive(false))
                {
                    Console.WriteLine("You Died");
                    return _gameOver = true;
                }

                //prints the stats of the player and enemy
                Console.WriteLine("[" + player.GetName() + "'s stats");
                player.PrintStats();
                Console.WriteLine("[" + enemy.GetName() + "'s stats");
                enemy.PrintStats();
                Console.WriteLine("[Press any button to continue]");
                Console.ReadKey();
                Console.Clear();
            }
            //returns whether or not the player is alive
            return _player1.GetIsAlive();
        }

        //Initalizes the enemy characters
        public void InitalizeCharacters()
        {
            _wolf = new Character("wolf", 20, 5);
            _goblin = new Character("Goblin", 20, 10);
            _theif = new Character("Theif", 25, 10);
        }

        //traverses through the rooms
        void Traverse(int roomNum)
        {
            switch(roomNum)
            {
                case 1:
                    {
                        Console.WriteLine("A lone Wolf leaps in front of you and starts to growl.");
                        if (startBattle(_player1, _wolf))
                        {
                            Traverse(roomNum++);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("A Goblin bumps into you and quickly raises its spear ready to stab you");
                        if (startBattle(_player1, _goblin))
                        {
                            Traverse(roomNum++);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("As you approach the shop a theif stops you with a knife telling you to give him your hard earned gold for your life");
                        if (startBattle(_player1, _theif))
                        {
                            Traverse(roomNum++);
                        }
                        break;
                    }
            }
            
            _gameOver = true;
        }

        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInv();

            char input = ' ';
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i]._name + " \n Damage: " + inventory[i]._statBoost);
            }
            Console.WriteLine(">");
            input = Console.ReadKey().KeyChar;
            switch(input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("you equipped " + inventory[0]._name);
                        Console.WriteLine("Base damage increased by: " + inventory[0]._statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("you equipped " + inventory[1]._name);
                        Console.WriteLine("Base damage increased by: " + inventory[1]._statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("you equipped " + inventory[2]._name);
                        Console.WriteLine("Base damage increased by: " + inventory[2]._statBoost);
                        break;
                    }
                default:
                    {
                        player.UnequipItem();
                        Console.WriteLine("You fumbled around too quickly causing you to drop your weapon");
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
