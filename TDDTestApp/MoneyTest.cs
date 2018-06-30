using System;
using TDDApp;
using Xunit;

namespace TDDTestApp
{
    public class MoneyTest
    {
        [Fact]
        public void TestMultiplication()
        {
            var five = Money.Dollar(5);

            Assert.Equal(Money.Dollar(10), five.Times(2));

            Assert.Equal(Money.Dollar(15), five.Times(3));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Fact]
        public void TestCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency());
            Assert.Equal("CHF", Money.Franc(1).Currency());
        }

        [Fact]
        public void TestSimpleAddition()
        {
            var five = Money.Dollar(5);

            IExpression expression = five.Plus(five);

            var bank = new Bank();
            var reduced = bank.Reduce(expression, "USD");

            Assert.Equal(Money.Dollar(10), reduced);
        }

        [Fact]
        public void TestPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            IExpression result = five.Plus(five);
            var sum = (Sum) result;
            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void TestReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(7), result);
        }

        [Fact]
        public void TestReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.Dollar(1), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            var result = bank.Reduce(Money.Franc(2), "USD");

            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void TestArrayEquals()
        {
            Assert.Equal(new Object[] {"abc"}, new object[] {"abc"});
        }

        [Fact]
        public void TestIdentityRate()
        {
            Assert.Equal(1, new Bank().Rate("USD", "USD"));
        }

        [Fact]
        public void TestMixedAddition()
        {
            var fiveBucks = Money.Dollar(5);
            var tenFrancs = Money.Franc(10);

            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");

            Assert.Equal(Money.Dollar(10), result);
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            var fiveBucks = Money.Dollar(5);
            var tenFrancs = Money.Franc(10);

            var bank = new Bank();
            bank.AddRate(tenFrancs.Currency(), fiveBucks.Currency(), 2);

            var result = bank.Reduce(new Sum(fiveBucks, tenFrancs).Plus(fiveBucks), fiveBucks.Currency());

            Assert.Equal(Money.Dollar(15), result);
        }

        [Fact]
        public void TestSumTimes()
        {
            var fiveBucks = Money.Dollar(5);
            var tenFrancs = Money.Franc(10);

            var bank = new Bank();
            bank.AddRate(tenFrancs.Currency(), fiveBucks.Currency(), 2);

            var result = bank.Reduce(new Sum(fiveBucks, tenFrancs).Times(2), fiveBucks.Currency());

            Assert.Equal(Money.Dollar(20), result);
        }
    }
}
