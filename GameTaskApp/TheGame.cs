using System;
using System.Reflection;

namespace GameTaskApp
{

	public class TheGame
	{
		private int _thenumber;
        private int _m, _n;

        public TheGame(int min, int max)
		{
		//	Random random
			_thenumber = new Random().Next(min, max+1);
            _m = min; 
            _n = max;
		}

		public int getThenumber()
		{ return _thenumber; }

		public Guess checkVariant(int v)
		{
            switch (v.CompareTo(_thenumber))
            {
                case -1:
                    return Guess.less;
                case 1:
                    return Guess.more;
                default:
                    return Guess.equal;
            }
            /*
			if (v < _thenumber) return Guess.less; // "Ваше число менше загаданного, спробуте ще!";
			else if (v > _thenumber) return Guess.more; //"Ваше число більше загаданного, спробуте ще!";
			else return Guess.equal; //$"Вітаю! ви вгадали загадане число - {thenumber}";
			*/	
        }
		public int nextGame(int min, int max)
		{
            this._thenumber = new Random().Next(min, max + 1);
            this._m = min;
            this._n = max;
			return _thenumber;
        }

		public void play()
		{
            int variant = _m - 1;
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
