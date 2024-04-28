using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DyeNamesTest.Objects
{
    public class Sorter
    {
        /// <summary>
        /// This method checks that a list of names contain only Alphanumeric characters
        /// </summary>
        public static bool CheckIsAlphanumericOrAllowedChars(List<FullName> inputNames)
        {
            // Declare Regex allowing alphanumeric as well as ' ' and '-'
            Regex allowedCharacters = new Regex("^[a-zA-Z0-9\\s\\-]+$");

            foreach (FullName fullName in inputNames)
            {
                if (!allowedCharacters.IsMatch(fullName.firstNames) || !allowedCharacters.IsMatch(fullName.lastName))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// This method checks that a given name contains only Alphanumeric characters
        /// </summary>
        public static bool CheckIsAlphanumericOrAllowedChars(FullName inputName)
        {
            // Declare Regex allowing alphanumeric as well as ' ' and '-'
            Regex allowedCharacters = new Regex("^[a-zA-Z0-9\\s\\-]+$");

            if (!allowedCharacters.IsMatch(inputName.firstNames) || !allowedCharacters.IsMatch(inputName.lastName))
            {
                    return false;
            }
            return true;
        }

        /// <summary>
        /// This method encapsulates a LINQ query that sorts names by last and then first name
        /// </summary>
        public static List<FullName> SortNames(List<FullName> inputNames)
        {
            return inputNames.OrderBy(inputName => inputName.lastName)
                                 .ThenBy(inputName => inputName.firstNames)
                                 .ToList();
        }
    }
}
