using System;
using System.Collections;
using System.Collections.Generic;

namespace TDDApp
{
    public class Bank
    {
        private readonly Hashtable _rates = new Hashtable();
        public Bank()
        {
        }

        public Money Reduce(IExpression source, string to) => source.Reduce(this, to);

        public void AddRate(string from, string to, int rate)
        {
            _rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to))
            {
                return 1;
            }
            var rate = _rates[new Pair(@from, to)];

            return (int) rate;
        }

        private class Pair
        {
            private readonly string _from;
            private readonly string _to;

            public Pair(string from, string to)
            {
                _from = from;
                _to = to;
            }

            public override bool Equals(object obj)
            {
                return obj is Pair pair &&
                       _from == pair._from &&
                       _to == pair._to;
            }

            public override int GetHashCode()
            {
                var hashCode = 1420309613;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_from);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_to);
                return hashCode;
            }
        }
    }
}