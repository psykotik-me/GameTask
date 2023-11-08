using System;
using System.Reflection;

namespace GameTaskApp
{

	public class TheGame
	{
		private int thenumber;
        private int m, n;

        public TheGame(int min, int max)
		{
		//	Random random
			thenumber = new Random().Next(m, n+1);
            m = min; n=max;
		}

		public int getThenumber()
		{ return thenumber; }

		public Guess checkVariant(int v)
		{
			if (v < thenumber) return Guess.less; // "Ваше число менше загаданного, спробуте ще!";
			else if (v > thenumber) return Guess.more; //"Ваше число більше загаданного, спробуте ще!";
			else return Guess.equal; //$"Вітаю! ви вгадали загадане число - {thenumber}";
					
        }
		public int nextGame(int m, int n)
		{
            this.thenumber = new Random().Next(m, n + 1);
			return thenumber;
        }

		public void play()
		{
            int variant = m - 1;
            bool isnumber = false;
            Guess guess = Guess.notAssigned;
            while (guess != Guess.equal)
            {
                while (!isnumber)
                {
                    Console.Write("Введіть ціле число!:");
                    isnumber = int.TryParse(Console.ReadLine(), out variant);
                }
                guess = checkVariant(variant);
                switch (guess)
                {
                    case Guess.less:
                        Console.WriteLine($"Ваше число {variant} менше загаданого, спробуйте ще!");
                        break;
                    case Guess.more:
                        Console.WriteLine($"Ваше число {variant} більше загаданого, спробуйте ще!");
                        break;
                    case Guess.equal:
                        // Вихід з циклу
                        return ;
                    default:
                        break;
                }
                Console.Write("Введіть наступний варіант: ");
                isnumber = int.TryParse(Console.ReadLine(), out variant);
            }
        }
	}
}
