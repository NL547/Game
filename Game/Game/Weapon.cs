using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Weapon
    {
        public string name;
        public int attack;
        public int defense;

        public static List<Weapon> weapon_list = new List<Weapon>();

        public Weapon(string aName, int aAttack, int aDefense)
        {
            name = aName;
            attack = aAttack;
            defense = aDefense;
        }

        public static void CreateWeapon(string name, int attack, int defense)
        {
            Weapon weapon = new Weapon(name, attack, defense);
            weapon_list.Add(weapon);
        }

        public static void CheckAllAvailableWeaponsStats()
        {
            Console.WriteLine("\nВсё оружие в игре:");
            foreach (Weapon weapon in Weapon.weapon_list)
            {
                Console.Write("Название: {0}\nУрон: {1}\nЗащита: {2}\n", weapon.name, weapon.attack, weapon.defense);
                Console.WriteLine("---------------------------");
            }
        }

        public static void CheckWeaponStats(Weapon weapon)
        {
            Console.Write("\nНазвание оружия: {0}\nУрон: {1}\nЗащита: {2}\n", weapon.name, weapon.attack, weapon.defense);
        }

        public static void CompareWeaponStats(Weapon other_weapon, Weapon your_weapon)
        {
            if (your_weapon == Player.equipped_weapon)
            {
                Console.Write("Название оружия: {0} | Название экипированного оружия: {1}\nУрон: {2} | Урон экипированного оружия: {3} \nЗащита: {4} |" +
                    " Защита экипированного оружия: {5}\n", other_weapon.name, your_weapon.name, other_weapon.attack, your_weapon.attack, other_weapon.defense, your_weapon.defense);
            }
            else
            {
                Console.Write("Название другого оружия: {0} | Название твоего оружия: {1}\nУрон другого оружия: {2} | Урон твоего оружия: {3} \nЗащита другого оружия: {4} " +
                    "| Защита твоего оружия: {5}\n", other_weapon.name, your_weapon.name, other_weapon.attack, your_weapon.attack, other_weapon.defense, your_weapon.defense);
            }
        }
    }
}
