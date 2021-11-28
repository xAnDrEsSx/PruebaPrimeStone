using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;
using Test.Domain.Administration.Repository.Interface;

namespace Test.Domain.Administration.Repository.RepositoryDBO
{
    public class EnrollRepository : IEnrollRepository<Enroll>
    {
        protected readonly TestContext context = null;

        public EnrollRepository(TestContext context)
        {
            this.context = context;
        }

        public void Create(Enroll Enroll)
        {
            try
            {
                context.Enrolls.Add(Enroll);
                context.SaveChanges();
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
                var Enroll = GetById(Id);

                if (Enroll == null)
                {
                    throw new NullReferenceException("La matricula no existe.");
                }

                context.Enrolls.Remove(Enroll);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        public Enroll GetById(int Id)
        {
            return context.Enrolls.FirstOrDefault(x => x.Id == Id && x.Active == true);
        }

        public ICollection<Enroll> GetEnrollsByIdStudent(int IdStudent)
        {
            return context.Enrolls
                    .Include(x => x.Course)
                    .Where(x => x.IdStudent == IdStudent && x.Active == true).ToList();
        }

        public Enroll GetEnroll(int IdStudent, int IdCourse)
        {
            return context.Enrolls
                    .Include(x => x.Course)
                    .Where(x => x.IdStudent == IdStudent && x.Active == true).FirstOrDefault();
        }

    }
}