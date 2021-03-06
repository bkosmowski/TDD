﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TDDApp
{
    public interface IExpression
    {
        Money Reduce(Bank bank, string to);

        IExpression Plus(IExpression addend);

        IExpression Times(int multiplier);
    }
}
