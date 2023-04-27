using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Battle
    {
        public static int crit_chance = 16;
        public static int attack_timer = 1500;

        public static bool isCrit()
        {
            Random rnd = new Random();
            int crit = rnd.Next(1, crit_chance);

            if (crit == 1)
            {
                return true;
            }
            return false;
        }

        public static bool isPlayerDead(Player player) { return player.HP <= 0; }        

        public static bool isEnemyDead(Enemy enemy) { return enemy.HP <= 0; }        

        public static void PlayerAttack(Player player, Enemy enemy)
        {
            bool was_crit = false;

            int DamageInflicted()
            {
                int damage = player.Attack() - enemy.Defense();
                if (damage <= 1)
                {
                    damage = 1;
                }
                if (isCrit() == true)
                {
                    was_crit = true;
                    damage += damage;
                }
                return damage;
            }

            enemy.HP -= DamageInflicted();

            if (was_crit == true)
            {
                Console.WriteLine("Критический урон! Ты нанёс {0} урона.", DamageInflicted());
            }
            else
            {
                Console.WriteLine("Ты нанёс {0} урона.", DamageInflicted());
            }
            Console.WriteLine("У противника осталось {0} здоровья.", enemy.HP);
        }

        public static void EnemyAttack(Player player, Enemy enemy)
        {
            bool was_crit = false;

            int DamageInflicted()
            {
                int damage = enemy.Attack() - player.Defense();
                if (damage <= 0)
                {
                    damage = 0;
                }
                if (isCrit() == true)
                {
                    was_crit = true;
                    damage += damage;
                }
                return damage;
            }

            player.HP -= DamageInflicted();

            if (was_crit == true)
            {
                Console.WriteLine("Критический урон! Противник нанёс {0} урона.", DamageInflicted());
            }
            else
            {
                Console.WriteLine("Противник нанёс {0} урона.", DamageInflicted());
            }
            Console.WriteLine("У тебя осталось {0} здоровья.", player.HP);
        }

        public static void MakeBattle(Player player, Enemy enemy)
        {
            Console.WriteLine("Ты, {0}, сражаешься с {1} {2}.", player.name, enemy.specie, enemy.name);
            enemy.Stats();
            Console.WriteLine("Нажмите Enter чтобы начать сражение.");
            Console.ReadLine();
            Random rnd = new Random();
            int move = rnd.Next(1, 3);
            if (move == 1)
            {
                Console.WriteLine("Ты атакуешь первым!");
                while (true)
                {
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    PlayerAttack(player, enemy);
                    if (isEnemyDead(enemy))
                    {
                        Console.WriteLine("Ты убил {0}!", enemy.specie);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    EnemyAttack(player, enemy);
                    if (isPlayerDead(player))
                    {
                        Console.WriteLine("Герой пал! Игра окончена!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Противник атакует первым!");
                while (true)
                {
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    EnemyAttack(player, enemy);
                    if (isPlayerDead(player))
                    {
                        Console.WriteLine("Герой пал! Игра окончена!");
                        break;
                    }

                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    PlayerAttack(player, enemy);
                    if (isEnemyDead(enemy))
                    {
                        Console.WriteLine("Ты убил {0}!", enemy.specie);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}
