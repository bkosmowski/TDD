namespace TDDApp
{
    public class Bank
    {
        public Bank()
        {
        }

        public Money Reduce(IExpression source, string to) => source.Reduce(to);
    }
}