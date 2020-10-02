using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy : Character
    {
        private Item _currentWeapon;
        private Item[] _inventory;
        private float _gold;
        //enemy base
        public Enemy() : base()
        {
            _inventory = new Item[1];
        }
        //constructor of the enemy
        public Enemy( string nameVal, float healthVal, int damageVal, int inventorySize, float coinVal)
            : base( nameVal, healthVal, damageVal, coinVal)
        {
            _inventory = new Item[inventorySize];
        }
        //allows the enemy to attack with the stat boost of it's weapon
        public float EnemyAttack(Character enemy)
        {
            float totalDamage = _damage + _currentWeapon._statBoost;
            return enemy.TakeDamage(totalDamage);
        }
        //returns the enemy's inventory
        public Item[] GetEnemyInv()
        {
            return _inventory;
        }
        //function for enemies to equip weapons
        public void EnemyEquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }
        //adds items to enemy inventory
        public void AddItemToInv(Item item, int index)
        {
            _inventory[index] = item;
        }
        //used to contain an enemy weapon
        public bool Contains(int itemIndex)
        {
            if (itemIndex >= 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }
    }
}
