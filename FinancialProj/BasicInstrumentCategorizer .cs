using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialProj
{
    class BasicInstrumentCategorizer : IInstrumentCategorizer
    {
        public InstrumentCategory Categorize(FinancialInstrument instrument)
        {
            if (instrument.MarketValue < 1000000)
                return InstrumentCategory.LowValue;
            else if (instrument.MarketValue >= 1000000 && instrument.MarketValue <= 5000000)
                return InstrumentCategory.MediumValue;
            else
                return InstrumentCategory.HighValue;
        }

    }
}
