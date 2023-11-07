// Зробити гру по вгадуванню числа.
// З конфігом в якому є налаштування по діапазону мінімального значення та максимального.
// При запуску гра просить ввести число в діапазоні і після введення пише це число більше, менше, або вгадав.
// Гра продовжується поки не вгадаєш число. Потім пропонує зіграти ще або вийти

using System.Configuration;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using GameTask;
using GameTaskApp;

try
{


    ConfigParse config = new ConfigParse();
    int m = config.minValue; 
    int n = config.maxValue;

    TheGame game = new TheGame(m, n);

    Console.Write($"Компутер загадав число у діапазоні [{m},{n}] і грає з вами в гру)) Спробуйте його відгадати і введіть ваш варіант:");

    int variant = m-1;
    bool isnumber = int.TryParse(Console.ReadLine(), out variant);
    char replay = '1';
    TheGame.Guess guess = TheGame.Guess.notAssigned;

    while (replay == '1')
    {
        while (guess != TheGame.Guess.equal)
        {
            while (!isnumber)
            {
                Console.Write("Введіть ціле число!:");
                isnumber = int.TryParse(Console.ReadLine(), out variant);
            }
            guess = game.checkVariant(variant);
            if (guess == TheGame.Guess.less) Console.WriteLine($"Ваше число {variant} менше загаданного, спробуте ще!");
            else if (guess == TheGame.Guess.more) Console.WriteLine($"Ваше число {variant} більше загаданного, спробуте ще!");
            else if (guess == TheGame.Guess.equal) break;
            Console.Write("Введіть настпний варіант: ");
            isnumber = int.TryParse(Console.ReadLine(), out variant);
        }
        Console.WriteLine($"Вітаю! Ви угадали число {variant}");
        Console.Write("Якщо бажаєте зіграти ще раз, введіть 1:");
        replay = Console.ReadLine()[0];
        if (replay == '1') game.nextGame(m, n);
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
