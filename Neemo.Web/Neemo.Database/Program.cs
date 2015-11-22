using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbUp;
using DbUp.Engine;

namespace Neemo.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? ConfigurationManager.ConnectionStrings["NeemoConnection"].ConnectionString;

            var upgrader = DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScripts(FromDirectory("Tables"))
                    .WithScripts(FromDirectory("Views"))
                    .WithScripts(FromDirectory("StoredProcedures"))
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }

        private static IEnumerable<SqlScript> FromDirectory(string directory)
        {
            var tables = Directory.GetFiles(directory, "*.sql");
            foreach (var tableScript in tables)
            {
                var file = new FileInfo(tableScript);
                yield return new SqlScript(file.Name, File.ReadAllText(tableScript));
            }
        }
    }
}
