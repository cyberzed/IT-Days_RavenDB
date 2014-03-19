using System.Linq;
using Ditmer.RavenDB.Domain;
using Raven.Client;
using Xunit;

namespace Ditmer.RavenDB
{
    public class BasicRavenDBOperations : IUseFixture<RavenDBFixture>
    {
        private IDocumentStore documentStore;

        public void SetFixture(RavenDBFixture data)
        {
            documentStore = data.DocumentStore;
        }

        [Fact]
        public void Insert()
        {
            using (var session = documentStore.OpenSession())
            {
                var student = new Student
                {
                    Name = "Stefan Poulsen",
                    Age = 34
                };

                session.Store(student);

                session.SaveChanges();
            }
        }

        [Fact]
        public void Load()
        {
            using (var session = documentStore.OpenSession())
            {
                var student = session.Load<Student>(1);
            }
        }

        [Fact]
        public void Query()
        {
            using (var session = documentStore.OpenSession())
            {
                var students = (from s in session.Query<Student>()
                                where
                                    s.Age > 25
                                select s).ToList();
            }
        }

        [Fact]
        public void QueryOnString()
        {
            using (var session = documentStore.OpenSession())
            {
                var student = (from s in session.Query<Student>()
                               where
                                   s.Name.Equals("Mads Nielsen")
                               select s).SingleOrDefault();
            }
        }

        [Fact]
        public void QueryWithContains()
        {
            using (var session = documentStore.OpenSession())
            {
                var student = (from s in session.Query<Student>()
                               where
                                   s.Name.Contains("Mads")
                               select s).SingleOrDefault();
            }
        }

        [Fact]
        public void Delete()
        {
            using (var session = documentStore.OpenSession())
            {
                var student = new Student
                {
                    Name = "Stefan Poulsen",
                    Age = 34
                };

                session.Store(student);

                session.SaveChanges();
            }

            using (var session = documentStore.OpenSession())
            {
                var student = session.Load<Student>(1);

                session.Delete(student);

                session.SaveChanges();
            }
        }
    }
}