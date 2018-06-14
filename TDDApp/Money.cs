﻿namespace TDDApp
{
    public class Money : IExpression
    {
        private readonly string _currency;

        public Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public override bool Equals(object obj) => obj is Money money &&
                                                   Amount == money.Amount &&
                                                   Currency() == money.Currency();

        public static Money Dollar(int amount) => new Money(amount, "USD");
        public static Money Franc(int amount) => new Money(amount, "CHF");

        public Money Times(int multiplier) => new Money(multiplier * Amount, _currency);

        public string Currency() => _currency;

        public int Amount { get; }

        public override string ToString() => Amount + " " + _currency;

        public IExpression Plus(Money added) => new Money(Amount + added.Amount, Currency());

        public Money Reduce(string to) => this;
    }
}
