using System;
using System.Collections.Generic;

namespace Ditmer.RavenDB.Domain
{
    public static class StudentGenerator
    {
        public static IEnumerable<Student> Generate()
        {
            var rnd = new Random();

            var firstNames = new[] {"Mads", "Britta", "Peter", "Hanne", "Knud"};

            var lastNames = new[] {"Nielsen", "Petersen", "Johnsen", "Hansen"};

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    yield return new Student
                    {
                        Name = string.Format("{0} {1}", firstName, lastName),
                        Age = rnd.Next(20, 36)
                    };
                }
            }
        }
    }
}