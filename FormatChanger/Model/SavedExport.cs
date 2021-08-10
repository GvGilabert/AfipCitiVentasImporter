using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.Model
{
    class SavedExport
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public Format Format { get; set; }
        public ICollection<SavedRow> SavedRows { get; set; }


        public bool GenerateTxt(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    List<string> rows = new List<string>();
                    foreach (SavedRow sr in SavedRows)
                    {
                        rows.Add(string.Join("", sr.SavedFields.OrderBy(sf => sf.FieldFormat.Position).Select(sf => sf.Value).ToArray()));
                    }
                    File.WriteAllLines(path, rows, new UTF8Encoding(false));
                    return true;
                }
                throw new Exception ("El archivo no existe");
            }
            catch 
            {
                throw;
            }
        }
    }
}
