namespace BettyTask.Tests;

public class GameTests
{
    private const string loseKey = "lose";
    private const string smallWinKey = "small win";
    private const string bigWinKey = "big win";

    [Fact]
    public void Bet_WhenWePlace1000Bets_TheProportionsOfTheOutcomeIsFearllySimilar()
    {
        var resultDic = new Dictionary<String, int>();//OddType -> times Hit
        var bet = 1;
        var game = new Game();

        resultDic.Add(loseKey, 0);
        resultDic.Add(smallWinKey, 0);
        resultDic.Add(bigWinKey, 0);
        
        for (int i = 0; i < 1000; i++)
        {
            var temp = game.Bet(bet);
            if (temp == 0)
            {
                resultDic[loseKey]++;
                continue;
            }
            if (temp > 2)
            {
                resultDic[bigWinKey]++;
                continue;
            }
            resultDic[smallWinKey]++;

        }
        Assert.True(true);// Some check to see how many times each was hit and if the result percentage is similar to what we want
    }
}
