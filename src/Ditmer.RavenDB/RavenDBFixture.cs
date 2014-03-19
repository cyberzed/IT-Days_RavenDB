using System.Linq;
using System.Threading;
using Ditmer.RavenDB.Domain;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace Ditmer.RavenDB
{
    public class RavenDBFixture
    {
        public RavenDBFixture()
        {
            DocumentStore = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            DocumentStore.Initialize();

            IndexCreation.CreateIndexes(typeof (RavenDBFixture).Assembly, DocumentStore);

            var students = StudentGenerator.Generate();

            using (var session = DocumentStore.OpenSession())
            {
                foreach (var student in students)
                {
                    session.Store(student);
                }

                session.SaveChanges();
            }

            while (DocumentStore.DatabaseCommands.GetStatistics().StaleIndexes.Any())
            {
                Thread.Sleep(50);
            }
        }

        public IDocumentStore DocumentStore { get; private set; }
    }
}