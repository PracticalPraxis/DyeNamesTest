using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DyeNamesTest.Objects;

namespace DyeNamesTest.File_IO
{
    /// <summary>
    /// This imports a list of names from a text file
    /// </summary>
    public class NameImporter
    {
        public static List<FullName> importNames(string filename)
        {
            String invalidNamesFileMessage = "Filename invalid.";
            String[] inputNames;
            // Symbol used to separate names in file - change to ',' for CSV files

            try
            {
                inputNames = File.ReadAllLines(filename);
            }
            catch (Exception e)
            {
                throw new ArgumentException(invalidNamesFileMessage, e);
            }

            List<FullName> fullNames = ReadLinesToFullName(inputNames);

            return fullNames;
        }

        /// <summary>
        /// Conver input String Array to List of FullName objects
        /// </summary>
        public static List<FullName> ReadLinesToFullName(String[] inputNames)
        {
            String invalidNameMessage = "First or last name missing for name: ";
            List<FullName> fullNames = new List<FullName>();
            char separatorSymbol = ' ';
            int lastSpace = 0;

            for (int i = 0; i < inputNames.Length; ++i)
            {
                string name = inputNames[i];
                if (name.Trim() == "" && i == inputNames.Length - 1)
                {
                    break;
                }
                lastSpace = name.LastIndexOf(separatorSymbol);
                if (lastSpace < 1)
                {
                    throw new ArgumentException(invalidNameMessage + name);
                }

                // Use substrings to get multiple first names if present
                string firstNames = name.Substring(0, lastSpace);
                string lastName = name.Substring(lastSpace + 1);

                fullNames.Add(new FullName(firstNames, lastName));
            }

            return fullNames;
        }
    }
}
