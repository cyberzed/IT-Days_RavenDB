using System.Linq;
using Raven.Client.Indexes;

namespace Ditmer.RavenDB.Indexes
{
    public class FirstNameStudentTransformation : AbstractTransformerCreationTask<StudentFirstNameOverview>
    {
        public FirstNameStudentTransformation()
        {
            TransformResults = results => from r in results
                                          select new
                                          {
                                              Fornavn = r.FirstName,
                                              Antal = r.Count
                                          };
        }
    }
}