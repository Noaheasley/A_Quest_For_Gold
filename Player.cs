using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private float _gold;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        //default player stats
        public Player() : base()
        {
            _inventory = new Item[3];
            _gold = 0;
            _hands._name = "fists";
            _hands._statBoost = 0;
        }

        //player constructor
        public Player(string nameVal, float healthVal, float damageVal, int inventorySize, float coinVal)
            : base( nameVal, healthVal, damageVal, coinVal)
        {
            _inventory = new Item[inventorySize];
            _hands._name = "fists";
            _hands._statBoost = 0;
            coinVal = _gold;
        }
        //function for the player to allow them to unequip an item
        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public float GetTrueDamage()
        {
            float totalDamage = _damage + _currentWeapon._statBoost;
            return totalDamage;
        }
        //function used to hold items in the player's inventory
        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }
        //adds an item to the inventory index
        public void AddItemToInv(Item item, int index)
        {
            _inventory[index] = item;
        }
        //allows the player to equip an item from their inventory
        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }
        //allows the player to use their gold to purchase items in the shop
        public bool Buy(Item item, int inventoryIndex)
        {
            if(_gold >= item._cost)
            {
                _gold -= item._cost;
                _inventory[inventoryIndex] = item;
                return true;
            }
            //If the player can't afford the item it will return false
            return false;
        }

        //function that allows the player to gain gold once they slay an enemy that has gold in their inventory
        public void GoldGain(Player player, Enemy enemy)
        { 
            player._gold += enemy._gold;
        }
        //returns gold
        public float GetGold()
        {
            return _gold;
        }
        //function for the player to get a stat boost depending on what weapon they are using
        public override float Attack(Character enemy)
        {
            float totalDamage = _damage + _currentWeapon._statBoost;
            return enemy.TakeDamage(totalDamage);
        }
        //return inventory
        public Item[] GetInv()
        {
            return _inventory;
        }
        
      
    }
}
