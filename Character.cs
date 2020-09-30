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
        private float _gold;

        public Character()
        {
            _health = 100;
            _name = "Hero";
            _damage = 10;
            _gold = 10;
        }

        public void GoldGain(Player player, Character enemy)
        {
            Console.WriteLine(player._name + " has gained" + enemy._gold + " gold!");
            player._gold += enemy._gold;
        }

        public Character(string nameVal, float healthVal, float damageVal, float goldVal)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
            _gold = goldVal;
        }

        public virtual float Attack(Character enemy)
        {
            return enemy.TakeDamage(_damage);
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal ;
            if(_health < 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
        }

        public virtual bool Load(StreamReader reader)
        {
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

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public bool GetIsAlive(bool Alive = false)
        {
            return _health <= 0;
        }

        public void PrintStats()
        {
            Console.WriteLine("[" + _name + "]");
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Gold: " + _gold);
        }
        public void PrintPlayerStats(Player player)
        {
            Console.WriteLine("[" + _name + "]");
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Gold: " + _gold);
        }
    }
}
