using System;

namespace GameTask
{

	public class TheGame
	{
		private int thenumber;
        public enum Guess
        {
			notAssigned,
            more,
            less,
            equal
        };
        public TheGame(int m, int n)
		{
		//	Random random
			thenumber = new Random().Next(m, n+1);	
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
            thenumber = new Random().Next(m, n + 1);
			return thenumber;
        }
	}
}
