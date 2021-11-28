using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;

namespace Test.Domain.Administration.Repository.Interface
{
    public interface IEnrollRepository<Enroll>
    {
        public void Create(Enroll Enroll);

        public void Delete(int Id);

        public Enroll GetById(int Id);

        public ICollection<Enroll> GetEnrollsByIdStudent(int IdStudent);

        public Enroll GetEnroll(int IdStudent, int IdCourse);
    }
}
