using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;

namespace csharp_4
{
    class Program
    {
        static void Main(string[] args)
        {

            UseDynamic();
            UseDynamicInsteadOfReflection();
            UseRuby();
            ReadXml();            
            ReadXmlDynamic().ToList();
            UseExpando();            
            ReadXmlExpando().ToList();
            ExcelInterop();
            Variance();
            Plinq();
            UseTpl();
        }

        private static void UseTpl()
        {
            var people = ReadXml();

            Parallel.ForEach(people, 
                    p =>
                    {
                        p.Name = p.Name.ToUpper();
                    });


            Task<IEnumerable<Person>>[] filters = new Task<IEnumerable<Person>>[]
            {
                Task<IEnumerable<Person>>.Factory.StartNew(
                    () => people.Where(p=>p.Country=="France")),
                Task<IEnumerable<Person>>.Factory.StartNew(
                    () => people.Where(p=>p.Country == "Germany")),
                Task<IEnumerable<Person>>.Factory.StartNew(
                    () => people.Where(p=>p.Country == "Sweden")),
            };

            var results = filters.SelectMany(filter => filter.Result);
            foreach (var result in results)
            {
                Console.WriteLine(result.Name);
            }
        }

        private static void Plinq()
        {
            var canadians = ReadXml().AsParallel()
                                     .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                                     .Where(person => person.Country == "Canada");            
        }

        private static void Variance()
        {
            IEnumerable<Person> people = CreatePeople();
            
            // error in C# 3.0
            ProcessAnimals(people);   
            
            // error in C# 3.0
            Func<IEnumerable<Animal>> createAnimals = CreatePeople; 
        }

        static void ProcessAnimals(IEnumerable<Animal> animals)
        {

        }

        static IEnumerable<Person> CreatePeople()
        {
            // ...
            return Enumerable.Empty<Person>();
        }        

        private static void UseExpando()
        {
            dynamic person = new ExpandoObject();
            person.Name = "Poonam";
            person.Country = "India";

            var dictionary = person as IDictionary<string, object>;
            var name = dictionary["Name"] as string;
            name = person.Name;

        }

        private static IEnumerable<Person> ReadXmlExpando()
        {            
            var doc = XDocument.Load("People.xml").AsExpando();
            foreach(var record in doc.Records)
            {
                yield return new Person() {Name = record.Name, Country = record.Country};
            }            
        }

        private static void UseRuby()
        {
            var engine = IronRuby.Ruby.CreateEngine();
            engine.Runtime.Globals.SetVariable("Vip", new Person { Name="Fritz", Country="USA"});
            engine.ExecuteFile("Person.rb");
            
            dynamic ruby = engine.Runtime.Globals;
            dynamic person = ruby.Person.@new("Scott", "USA");
            person.SayName();
        }

        private static IEnumerable<Person> ReadXmlDynamic()
        {
            dynamic document = new DynamicXml("people.xml");
            foreach (var record in document.Records)
            {
                yield return new Person { Name = record.Name, Country = record.Country };
            }
        }
      
        private static IEnumerable<Person> ReadXml()
        {
            return
                XDocument.Load("People.xml")
                         .Element("Records")
                         .Elements("Record")
                         .Select(r => new Person
                           {
                               Name = r.Element("Name").Value,
                               Country = r.Element("Country").Value
                           });
        }

        private static void DoWork(bool workHarder = false, int numberHours = 8)
        {
            // ...
        }

        private static void ExcelInterop()
        {
            var app = new Application { Visible = true };
            var workbook = app.Workbooks.Add();
            var sheet = (Worksheet)workbook.ActiveSheet; // ActiveSheet returns dynamic
            sheet.Cells[1, 1] = "Name";
            sheet.Cells[1, 2] = "Country";

            int row = 2;
            foreach (var person in ReadXml())
            {
                sheet.Cells[row, 1] = person.Name;
                sheet.Cells[row, 2] = person.Country;
                ++row;
            }

            var range = sheet.Range["A1", "B1"];
            range.Font.Bold = true;
            range.EntireColumn.AutoFit();

            //sheet.SaveAs("people.xls", Missing.Value, Missing.Value, Missing.Value,
            //             Missing.Value, false, Missing.Value, Missing.Value,
            //             Missing.Value, Missing.Value);

            sheet.SaveAs("people.xls", AddToMru:false); 
            
            app.Quit();
        }

        private static void UseDynamicInsteadOfReflection()
        {
            object person = FetchObject();
            person.GetType().GetMethod("SayName").Invoke(person, null);

            dynamic dynamicPerson = FetchObject();
            dynamicPerson.SayName();
        }

        private static object FetchObject()
        {
            return new Person { Name = "Scott", Country = "USA" };
        }

        private static void UseDynamic()
        {
            dynamic name = "Scott";

            int length = name.Length;
            //int error = name.Capitalize(); // compiles, but runtime exception!
        }
    }
}

