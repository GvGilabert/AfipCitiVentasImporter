using FormatChanger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.CitiComprasVentasModule 
{
    class CitiComprasVentasModule : IEquivalence
    {
        public Dictionary<string, string> CalculationValues { get; set; }
        readonly CitiComprasVentasUtils utils;
        CitiComprasCalcValues calcValues;

        public CitiComprasVentasModule()
        {
            CalculationValues = new Dictionary<string, string>();
            CalculationValues.Add("IVA", "");
            CalculationValues.Add("Imp. Neto Gravado", "");
            CalculationValues.Add("Imp. Total", "");
            CalculationValues.Add("Tipo", "");
            CalculationValues.Add("Número Desde", "");
            CalculationValues.Add("Número Hasta", "");
            utils = new();
        }

        public SavedRow SetValues(SavedRow row)
        {
            if (row.SavedFields is not null && row.SavedFields.Count > 0)
            {
                if (row.SavedFields?.First().FieldFormat.Father.Name == "CitiAlicuotasComprasImport")
                {
                    if ((calcValues.Tipo.Substring(0, 2).Trim() == "1" || calcValues.Tipo.Substring(0, 2).Trim() == "51" || calcValues.Tipo.Substring(0, 2).Trim() == "3") && calcValues.IVA != 0)
                    {
                        row.SavedFields.ToList().ForEach(sf => sf.Value = utils.StringFormmater(field: sf, calcValues));
                        return row;
                    }
                    else 
                        return null;
                }
                else
                {
                    row.SavedFields.ToList().ForEach(sf => sf.Value = utils.StringFormmater(sf, calcValues));
                    return row;
                }
            }
            return null;
        }
        public void RowDataForCalculations()
        {
            calcValues = new() {
                IVA = (!string.IsNullOrEmpty(CalculationValues["IVA"])) ? double.Parse(CalculationValues["IVA"].Replace(".", ",")) : 0,
                ImpNetoGravado = (!string.IsNullOrEmpty(CalculationValues["Imp. Neto Gravado"])) ? double.Parse(CalculationValues["Imp. Neto Gravado"].Replace(".", ",")) : 0,
                ImpTotal = (!string.IsNullOrEmpty(CalculationValues["Imp. Total"])) ? double.Parse(CalculationValues["Imp. Total"].Replace(".", ",")) : 0,
                Tipo = CalculationValues["Tipo"].Replace(".", ","),
                NumeroDesde = CalculationValues["Número Desde"],
                NumeroHasta = CalculationValues["Número Hasta"]
            };
        }
    }
}
