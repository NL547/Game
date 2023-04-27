using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy
    {
        public string specie;
        public string name;
        public int base_attack = 2;
        public int base_defense = 1;
        public int HP;

        public int enemy_defense;
        public int enemy_attack;

        public Enemy(string aSpecie, string aName, int aHP, int aAttack, int aDefense)
        {
            specie = aSpecie;
            name = aName;
            HP = aHP;
            enemy_attack = aAttack;
            enemy_defense = aDefense;
        }

        public int Attack()
        {
            return (base_attack + enemy_attack);
        }

        public int Defense()
        {
            return (base_defense + enemy_defense);
        }

        public void Stats()
        {
            Console.WriteLine("{0} {1}:", specie, name);
            Console.WriteLine("Здоровье: {0}", HP);
            Console.WriteLine("Урон: {0}", Attack());
            Console.WriteLine("Защита: {0}", Defense());
        }
    }
}
