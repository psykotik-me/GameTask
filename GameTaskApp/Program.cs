// Зробити гру по вгадуванню числа.
// З конфігом в якому є налаштування по діапазону мінімального значення та максимального.
// При запуску гра просить ввести число в діапазоні і після введення пише це число більше, менше, або вгадав.
// Гра продовжується поки не вгадаєш число. Потім пропонує зіграти ще або вийти

using System.Configuration;
using GameTask;
using GameTaskApp;

try
{
    ConfigParse config = new ConfigParse();
    int m=0, n=0;
    if (config.readRange())
    {
        m = config.minValue; n = config.maxValue;
    }
    TheGame game = new TheGame(m, n);

    Console.Write($"Компутер загадав число у діапазоні [{m},{n}] і грає з вами в гру)) Спробуйте його відгадати і введіть ваш варіант:");

    int variant = m-1;
    bool isnumber = int.TryParse(Console.ReadLine(), out variant);
    char guess = '1';

    while (guess == '1')
    {
        while (guess != '=')
        {
            while (!isnumber)
            {
                Console.Write("Введіть ціле число!:");
                isnumber = int.TryParse(Console.ReadLine(), out variant);
            }
            guess = game.checkVariant(variant);
            if (guess == '<') Console.WriteLine($"Ваше число {variant} менше загаданного, спробуте ще!");
            else if (guess == '>') Console.WriteLine($"Ваше число {variant} більше загаданного, спробуте ще!");
            else if (guess == '=') break;
            Console.Write("Введіть настпний варіант: ");
            isnumber = int.TryParse(Console.ReadLine(), out variant);
        }
        Console.WriteLine($"Вітаю! Ви угадали число {variant}");
        Console.Write("Якщо бажаєте зіграти ще раз, введіть 1:");
        guess = Console.ReadLine()[0];
        if (guess == '1') game.nextGame(m, n);
        isnumber = false;
    }
}
catch (ConfigurationErrorsException Cex)
{
    Console.WriteLine(Cex.Message);
}
catch (Exception Ex)
{
    Console.WriteLine(Ex.Message);
}
