using FormatChanger.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatChanger.ContextData
{
    class ContextSets : DbContext
    {
        public DbSet<FieldFormat> FieldFormats { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<FormatMapper> FormatMapper { get; set; }
        public DbSet<FormatMappedField> FormatMappedField { get; set; }
        public DbSet<SavedExport> SavedExports { get; set; }
        public DbSet<SavedField> SavedFields { get; set; }
        public string DbPath { get; private set; }

        public ContextSets()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}conversions.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
