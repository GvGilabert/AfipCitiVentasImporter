using FormatChanger.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.CitiComprasVentasModule
{
    class CitiComprasVentasUtils
    {

        public string StringFormmater(SavedField field, CitiComprasCalcValues calcValues)
        {
            field.Value = field.Value.Replace("\"", "").Trim();

            return field.FieldFormat.StringFormatter switch
            {
                "yyyyMMdd"      => $"{DateTime.Parse(field.Value):yyyyMMdd}".Substring(0, field.FieldFormat.Length ?? 0),
                "TIPOCOMP"      => $"{field.Value.Substring(0, 2).Trim().PadLeft(3, '0').Substring(0, field.FieldFormat.Length ?? 0)}",
                "CODDOC"        => GetCodDocumento(field.Value),
                "0.00"          => ParseNumber(field.Value).PadLeft(field.FieldFormat?.Length ?? 0, field.FieldFormat?.PaddingChar ?? '0'),
                "MONEDA"        => $"{((field.Value == "$") ? "PES" : "DOL")}",
                "0000.000000"   => FormatNumber46(field.Value),
                "DENOEMI"       => FormatDenoemi(field),
                "IIBB"          => GetIIBB(calcValues.IVA, calcValues.ImpNetoGravado, calcValues.ImpTotal),
                "CANTALICUOTAS" => GetCanAlicuotas(calcValues.Tipo),
                "CANTALICSVTAS" => GetCanAlicuotasVentas(calcValues.Tipo),
                "ALICUOTAIVA"   => GetAlicuotaIva(calcValues.IVA, calcValues.ImpNetoGravado).Trim().PadLeft(field.FieldFormat?.Length ?? 0, field.FieldFormat?.PaddingChar ?? '0').Substring(0, field.FieldFormat.Length ?? 0),
                "CREDFISCCOMP"  => GetCredFisComp(calcValues.IVA, calcValues.Tipo),
                "CODALICUOTA"   => $"{((calcValues.IVA * 100 / calcValues.ImpNetoGravado) >= 20 ? "0005" : "0004")}",
                "NUMHASTA"      => $"{(String.IsNullOrEmpty(calcValues.NumeroHasta) ? calcValues.NumeroDesde.PadLeft(20, '0') : calcValues.NumeroHasta.PadLeft(20, '0'))}",
                _ => field.Value.PadLeft(field.FieldFormat?.Length ?? 0, field.FieldFormat?.PaddingChar ?? ' ').Substring(0, field.FieldFormat.Length ?? 0)
            };
        }

        private string FormatDenoemi(SavedField field)
        {
            string result = !string.IsNullOrEmpty(field.Value) ? field.Value : field.FieldFormat.DefaultValue;
            return result.PadRight(field.FieldFormat?.Length ?? 0, field.FieldFormat?.PaddingChar ?? ' ').Substring(0, field.FieldFormat.Length ?? 0);
        }

        public string GetCredFisComp(double IVA, string Tipo)
        {
            return $"{(IVA == 0 || (Tipo.Substring(0, 2).Trim() != "1" && Tipo.Substring(0, 2).Trim() != "51" && Tipo.Substring(0, 2).Trim() != "3") ? "0" : IVA.ToString("0.00")).Replace(".", "").Replace(",", "").PadLeft(15, '0')}";
        }

        public string ParseNumber(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return double.Parse(value, CultureInfo.InvariantCulture).ToString("0.00").Replace(".", "").Replace(",", "");
            }
            else
            {
                return "000";
            };
        }

        public string GetCodDocumento(string documento)
        {
            string result = documento switch
            {
                "DNI" => "96",
                "CUIT" => "80",
                _ => documento,
            };
            return result;
        }

        public string GetIIBB(double IVA, double ImpNetoGravado, double ImpTotal)
        {
            double result;
            if (ImpNetoGravado == 0 && IVA == 0)
            {
                result = 0;
            }
            else
            {
                result = (ImpNetoGravado + IVA) < ImpTotal ? (ImpTotal - IVA - ImpNetoGravado) : 0;
            }
            return result.ToString("00.00").Replace(".", "").Replace(",", "").PadLeft(15, '0');
        }

        public string GetCanAlicuotas(string Tipo)
        {
            
            return $"{((Tipo.Substring(0, 2).Trim() == "1" || Tipo.Substring(0, 2).Trim() == "51" || Tipo.Substring(0, 2).Trim() == "3") ? "1" : "0")}";
        }

        public string GetCanAlicuotasVentas(string Tipo)
        {

            return $"{((Tipo.Substring(0, 2).Trim() == "1" || Tipo.Substring(0, 2).Trim() == "51" || Tipo.Substring(0, 2).Trim() == "3" || Tipo.Substring(0, 2).Trim() == "6") ? "1" : "0")}";
        }

        public string FormatNumber46(string value)
        {
            string[] strValues = value.Trim().Split(".");
            if (strValues.Length > 1)
            {
                return strValues[0].PadLeft(4, '0') + strValues[1].PadRight(6, '0');
            }
            else
            {
                return strValues[0].Replace(".", "").Replace(",", "").PadLeft(4, '0').PadRight(10, '0');
            };
        }

        public string GetAlicuotaIva(double IVA, double ImpNetoGravado )
        {
            return (IVA * 100 / ImpNetoGravado >= 20) ? "0005" : "0004";
        }
    }
}
