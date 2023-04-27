using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
    public static Weapon initial_sword = new Weapon("Стартовый меч", 8, 4);

    public string name;
    public int HP;
    public int level = 0;
    public static Weapon equipped_weapon = initial_sword;

    public int base_attack = 4;
    public int base_defense = 2;

    public Player(string aName, int aHP)
    {
        name = aName;
        HP = aHP;
    }

    public int Attack()
    {
        return (base_attack + equipped_weapon.attack);
    }

    public int Defense()
    {
        return (base_defense + equipped_weapon.defense);
    }

    public void Stats()
    {
        Console.WriteLine("\n{0}:", name);
        Console.WriteLine("Здоровье: {0}", HP);
        Console.WriteLine("Урон: {0} ({1})", Attack(), base_attack);
        Console.WriteLine("Защита: {0} ({1})", Defense(), base_defense);
        Console.WriteLine("Экипированное оружие: {0}; Урон: {1}; Защита: {2}", equipped_weapon.name, equipped_weapon.attack, equipped_weapon.defense);
    }

    public static bool QuestionPrompt()
    {
        string[] yes_list = { "да", "конечно", "конечно да", "почему нет", "почему бы и нет", "Да", "Конечно", "Конечно да", "Почему нет", "Почему бы и нет" };

        Console.Write("--> ");
        string input = Console.ReadLine();
        string iinput = input.ToLower();
        foreach (string value in yes_list)
        {
            if (value.Equals(iinput))
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }

    public static void ChangeWeaponByName(string new_weapon_name)
    {
        Weapon weapon_to_change = new Weapon("Проверка оружия", 0, 0);

        bool WeaponExists()
        {
            foreach (Weapon weapon in Weapon.weapon_list)
            {
                if (weapon.name.ToLower() == new_weapon_name.ToLower())
                {
                    weapon_to_change = weapon;
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        if (WeaponExists() == true)
        {
            equipped_weapon = weapon_to_change;
        }
    }

    public static void ChangeWeapon(Weapon new_weapon)
    {
        equipped_weapon = new_weapon;
    }

    public static void EquipWeapon(string weapon_name)
    {
        Weapon weapon_to_equip = new Weapon("Проверка оружия", 0, 0);

        bool WeaponExists()
        {
            foreach (Weapon weapon in Weapon.weapon_list)
            {
                if (weapon.name.ToLower() == weapon_name.ToLower())
                {
                    weapon_to_equip = weapon;
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        if (WeaponExists())
        {
            Console.WriteLine("\nСравнение характеристик обоих видов оружия:");
            Weapon.CompareWeaponStats(weapon_to_equip, Player.equipped_weapon);
            Console.WriteLine("Вы уверены что хотите экипировать это оружие?");
            if (QuestionPrompt() == true)
            {
                Console.WriteLine("Вы экипировали оружие!");
                ChangeWeapon(weapon_to_equip);
            }
            else
            {
                Console.WriteLine("Вы продолжите с тем же оружием, новое было выброшено.");
            }
        }
        else
        {
            Console.WriteLine("Оружие, которое вы хотите экипировать, не существует!");
        }
    }

    public static void CheckEquippedWeapon()
    {
        Console.WriteLine("Экипированное оружие:");
        Weapon.CheckWeaponStats(equipped_weapon);
    }
}
}
