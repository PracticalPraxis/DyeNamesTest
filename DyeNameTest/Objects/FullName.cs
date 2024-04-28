using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeNamesTest.Objects
{
    public class FullName
    {
        public string firstNames { get; }
        public string lastName { get; }
        public FullName(string firstNames, string lastName)
        {
            this.firstNames = firstNames;
            this.lastName = lastName;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            FullName fullName = (FullName)obj;

            return firstNames == fullName.firstNames && lastName == fullName.lastName;
        }
        public override int GetHashCode() => firstNames.GetHashCode() * 97 + lastName.GetHashCode();

        public override string ToString() => $"{firstNames} {lastName}";


    }
}
