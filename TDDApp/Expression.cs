using System;
using System.Collections.Generic;
using System.Text;

namespace TDDApp
{
    public interface IExpression
    {
        Money Reduce(string to);
    }
}
