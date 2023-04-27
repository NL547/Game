using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{  
    class Program
    {
        static void Main()
        {
            Player player = new Player("", 30);

            bool PlayerDied()
            {
                if (Battle.isPlayerDead(player) == true)
                {
                    return true;
                }
                return false;
            }

            Weapon.CreateWeapon("Ржавый меч", 7, 3);
            Weapon.CreateWeapon("Железный меч", 10, 5);
            Weapon.CreateWeapon("Золотой меч", 14, 7);
            Weapon.CreateWeapon("Легендарный зубчатый меч", 18, 9);

            Player.ChangeWeaponByName("Ржавый меч");

            // the enemies
            Enemy[] bandits =
            {
            new Enemy("Бандит", "Боб", 9, 6, 2),
            new Enemy("Главарь бандитов", "Джо", 10, 7, 2)
        };
            Enemy[] knights =
            {
            new Enemy("Рыцарь", "Саймон", 12, 8, 4),
            new Enemy("Рыцарь", "Джон", 12, 9, 3),
            new Enemy("Капитан рыцарей", "Байрон", 14, 10, 4),
        };
            Enemy[] dragons =
            {
            new Enemy("Дракон", "Лезвиекрыл", 17, 11, 7),
            new Enemy("Драконий вожак", "Терзатель", 20, 13, 10),
        };

            Console.WriteLine("Как к тебе обращаться, странник?");
            string response = Console.ReadLine();
            player.name = response;

            player.Stats();
            Console.WriteLine("\nНажми любую клавишу, чтобы начать игру.");
            Console.ReadLine();
            Console.Clear();

            while (true)
            {
                Story.S_1_Bandits(player);
                foreach (Enemy enemy in bandits)
                {
                    Battle.MakeBattle(player, enemy);
                    if (Battle.isPlayerDead(player) == true)
                    {
                        break;
                    }
                }

                if (PlayerDied())
                {
                    break;
                }

                Events.SpawnWeapon("Железный меч");
                if (player.HP <= 16)
                {
                    Events.LootHealHerbs(player);
                }
                else
                {
                    Events.LootPoisonHerbs(player);
                }
                player.Stats();
                Console.WriteLine("\nНажми Enter чтобы продолжить.");
                Console.ReadLine();

                Console.Clear();

                Story.S_2_Knights(player);
                foreach (Enemy enemy in knights)
                {
                    Battle.MakeBattle(player, enemy);
                    if (Battle.isPlayerDead(player) == true)
                    {
                        break;
                    }
                }

                if (PlayerDied())
                {
                    break;
                }

                Events.SpawnWeapon("Золотой меч");                
                if (player.HP >= 15)
                {
                    Events.LootBadMedicine(player);
                    Events.Notes(player);
                }
                else if (player.HP <= 10)
                {
                    Events.StrangeGlowingRock(player);
                    Events.Notes(player);
                }
                else
                {
                    Events.LootHealMedicine(player);
                    Events.Notes(player);
                }
                player.Stats();
                Events.LegendarySwordRoom("Легендарный зубчатый меч");
                player.Stats();
                Console.WriteLine("\nНажми Enter чтобы продолжить.");
                Console.ReadLine();

                Console.Clear();

                Story.S_3_Dragons(player);
                foreach (Enemy enemy in dragons)
                {
                    Battle.MakeBattle(player, enemy);
                    if (Battle.isPlayerDead(player) == true)
                    {
                        break;
                    }
                }

                if (PlayerDied())
                {
                    break;
                }

                Console.Clear();

                Story.S_End(player);

                break;
            }

            Console.ReadLine();
        }
    }
}
