using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.Model
{
    class SavedRow
    {
        public int Id { get; set; }
        public ICollection<SavedField> SavedFields { get; set; }
    }
}
