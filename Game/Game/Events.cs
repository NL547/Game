using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Events
    {        
        public static void SpawnWeapon(string weapon_name)
        {
            Console.WriteLine("\nПосле этого боя ты украл оружие у врага: {0}", weapon_name);
            Player.EquipWeapon(weapon_name);
        }

        public static void LootPoisonHerbs(Player player)
        {
            Console.WriteLine("После победы над бандитами, вы продолжили свой путь. По пути вы наткнулись на небольшое травянистое растение.\n1. Использовать траву для лечения\n2. Пройти мимо");
            int action = Int32.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    player.HP -= 3;
                    Console.WriteLine("Применив траву ты почувствовал сильное недомогание. Через некоторое время тебя стошнило. \nЗдоровье снижено на 3 ед.");
                    break;
                case 2:
                    Console.WriteLine("Ты не стал использовать траву и пошёл дальше.");
                    break;
                default:
                    Console.WriteLine("...");
                    break;
            }           
        }

        public static void LootHealHerbs(Player player)
        {
            Console.WriteLine("После нелёгкой победы над бандитами, ты продолжил свой путь. По пути ты наткнулся на раскидистое травянистое растение.\n1. Использовать траву для лечения\n2. Пройти мимо");
            int action = Int32.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    player.HP += 5;
                    Console.WriteLine("Сок травы благоприятно повлиял на твоё состояние. \nВосстановленно 5 ед. здоровья.");
                    break;
                case 2:
                    Console.WriteLine("Ты не стал использовать траву и пошёл дальше.");
                    break;
                default:
                    Console.WriteLine("...");
                    break;
            }            
        }

        public static void LootHealMedicine(Player player)
        {
            Console.WriteLine("Рыцари были повержены. Ты продолжил свой путь. Пройдя дальше, ты обнаружил ящик с неизвестным лекарством.\n1. Использовать лекарство для лечения\n2. Пройти мимо");
            int action = Int32.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    player.HP += 5;
                    Console.WriteLine("После принятия лекарства ты почувствовал себя гораздо лучше. \nВосстановленно 5 ед. здоровья.");
                    break;
                case 2:
                    Console.WriteLine("Ты не стал использовать лекарство и пошёл дальше.");
                    break;
                default:
                    Console.WriteLine("...");
                    break;
            }
        }

        public static void LootBadMedicine(Player player)
        {
            Console.WriteLine("Рыцари были повержены. Ты продолжил свой путь. Пройдя дальше, ты обнаружил бочонок с неизвестным лекарством.\n1. Использовать лекарство для лечения\n2. Пройти мимо");
            int action = Int32.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    player.HP -= 4;
                    Console.WriteLine("Кто бы мог подумать, что неизвестное лекарство окажется лошадиным слабительным...\n" +
                        " В течении всего следующего дня ты проклинал людей, изготовивших данный препарат. \nЗдоровье снижено на 4 ед.");
                    break;
                case 2:
                    Console.WriteLine("Ты не стал использовать лекарство и пошёл дальше.");
                    break;
                default:
                    Console.WriteLine("...");
                    break;
            }            
        }

        public static void StrangeGlowingRock(Player player)
        {
            Console.WriteLine("После изнурительного сражения рыцари были повержены. Их мотивы пребывания в пещере так и остались вам неизвестны." +
                " \nВ одной из комнат пещеры ты заметил небольшой выгравированный пьедестал со светящимся камнем на нём.\n1. Прикоснуться к камню\n2. Не прикасаться");
            int action = Int32.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    player.HP += 15;
                    Console.WriteLine("Приложив руку к необычному камню, ты резко почувствовал прилив сил. Некоторые твои раны затянулись. \nВосстановленно 15 ед. здоровья.");
                    break;
                case 2:
                    Console.WriteLine("Ты решил не трогать необычный камень.");
                    break;
                default:
                    Console.WriteLine("...");
                    break;
            }            
        }

        public static void Notes(Player player)
        {
            Console.WriteLine("Пройдя дальше через очень узкий участок пещеры ты обнаружил стол с множеством записей. Все они были написаны на неизвестном языке. " +
                "\nЛишь одна была частично переведена:" +
                "\nОтчёт №1. " +
                "\nДень 1. Драконы взяты под охрану." +
                "\nДень 3. ̸̱̀̓͛̃̋̒̂숨4͌" +
                "\nДень 6. Два воина пришли с целью убить драконов во время спячки. Они незамедлительно были устранены охраной." +
                "\nДень 8. Ещё один воин пришёл расправиться с драконами. Он также незамедлительно был устранён." +

                "\nДень 13. С̴̞̣͓̚в̷̥̗̟̥͓̒́̄͋е̵̖̼͐д̷̩͉̰̪̃̏̿͝е̷̲̺̞̎̉̿̎͠н̸͚̽̅́̄̓и̵̗̲̫̌̈́я̶̮͂̿͊̍ ̸̡͖̾͝с̶͙̜̭̪̕к̴̘̅̆̀͑͌ͅр̴̗̱͛̾̓̈̊ы̷͉̀̔т̷̨̼̎͊͂ы̷̖̝͇̉̔̚" +

                "\nДень 37. К логову пришло небольшое войско приблизительно из 20 человек. Пришлось прибегнуть к использованию ловушки с шипами." +
                "\nДень 44. 겨̷̎2̛͖̝͙̥͖̤̈́̉͂̈̎̄̆̓̓̌̒̾̑͂7̬͇" +
                "\nОтчёт составлен по приказу Марка Отиса (17 августа 1339г.)");
            Console.WriteLine($"{player.name}: Марк? Так значит это он всё это время за этим стоял... Видимо рыцарей поставил, чтобы они меня прикончили. " +
                $"\nНесдобровать ему когда я вернусь!");
        }        

        public static void LegendarySwordRoom(string weapon_name)
        {
            Console.WriteLine("Пройдя дальше, ты обнаружил массивную железную дверь. Рядом с ней располагались 10 каменных кнопок с цифрами на них." +
                "\nПохоже на кодовый замок. Можно попытаться его подобрать...");
            int number = Int32.Parse(Console.ReadLine());
            if (number == 427)
            {
                Console.WriteLine("После того как вы нажали на 3 цифры, раздался щелчок и дверь открылась. За ней была комната, в которой на пъедестале лежал боевой меч.");
                Player.EquipWeapon(weapon_name);
                Console.WriteLine("\nС таким мечом драконов будет одолеть гораздо проще.");
            }
            else
            {
                Console.WriteLine("После того как вы нажали на 3 цифры, каменные кнопки задвинулись внуть стены, что больше не позволило подбирать комбинации." +
                    "\nВидимо это была не та комбинация...");
            }
        }
    }
}