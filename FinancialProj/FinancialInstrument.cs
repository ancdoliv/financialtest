using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialProj
{
    class FinancialInstrument
    {
        public double MarketValue { get; }
        public string Type { get; }

        public FinancialInstrument(double marketValue, string type)
        {
            MarketValue = marketValue;
            Type = type;
        }

    }

}