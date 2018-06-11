using System;
using System.Linq.Expressions;
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
            Action sum = { return Money.Dollar(5).Plus(Money.Dollar(5));};
            var bank = new Bank();
            var reduced = );

            Assert.Equal(Money.Dollar(10), reduced);
        }
    }
}
