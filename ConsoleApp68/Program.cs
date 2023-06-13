namespace ConsoleApp68
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bossHealth = 1000;
            int bossDamage = 15;
            int heroHealth = 100;
            int maximumHeroHealth = 100;
            int heroSpell1Damage = 50;
            int maximumHeroSpell1Damage = 50;
            int degradationHeroSpell1Damage = 10;
            int recoveryHeroSpell1Damage = 10;
            int heroSpell2Heal = 50;
            int hitHeroSpell3 = 20;
            int heroSpell4Damage = 100;
            bool isSpell4Ready = false;
            string userInput;

            Console.WriteLine("Упокой душу павшего Короля, юный Воин, и только тогда ты обретёшь свободу.");

            while (bossHealth > 0 && heroHealth > 0)
            {
                const string CommandUseSpell1 = "1";
                const string CommandUseSpell2 = "2";
                const string CommandUseSpell3 = "3";
                const string CommandUseSpell4 = "4";

                Console.WriteLine("юный Воин: Здоровье - " + heroHealth);
                Console.WriteLine("Павший Король: Здоровье - " + bossHealth + " Урон - " + bossDamage);
                Console.WriteLine("Способности юного Воина:");
                Console.WriteLine(CommandUseSpell1 + " - бросить острый бумеранг, наносящий " + heroSpell1Damage + " урона. (После каждого " +
                    "использования, теряет " + degradationHeroSpell1Damage + " урона. Восстанавливается при удачном использовании " + CommandUseSpell3 +
                     "-ей и " + CommandUseSpell4 + "-ой способности.");
                Console.WriteLine(CommandUseSpell2 + " - выпить зелье, восстанавливающее здоровье на " + heroSpell2Heal + " единиц и увернуться от атаки Павшего Короля.");
                Console.WriteLine(CommandUseSpell3 + " - приготовится к атаке мечом, жертвуя здоровьем в " + hitHeroSpell3 + " единиц.");
                Console.WriteLine(CommandUseSpell4 + " - атака мечом, наносящая " + heroSpell4Damage + " урона. (Только после подготовки к атаке!)");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandUseSpell1:
                        bossHealth -= heroSpell1Damage;
                        heroHealth -= bossDamage;
                        Console.WriteLine("Вы нанесли " + heroSpell1Damage + " урона.");
                        heroSpell1Damage -= degradationHeroSpell1Damage;
                        break;

                    case CommandUseSpell2:
                        heroHealth += heroSpell2Heal;
                        
                        if (heroHealth > maximumHeroHealth)
                        {
                            heroHealth = maximumHeroHealth;
                        }
                        break;

                    case CommandUseSpell3:
                        isSpell4Ready = true;
                        heroHealth -= (hitHeroSpell3 + bossDamage);
                        heroSpell1Damage += recoveryHeroSpell1Damage;
                        Console.WriteLine("Вы приготовились к атаке, пожертвовав дополнительно " + hitHeroSpell3 + " здоровья.");
                        if (heroSpell1Damage > maximumHeroSpell1Damage)
                        {
                            heroSpell1Damage = maximumHeroSpell1Damage;
                        }
                        break;

                    case CommandUseSpell4:
                        if (isSpell4Ready == true)
                        {
                            bossHealth -= heroSpell4Damage;
                            heroHealth -= bossDamage;
                            heroSpell1Damage += recoveryHeroSpell1Damage;
                            Console.WriteLine("Ударом тяжолого меча, вы нанесли " + heroSpell4Damage + " урона.");
                        }
                        else if (isSpell4Ready == false)
                        {
                            heroHealth -= bossDamage;
                            Console.WriteLine("Не подготовившись к удару мечом, вы зря потратили ход. Павший король увернулся.");
                        }

                        if (heroSpell1Damage > maximumHeroSpell1Damage)
                        {
                            heroSpell1Damage = maximumHeroSpell1Damage;
                        }
                        break;
                }
            }

            if (bossHealth <= 0 && heroHealth <= 0)
            {
                Console.WriteLine("Ты боролся как истинный воин, но даже упокоив Павшего Короля, ты не смог выйти из боя живым.");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("У тебя получилось упокоить душу Павшего Короля, воин. Теперь ты свободен.");
            }
            else if (heroHealth <= 0)
            {
                Console.WriteLine("Увы, но как бы храбро ты не сражался, Павший Король оказался сильнее.");
            }
        }
    }
}