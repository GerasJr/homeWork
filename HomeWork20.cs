using System;

namespace hm20
{
    class HomeWork20
    {
        static void Main(string[] args)
        {
            int playerHp = 200;
            int shield = 300;
            int energy = 100;
            int maxEnergy = 100;
            int healingPotions = 2;
            int bossHp = 1000;
            int lightBlowDamage = 100;
            int highBlowDamage = 200;
            int lightEnergyCost = 25;
            int highEnergyCost = 50;
            int energyFill = 50;
            int playerHpFill = 250;
            int lightBossDamage = 75;
            int highBossDamage = 150;
            string userInput;

            Console.WriteLine("Вы храбрый рыцарь, который обязан убить гиганта живущего в заброшенном замке...");
            Console.ReadKey();
            Console.WriteLine("И вот вы встретились лицом к лицу. Он был ростом в 2 раза выше вашего, а его жуткий взгляд нагоняет страх.");
            Console.ReadKey();
            Console.WriteLine("Но точно не у вас. Вы обязаны выполнить свой долг как рыцаря и прикончить эту тварь.");
            Console.ReadKey();

            while(bossHp > 0 && playerHp > 0)
            {
                Console.WriteLine($"Здоровье: {playerHp}");
                Console.WriteLine($"Прочность щита: {shield}");
                Console.WriteLine($"Зелья исцеления: {healingPotions}");
                Console.WriteLine($"Энергия: {energy}");
                Console.WriteLine($"Здоровье гиганта: {bossHp}");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine($"1 - Легкий удар мечом (-{lightEnergyCost} энергии)");
                Console.WriteLine($"2 - Сильный удар мечом (-{highEnergyCost} энергии)");
                Console.WriteLine("3 - Отступить");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        if(energy >= lightEnergyCost)
                        {
                            bossHp -= lightBlowDamage;
                            energy -= lightEnergyCost;
                            Console.WriteLine($"Вы наносите удар гиганту в {lightBlowDamage} урона");
                        }
                        else
                        {
                            playerHp -= lightBossDamage;
                            Console.WriteLine($"У вас не хватило сил даже замахнуться, гигант наносит вам {lightBossDamage} урона");
                        }
                        break;
                    case "2":
                        if(energy >= highEnergyCost)
                        {
                            bossHp -= highBlowDamage;
                            energy -= highEnergyCost;
                            Console.WriteLine($"Вы наносите удар гиганту в {highBlowDamage} урона");
                        }
                        else
                        {
                            playerHp -= lightBossDamage;
                            Console.WriteLine($"У вас не хватило сил даже замахнуться, гигант наносит вам {lightBossDamage} урона");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Вы отступили, ваши действия:");
                        Console.WriteLine($"1 - Перевести дух (+{energyFill} энергии, -{lightBossDamage} здоровья)");
                        Console.WriteLine($"2 - Выпить зелье исцеления (Всего: {healingPotions})");
                        userInput = Console.ReadLine();

                        if(userInput == "1")
                        {
                            playerHp -= lightBossDamage;
                            energy += energyFill;

                            if(energy > maxEnergy)
                            {
                                energy = maxEnergy;
                            }

                            Console.WriteLine($"Пока вы отдыхали гигант успел нанести вам {lightBossDamage} урона");
                            Console.WriteLine($"Но вы восстановили энергию (Ваша энергия: {energy})");
                        }
                        else if(userInput == "2")
                        {
                            playerHp = playerHpFill;
                            healingPotions--;
                            Console.WriteLine("Вы исцелились");
                        }
                        else
                        {
                            Console.WriteLine("Вы решили подумать о жизни пока гигант бежит на вас");
                        }
                        break;
                    default:
                        Console.WriteLine($"Вы решили стоять на месте, гигант наносит вам {lightBossDamage} урона");
                        break;
                }

                if(playerHp <= 0 || bossHp <= 0)
                {
                    break;
                }

                Console.WriteLine("Гигант нападает");
                Console.WriteLine($"1 - Контратака (-{highEnergyCost} энергии)");
                Console.WriteLine($"2 - Увернуться (-{lightEnergyCost} энергии)");
                Console.WriteLine($"3 - Использовать щит (-{highBossDamage} прочности)");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        if(energy >= highEnergyCost)
                        {
                            energy -= highEnergyCost;
                            bossHp -= lightBlowDamage;
                            Console.WriteLine($"Вы успешно контратаковали и нанесли гиганту {lightBlowDamage} урона");
                        }
                        else
                        {
                            playerHp -= highBossDamage;
                            Console.WriteLine($"Вы не смогли контратакавать, гигант наносит вам {highBossDamage} урона");
                        }
                        break;
                    case "2":
                        if(energy >= lightEnergyCost)
                        {
                            energy -= lightEnergyCost;
                            Console.WriteLine($"Вы успешно увернулись");
                        }
                        else
                        {
                            playerHp -= highBossDamage;
                            Console.WriteLine($"У вас не хватило сил увернуться, гигант наносит вам {highBossDamage} урона");
                        }
                        break;
                    case "3":
                        if(shield >= highBossDamage)
                        {
                            shield -= highBossDamage;
                            Console.WriteLine($"Вы успешно прикрылись щитом но его прочность снижена (Текущая прочность - {shield})");
                        }
                        else
                        {
                            playerHp -= highBossDamage;
                            Console.WriteLine($"Ваш щит уже сломан, гигант наносит вам {highBossDamage} урона");
                        }
                        break;
                    default:
                        Console.WriteLine($"Вы ничего не сделали и гигант нанес вам {highBossDamage} урона");
                        break;
                }
            }

            if(playerHp > 0)
            {
                Console.WriteLine("Гигант повержен, поздравляем!");
            }
            else if(bossHp > 0)
            {
                Console.WriteLine("Вы умерли от руки гиганта.");
            }
        }
    }
}
