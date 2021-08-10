using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.Model
{
    class Format
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<FieldFormat> Fields { get; set; }
        public char? Delimiter { get; set; }

    }
}
