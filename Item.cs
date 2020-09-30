using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HelloWorld
{
    class Item
    {
        public string _name;
        public int _statBoost;
        private Item _longSword;
        private Item _claymore;
        private Item _bow;
        private Item _crossBow;
        private Item _enchantedSword;
        private Item _zweihandler;

        public Item()
        {
            _statBoost = 25;
        }

        public Item(string nameVal, int statBoost)
        {
            _name = nameVal;
        }

        //intializes all weapons that the player can buy and use
        public void IntialItems()
        {
            _longSword._name = "Longsword";
            _longSword._statBoost = 15;
            _claymore._name = "Claymore";
            _claymore._statBoost = 25;
            _bow._name = "Bow";
            _bow._statBoost = 20;
            _crossBow._name = "Crossbow";
            _crossBow._statBoost = 30;
            _enchantedSword._name = "Enchanted Sword";
            _enchantedSword._statBoost = 25;
            _zweihandler._name = "Zweihandler";
            _zweihandler._statBoost = 40;
        }

        public void GetInput(out char input, string option1, string option2, string query)
        {
            input = ' ';

            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        public int GetStatBoost()
        {
            return _statBoost;
        }
    }
}
