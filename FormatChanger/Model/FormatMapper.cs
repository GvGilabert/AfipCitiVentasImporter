using System;
using System.Collections.Generic;
using System.Linq;

namespace FormatChanger.Model
{
    class FormatMapper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FormatMappedField> MappingFields { get; set; }


        public SavedExport MapFile(SavedExport file, Format format, IEquivalence equivalenceModule, string fileName = "TempFile")
        {
            SavedExport result = new SavedExport()
            {
                CreationDate = DateTime.Now,
                FileName = fileName,
                Format = format,
                SavedRows = new List<SavedRow>(),
            };

            foreach (var item in file.SavedRows)
            {
                var a = MapRow(item, equivalenceModule);
                if (a is not null)
                    result.SavedRows.Add(a);
            }
            return result;
        }
        private SavedRow MapRow(SavedRow originFields, IEquivalence equivalenceModule)
        {
            SavedRow newRow = new SavedRow()
            {
                SavedFields = new List<SavedField>()
            };

            foreach (FormatMappedField mappedField in MappingFields)
            {
                var val = originFields.SavedFields.Where(of => of.FieldFormat == mappedField.FieldFrom).FirstOrDefault()?.Value;
                newRow.SavedFields.Add(new SavedField()
                {
                    FieldFormat = mappedField.FieldTo,
                    Value = val ?? mappedField.FieldTo.DefaultValue
                });
            }

            foreach (string key in equivalenceModule.CalculationValues.Keys)
            {
                if (equivalenceModule.CalculationValues.ContainsKey(key))
                    equivalenceModule.CalculationValues[key] = originFields.SavedFields.Where(s => s.FieldFormat.Name == key).FirstOrDefault().Value.Replace("\"", "");
            }
            equivalenceModule.RowDataForCalculations();
            if (equivalenceModule.SetValues(newRow) is not null)
            {
                return newRow;
            }
            else
                return null;
        }
    }
}
