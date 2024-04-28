using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DyeNamesTest.Objects;

namespace DyeNamesTest.File_IO
{
    public class NameExporter
    {
        /// <summary>
        /// This exports a list of names to an external file
        /// </summary>
        public static void exportNames(List<FullName> names, string filename)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filename))
                {
                    foreach (FullName fullName in names)
                    {
                        file.WriteLine(fullName);
                        Console.WriteLine(fullName);
                    }
                }
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Error writing file contents");
            }
        }
    }
}
