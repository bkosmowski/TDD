namespace TDDApp
{
    public class Sum : IExpression
    {
        public Sum(Money augend, Money addeed)
        {
            Augend = augend;
            Addend = addeed;
        }

        public Money Augend { get; }
        public Money Addend { get; }

        public Money Reduce(string to)
        {
            var amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }
    }
}
