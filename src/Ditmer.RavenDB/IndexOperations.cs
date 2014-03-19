using System.Linq;
using Ditmer.RavenDB.Domain;
using Ditmer.RavenDB.Indexes;
using Raven.Client;
using Xunit;

namespace Ditmer.RavenDB
{
    public class IndexOperations : IUseFixture<RavenDBFixture>
    {
        private IDocumentStore documentStore;

        public void SetFixture(RavenDBFixture data)
        {
            documentStore = data.DocumentStore;
        }

        [Fact]
        public void QuerySearchString()
        {
            using (var session = documentStore.OpenSession())
            {
                var student = session.Query<Student, StudentNameIndex>()
                    .Search(s => s.Name, "Mads Nielsen")
                    .ToList();
            }
        }

        [Fact]
        public void MapReduce()
        {
            using (var session = documentStore.OpenSession())
            {
                var firstNameStats = session.Query<StudentFirstNameOverview, FirstNameStudentIndex>()
                    .ToList();
            }
        }

        [Fact]
        public void Transform()
        {
            using (var session = documentStore.OpenSession())
            {
                var firstNameStats = session.Query<StudentFirstNameOverview, FirstNameStudentIndex>()
                    .TransformWith<FirstNameStudentTransformation, StudentFirstNameOverview2>()
                    .ToList();
            }
        }
    }
}