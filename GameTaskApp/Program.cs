// Зробити гру по вгадуванню числа.
// З конфігом в якому є налаштування по діапазону мінімального значення та максимального.
// При запуску гра просить ввести число в діапазоні і після введення пише це число більше, менше, або вгадав.
// Гра продовжується поки не вгадаєш число. Потім пропонує зіграти ще або вийти

using System.Configuration;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using GameTaskApp;


try
{


    ConfigParse config = new ConfigParse();
    int m = config.minValue; 
    int n = config.maxValue;

    TheGame game = new TheGame(m, n);

    Console.Write($"Компутер загадав число у діапазоні [{m},{n}] і грає з вами в гру)) Спробуйте його відгадати:");

    int variant = m-1;
    bool isnumber = false;// int.TryParse(Console.ReadLine(), out variant);
    string replay = "1";
    Guess guess = Guess.notAssigned;

    while (true)
    {
        game.play();
        Console.WriteLine($"Вітаю! Ви угадали число {game.getThenumber()}");
        Console.Write("Якщо бажаєте зіграти ще раз, введіть 1:");
        replay = Console.ReadLine();
        if (replay != "1") break;
        game.nextGame(m, n);
        isnumber = false;
        guess = Guess.notAssigned;
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
