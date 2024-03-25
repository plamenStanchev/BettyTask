namespace BettyTask.Tests;

public class WalletTests
{
    public Wallet Wallet { get; set; }
    public WalletTests()
    {
        Wallet = new Wallet();
    }

    [Theory]
    [InlineData(5.0)]
    [InlineData(10.0)]
    [InlineData(0.1)]
    [InlineData(100)]
    public void Deposit_WhenAmountIsAbove_ReturnTrueAndBalanceIsEqualToAmout(double amount)
    {
        var amoutDecimal = Convert.ToDecimal(amount);

        var res = Wallet.Deposit(amoutDecimal);

        Assert.True(res.Succeeded);
        Assert.False(res.Failure);
        Assert.Equal(amoutDecimal, Wallet.Balance);
    }

    [Fact]
    public void Deposit_WhenWeHaveMultipleDeposits_ReturnTrueAndBalanceIs50()
    {
        var amount1 = 10.0m;
        var amount2 = 15.5m;
        var amount3 = 4.5m;
        var amount4 = 20m;

        var res1 = Wallet.Deposit(amount1);
        var res2 = Wallet.Deposit(amount2);
        var res3 = Wallet.Deposit(amount3);
        var res4 = Wallet.Deposit(amount4);

        Assert.True(res1.Succeeded);
        Assert.True(res2.Succeeded);
        Assert.True(res3.Succeeded);
        Assert.True(res4.Succeeded);

        Assert.False(res1.Failure);
        Assert.False(res2.Failure);
        Assert.False(res3.Failure);
        Assert.False(res4.Failure);

        Assert.Equal(50m, Wallet.Balance);
    }

    [Fact]
    public void Deposit_WhenAmountIsLessThanZero_ReturnFalseAndErrorMessageIsPresentAndBalanceIsZero()
    {
        var amount = -10m;

        var res = Wallet.Deposit(amount);

        Assert.False(res.Succeeded);
        Assert.True(res.Failure);
        Assert.Equal(Wallet.AmountExceptionMessage, res.Error);
        Assert.Equal(0.0m, Wallet.Balance);
    }

    [Fact]
    public void Withdow_WhenBalanceIs50AndHaveMultipleWithdraws_ReturnsAllTrueAndBalanceIs0()
    {
        Wallet.Deposit(50);//We can do this with Reflection and bypass any checks/additional logic if we want to be supper sure

        var amount1 = 10.0m;
        var amount2 = 15.5m;
        var amount3 = 4.5m;
        var amount4 = 20m;

        var res1 = Wallet.Withdraw(amount1);
        var res2 = Wallet.Withdraw(amount2);
        var res3 = Wallet.Withdraw(amount3);
        var res4 = Wallet.Withdraw(amount4);

        Assert.True(res1.Succeeded);
        Assert.True(res2.Succeeded);
        Assert.True(res3.Succeeded);
        Assert.True(res4.Succeeded);

        Assert.False(res1.Failure);
        Assert.False(res2.Failure);
        Assert.False(res3.Failure);
        Assert.False(res4.Failure);

        Assert.Equal(0.0m, Wallet.Balance);
    }

    [Fact]
    public void Withdow_WhenBalanceIs0AndHaveMultipleWithdraws_ReturnsFailAndBalanceIs0()
    {
        var amount1 = 10.0m;
        var amount2 = 15.5m;
        var amount3 = 4.5m;
        var amount4 = 20m;

        var res1 = Wallet.Withdraw(amount1);
        var res2 = Wallet.Withdraw(amount2);
        var res3 = Wallet.Withdraw(amount3);
        var res4 = Wallet.Withdraw(amount4);

        Assert.False(res1.Succeeded);
        Assert.False(res2.Succeeded);
        Assert.False(res3.Succeeded);
        Assert.False(res4.Succeeded);

        Assert.True(res1.Failure);
        Assert.True(res2.Failure);
        Assert.True(res3.Failure);
        Assert.True(res4.Failure);

        Assert.Equal(Wallet.WithdrawAmountExceptionMessage,res1.Error);
        Assert.Equal(Wallet.WithdrawAmountExceptionMessage, res2.Error);
        Assert.Equal(Wallet.WithdrawAmountExceptionMessage, res3.Error);
        Assert.Equal(Wallet.WithdrawAmountExceptionMessage, res4.Error);

        Assert.Equal(0.0m, Wallet.Balance);
    }
}