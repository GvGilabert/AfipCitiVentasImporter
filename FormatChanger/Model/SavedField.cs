using System;

namespace FormatChanger.Model
{
    class SavedField
    {
        public int Id { get; set; }
        public FieldFormat FieldFormat { get; set; }
        public string Value { get; set; }
    }
}