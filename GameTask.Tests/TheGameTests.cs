namespace GameTaskApp.Tests
{
    [TestFixture]
    public class TheGameTests
    {
        [TestCase(1, 100)]
        [TestCase(10, 200)]
        public void NextGame_ShouldChangeThenumber(int min, int max)
        {
            TheGame game = new TheGame(min, max);
            int initialnumber = game.getThenumber();
            game.nextGame(min, max);
            int newnumber = game.getThenumber();
            Assert.AreNotEqual(initialnumber, newnumber);
        }

        [TestCase(50, 40, Guess.less)]
        [TestCase(40, 50, Guess.more)]
        [TestCase(42, 42, Guess.equal)]
        public void CheckVariant_ShouldReturnExpectedResult(int v, int thenumber, Guess expectedResult)
        {
            TheGame game = new TheGame(1, 100);
            thenumber = game.getThenumber();
            Guess result = game.checkVariant(v);
            Assert.AreEqual(expectedResult, result);
        }
    }

}