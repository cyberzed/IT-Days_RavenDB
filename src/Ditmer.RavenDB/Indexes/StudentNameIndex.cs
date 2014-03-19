using System.Linq;
using Ditmer.RavenDB.Domain;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Ditmer.RavenDB.Indexes
{
    public class StudentNameIndex : AbstractIndexCreationTask<Student>
    {
        public StudentNameIndex()
        {
            Map = docs => from d in docs select new {d.Name};

            Index(s => s.Name, FieldIndexing.Analyzed);
        }
    }
}