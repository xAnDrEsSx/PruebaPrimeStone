using System.Collections.Generic;

namespace Test.Domain.Administration.Repository.Interface
{
    public interface ICourseRepository<Course>
    {
        public void Create(Course course);
        public void Update(Course course);
        public void Delete(int Id);
        public ICollection<Course> Get();
        public Course GetById(int Id);
    }
}
