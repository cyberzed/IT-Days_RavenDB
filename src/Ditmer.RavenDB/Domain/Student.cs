using System.Diagnostics;

namespace Ditmer.RavenDB.Domain
{
    [DebuggerDisplay("Id: {Id}; Name: {Name}")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}