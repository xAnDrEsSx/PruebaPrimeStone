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
    public class StudentRepository : IStudentRepository<Student>
    {

        protected readonly TestContext context = null;

        public StudentRepository(TestContext context)
        {
            this.context = context;
        }

        public void Create(Student Student)
        {
            try
            {
                context.Students.Add(Student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public void Update(Student Student)
        {
            try
            {
                foreach (var _entity in context.ChangeTracker.Entries())
                {
                    _entity.State = EntityState.Detached;
                }
                context.Students.Update(Student);
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
                var Student = GetById(Id);

                if (Student == null)
                {
                    throw new NullReferenceException("El estudiante no existe.");
                }

                context.Students.Remove(Student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public ICollection<Student> Get()
        {
            return context.Students
                .ToList();
        }

        public Student GetById(int Id)
        {
            return context.Students.FirstOrDefault(x => x.Id == Id && x.Active == true);
        }

        public Student GetByDocumentNumber(int documentNumber)
        {
            return context.Students.FirstOrDefault(x => x.DocumentNumber == documentNumber && x.Active == true);
        }
    }
}
