using System;

namespace GameTask
{

	public class TheGame
	{
		private int thenumber;
		public TheGame(int m, int n)
		{
		//	Random random
			thenumber = new Random().Next(m, n+1);	
		}

		public int getThenumber()
		{ return thenumber; }

		public char checkVariant(int v)
		{
			if (v < thenumber) return '<'; // "Ваше число менше загаданного, спробуте ще!";
			else if (v > thenumber) return '>'; //"Ваше число більше загаданного, спробуте ще!";
			else return '='; //$"Вітаю! ви вгадали загадане число - {thenumber}";
					
        }
		public int nextGame(int m, int n)
		{
            thenumber = new Random().Next(m, n + 1);
			return thenumber;
        }
	}
}
