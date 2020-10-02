using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;
        //initalizes the shop
        public Shop()
        {
            _gold = 100;
            _inventory = new Item[3];
        }
        //shop constructor
        public Shop(Item[] items)
        {
            _gold = 100;
            _inventory = items;
        }
        //sell function to give the player the item that they bought
        public bool Sell(Player player, int itemIndex, int playerIndex)
        {
            Item itemToBuy = _inventory[itemIndex];
            //if the player buys the item it will take the item from the shop inv and give it to the player's inv
            if(player.Buy(_inventory[itemIndex], playerIndex))
            {
                _gold += itemToBuy._cost;
                return true;
            }
            //returns false if player doesn't buy anything
            return false;
        }
    }
}
