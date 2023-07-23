using System.Collections.Generic;

namespace Test.Domain.Administration.Repository.Interface
{
    public interface IStudentRepository<Student>
    {
        public void Create(Student Student);
        public void Update(Student Student);
        public void Delete(int Id);
        public ICollection<Student> Get();
        public Student GetById(int Id);
        public Student GetByDocumentNumber(int documentNumber);
    }
}
