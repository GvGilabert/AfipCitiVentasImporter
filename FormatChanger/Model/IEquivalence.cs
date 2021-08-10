using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.Model
{
    interface IEquivalence
    {
        Dictionary<string, string> CalculationValues { get; set; }

        SavedRow SetValues(SavedRow rows);
        void RowDataForCalculations();
    }
}
