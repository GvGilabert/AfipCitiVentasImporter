using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.Model
{
    class FileManager
    {
        private readonly string path;
        private readonly Format format; 
        private readonly bool hasHeader;
        private const string OK = "Proceso finalizado correctamente.";
        private const string ERROR = "Error en el proceso: ";

        public FileManager(string _path, Format _format, bool _hasHeader)
        {
            path = _path;
            format = _format;
            hasHeader = _hasHeader;
        }

        public SavedExport MapFile(string filename)
        {
            SavedExport result = new SavedExport()
            {
                CreationDate = DateTime.Now,
                FileName = filename,
                Format = format,
                SavedRows = new List<SavedRow>()
            };
            List<string> errors = new List<string>();

            if (File.Exists(path))
            {
                using var sr = new StreamReader(path);
                string line;
                int lineNumber = 0;

                if (hasHeader) sr.ReadLine();
                
                while ((line = sr.ReadLine()) != null)
                {
                    SavedRow resultLine = new SavedRow()
                    {
                        SavedFields = new List<SavedField>()
                    };
                    lineNumber++;
                    string[] splittedLine = line.Split((char)format.Delimiter);
                    if (splittedLine.Length == format.Fields.Count)
                    {
                        int fieldNumber = 0;
                        foreach (string field in splittedLine)
                        {
                            SavedField sfield = new SavedField()
                            {
                                Value = field,
                                FieldFormat = format.Fields.ElementAt(fieldNumber++)
                            };
                            resultLine.SavedFields.Add(sfield);
                        }                        
                    }
                    else
                    {
                        errors.Add(ERROR+ $"linea {lineNumber} cantidad de campos del archivo no coincide con el formato seleccionado.");
                    }
                    result.SavedRows.Add(resultLine);
                }
            }
            else
            {
                errors.Add(ERROR+"No existe la ruta o el archivo");
            }
            return result;
        }
    }
}
