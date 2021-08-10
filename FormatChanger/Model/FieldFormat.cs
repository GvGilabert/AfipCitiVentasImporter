using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.Model
{
    class FieldFormat
    {
        public int Id { get; set; }
        public Format Father { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int? Length { get; set; }
        public char? PaddingChar { get; set; }
        public string StringFormatter { get; set; }
        public string DefaultValue { get; set; }

    }

}
