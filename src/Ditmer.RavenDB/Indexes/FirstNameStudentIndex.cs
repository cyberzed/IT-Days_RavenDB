using System;
using System.Linq;
using Ditmer.RavenDB.Domain;
using Raven.Client.Indexes;

namespace Ditmer.RavenDB.Indexes
{
    public class FirstNameStudentIndex : AbstractIndexCreationTask<Student, StudentFirstNameOverview>
    {
        public FirstNameStudentIndex()
        {
            Map = docs => from d in docs
                          select new
                          {
                              FirstName = d.Name.Substring(0, d.Name.IndexOf(" ", StringComparison.Ordinal)),
                              Count = 1
                          };

            Reduce = results => from r in results
                                group r by r.FirstName
                                into gFirstName
                                select new
                                {
                                    FirstName = gFirstName.Key,
                                    Count = gFirstName.Sum(f => f.Count)
                                };
        }
    }
}