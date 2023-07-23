using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;
using Test.Domain.Administration.Repository.Interface;

namespace Test.Domain.Administration.Repository.RepositoryDBO
{
    public class CourseRepository : ICourseRepository<Course>
    {

        protected readonly TestContext context = null;

        public CourseRepository(TestContext context)
        {
            this.context = context;
        }

        public void Create(Course course)
        {
            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public void Update(Course course)
        {
            try
            {
                foreach (var _entity in context.ChangeTracker.Entries())
                {
                    _entity.State = EntityState.Detached;
                }
                context.Courses.Update(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var course = GetById(Id);

                if (course == null)
                {
                    throw new NullReferenceException("El curso no existe.");
                }

                context.Courses.Remove(course);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public ICollection<Course> Get()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int Id)
        {
            return context.Courses.FirstOrDefault(x => x.Id == Id);
        }

    }
}
