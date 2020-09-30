using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private int _gold;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Player() : base()
        {
            _inventory = new Item[3];

            _hands._name = "fists";
            _hands._statBoost = 0;
        }

        public Player(string nameVal, float healthVal, float damageVal, int inventorySize)
            : base(healthVal, nameVal, damageVal)
        {
            _inventory = new Item[inventorySize];
            _hands._name = "fists";
            _hands._statBoost = 0;
        }

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }
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
    }
}
