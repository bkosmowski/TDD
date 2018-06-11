namespace TDDApp
{
    public class Money
    {
        private readonly int _amount;
        private readonly string _currency;

        public Money(int amount, string currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public override bool Equals(object obj) => obj is Money money &&
                                                   _amount == money._amount &&
                                                   Currency() == money.Currency();

        public static Money Dollar(int amount) => new Money(amount, "USD");
        public static Money Franc(int amount) => new Money(amount, "CHF");

        public Money Times(int multiplier) => new Money(multiplier * _amount, _currency);

        public string Currency() => _currency;

        public override string ToString() => _amount + " " + _currency;

        public Money Plus(Money added) => new Money(_amount + added._amount, Currency());
    }
}
