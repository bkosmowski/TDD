namespace TDDApp
{
    public class Sum : IExpression
    {
        public Sum(IExpression augend, IExpression addeed)
        {
            Augend = augend;
            Addend = addeed;
        }

        public IExpression Augend { get; }
        public IExpression Addend { get; }

        public Money Reduce(Bank bank, string to)
        {
            var amount = Augend.Reduce(bank, to).Amount + Addend.Reduce(bank, to).Amount;
            return new Money(amount, to);
        }

        public IExpression Plus(IExpression addend)
        {
            return new Sum(this, addend);
        }

        public IExpression Times(int multiplier) => new Sum(Augend.Times(multiplier), Addend.Times(multiplier));
    }
}