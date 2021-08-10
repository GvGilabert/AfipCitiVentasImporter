using FormatChanger.ContextData;
using FormatChanger.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormatChanger
{
    class Program
    {

        static void Main(string[] args)
        {
           // GenerateComprasTest();
            //GenerateComprasAlicuotasTest();
            //GenerateVentasTest();
            GenerateVentasAlicuotasTest();
        }



        public static void GenerateVentasTest()
        {
            ContextSets db = new ContextSets();

            //1 Levanto el formato y con el levanto el csv y lo paso a SAVED EXPORT
            var format = db.Formats.Include(f => f.Fields).Where(x => x.Id == 2).FirstOrDefault(); //FORMATO ARCHIVO ENTRADA
            var fm = new FileManager(@"D:\Desktop\FORMAT CHANGER\012017Ventas.csv", format, _hasHeader: true);
            SavedExport openeFile = fm.MapFile("ventasEne20202"); //ARCHIVO DE ENTRADA

            var destinationFormat = db.Formats.Include(f => f.Fields).Where(x => x.Id == 5).FirstOrDefault(); //FORMATO ARCHIVO SALIDA

            var converter = db.FormatMapper.Include(fm => fm.MappingFields).Where(f => f.Id == 3).FirstOrDefault(); //FORMATO DE MAPEO


            var r = converter.MapFile(openeFile, destinationFormat, new CitiComprasVentasModule.CitiComprasVentasModule());
            db.SavedExports.AddRange(r);
            db.SaveChanges();

            //

            var savedFile = db.SavedExports
                                            .Include(i => i.SavedRows)
                                            .ThenInclude(ti => ti.SavedFields)
                                            .Include(i1 => i1.Format)
                                            .ThenInclude(ti1 => ti1.Fields)
                                            .OrderBy(i => i.Id)
                                            .Last();
            savedFile.GenerateTxt(@"D:\Desktop\FORMAT CHANGER\VentasEne20217.txt");

            Console.WriteLine();
        }

        public static void GenerateVentasAlicuotasTest()
        {
            ContextSets db = new ContextSets();

            //1 Levanto el formato y con el levanto el csv y lo paso a SAVED EXPORT
            var format = db.Formats.Include(f => f.Fields).Where(x => x.Id == 2).FirstOrDefault(); //FORMATO ARCHIVO ENTRADA

            var fm = new FileManager(@"D:\Desktop\FORMAT CHANGER\012017Ventas.csv", format, _hasHeader: true); //INSTANCIA FILE MANAGER

            SavedExport openeFile = fm.MapFile("ventasEne20202"); //ARCHIVO DE ENTRADA

            var destinationFormat = db.Formats.Include(f => f.Fields).Where(x => x.Id == 6).FirstOrDefault(); //FORMATO ARCHIVO SALIDA

            var converter = db.FormatMapper.Include(fm => fm.MappingFields).Where(f => f.Id == 4).FirstOrDefault(); //FORMATO DE MAPEO


            var r = converter.MapFile(openeFile, destinationFormat, new CitiComprasVentasModule.CitiComprasVentasModule()); //MAPEO
            db.SavedExports.AddRange(r);
            db.SaveChanges();

            //

            var savedFile = db.SavedExports
                                            .Include(i => i.SavedRows)
                                            .ThenInclude(ti => ti.SavedFields)
                                            .Include(i1 => i1.Format)
                                            .ThenInclude(ti1 => ti1.Fields)
                                            .OrderBy(i => i.Id)
                                            .Last();
            savedFile.GenerateTxt(@"D:\Desktop\FORMAT CHANGER\VentasEneroAlicuotas20217.txt");

            Console.WriteLine();
        }



        public static void GenerateComprasTest()
        {
            ContextSets db = new ContextSets();

            //1 Levanto el formato y con el levanto el csv y lo paso a SAVED EXPORT
            var format = db.Formats.Include(f => f.Fields).Where(x => x.Id == 1).FirstOrDefault();
            var fm = new FileManager(@"D:\Desktop\FORMAT CHANGER\ComprasFeb20217.csv", format, true);
            SavedExport openeFile = fm.MapFile("comprasFeb20202"); //ARCHIVO DE ENTRADA

            var destinationFormat = db.Formats.Include(f => f.Fields).Where(x => x.Id == 3).FirstOrDefault();


            db.SaveChanges();
            //var f = format.Fields.Where(f => f.Name.StartsWith('I')).FirstOrDefault();

            //Console.WriteLine(f.Name);


            var converter = db.FormatMapper.Include(fm => fm.MappingFields).Where(f => f.Id == 1).FirstOrDefault(); //FORMATO DE MAPEO


            var r = converter.MapFile(openeFile, destinationFormat, new CitiComprasVentasModule.CitiComprasVentasModule());
            db.SavedExports.AddRange(r);
            db.SaveChanges();

            //

            var savedFile = db.SavedExports
                                            .Include(i => i.SavedRows)
                                            .ThenInclude(ti => ti.SavedFields)
                                            .Include(i1 => i1.Format)
                                            .ThenInclude(ti1 => ti1.Fields)
                                            .OrderBy(i => i.Id)
                                            .Last();
            savedFile.GenerateTxt(@"D:\Desktop\FORMAT CHANGER\ComprasFeb20217.txt");

            // var compras = new CitiComprasVentasModule.ComprasModule(openeFile.SavedRows.Where(sr=>sr.);
            //compras.SetValues(savedFile.SavedRows.ToList());
            savedFile.GenerateTxt(@"D:\Desktop\FORMAT CHANGER\ComprasFeb20217-2.txt");

            Console.WriteLine();
        }

        public static void GenerateComprasAlicuotasTest()
        {
            ContextSets db = new ContextSets();

            //1 Levanto el formato y con el levanto el csv y lo paso a SAVED EXPORT
            var format = db.Formats.Include(f => f.Fields).Where(x => x.Id == 1).FirstOrDefault();
            var fm = new FileManager(@"D:\Desktop\FORMAT CHANGER\ComprasFeb20217.csv", format, true);
            SavedExport openeFile = fm.MapFile("comprasFeb20202"); //ARCHIVO DE ENTRADA

            var destinationFormat = db.Formats.Include(f => f.Fields).Where(x => x.Id == 4).FirstOrDefault();
            db.SaveChanges();

            var converter = db.FormatMapper.Include(fm => fm.MappingFields).Where(f => f.Id == 2).FirstOrDefault(); //FORMATO DE MAPEO


            var r = converter.MapFile(openeFile, destinationFormat, new CitiComprasVentasModule.CitiComprasVentasModule());
            db.SavedExports.AddRange(r);
            db.SaveChanges();

            //

            var savedFile = db.SavedExports
                                            .Include(i => i.SavedRows)
                                            .ThenInclude(ti => ti.SavedFields)
                                            .Include(i1 => i1.Format)
                                            .ThenInclude(ti1 => ti1.Fields)
                                            .OrderBy(i => i.Id)
                                            .Last();
            savedFile.GenerateTxt(@"D:\Desktop\FORMAT CHANGER\ComprasAlicuotaFeb20217.txt");
            Console.WriteLine();
        }
    }
}
