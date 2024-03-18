using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialProj
{
    interface IInstrumentRepository
    {
        void InsertFinancialInstrument(double marketValue, string type);
        List<FinancialInstrument> SelectFinancialInstruments();
    }
}
