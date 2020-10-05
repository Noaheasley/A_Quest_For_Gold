using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        private string _name;
        protected float _damage;
        
        public float _gold;

        //character defaults
        public Character()
        {
            _name = "Hero";
            _health = 100;
            
            _damage = 10;
            _gold = 10;
        }

        
        //Character constructor
        public Character(string nameVal, float healthVal, float damageVal, float goldVal)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
            _gold = goldVal;
        }

        public float GetDamage()
        {
            return _damage;
        }
        
        //allows characters to attack each other
        public virtual float Attack(Character enemy)
        {
            return enemy.TakeDamage(_damage);
        }
        //allows enemy or player to take damage from the attack function
        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal ;
            if(_health < 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        //saves character data
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
            writer.WriteLine(_gold);
        }
        //loads data saved by the player
        public virtual bool Load(StreamReader reader)
        {
            if(File.Exists("SavedData.txt") == false)
            {
                return false;
            }
            string name = reader.ReadLine();
            float health = 0;
            float damage = 0;

            if(float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if(float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }

            _name = name;
            _damage = damage;
            _health = health;
            return true;
        }
        //returns name from Character class
        public string GetName()
        {
            return _name;
        }
        //checks if character is alive
        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public bool GetIsAlive(bool Alive = false)
        {
            return _health <= 0;
        }
        //prints the stats of the enemy
        public void PrintStats()
        {
            Console.WriteLine("[" + _name + "]");
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Gold: " + _gold);
        }
        //prints the stats of the player
        public void PrintPlayerStats(Player player)
        {
            Console.WriteLine("[" + player._name + "]");
            Console.WriteLine("Health: " + player._health);
            Console.WriteLine("Damage: " + player.GetTrueDamage());
            Console.WriteLine("Gold: " + player.GetGold());
        }
    }
}
