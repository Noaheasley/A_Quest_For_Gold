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
            _gold = 10;
            _inventory = new Item[3];
            _hands._name = "fists";
            _hands._statBoost = 0;
        }

        public Player(string nameVal, float healthVal, float damageVal, int inventorySize, float coinVal)
            : base( nameVal, healthVal, damageVal, coinVal)
        {
            _inventory = new Item[inventorySize];
            _hands._name = "fists";
            _hands._statBoost = 0;
            coinVal = _gold;
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

        public bool Buy(Item item, int inventoryIndex)
        {
            if(_gold >= item._cost)
            {
                _gold -= item._cost;
                _inventory[inventoryIndex] = item;
                return true;
            }
            return false;
        }

        public int GetGold()
        {
            return _gold;
        }
        public override float Attack(Character enemy)
        {
            float totalDamage = _damage + _currentWeapon._statBoost;
            return enemy.TakeDamage(totalDamage);
        }
        
        public Item[] GetInv()
        {
            return _inventory;
        }
        public int GetStat()
        {
            return _currentWeapon._statBoost;
        }
      
    }
}
