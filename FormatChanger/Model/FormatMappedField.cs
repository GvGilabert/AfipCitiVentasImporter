namespace FormatChanger.Model
{
    class FormatMappedField
    {
        public int Id { get; set; }
        public FieldFormat FieldFrom { get; set; }
        public FieldFormat FieldTo { get; set; }
        public FormatMapper Father { get; set; }
    }
}