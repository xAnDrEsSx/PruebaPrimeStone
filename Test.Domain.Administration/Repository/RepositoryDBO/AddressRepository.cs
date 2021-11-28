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
    public class AddressRepository : IAddressRepository<Address>
    {

        protected readonly TestContext context = null;

        public AddressRepository(TestContext context)
        {
            this.context = context;
        }

        public void Create(Address address)
        {
            try
            {
                context.Address.Add(address);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }

        //public void Update(Address course)
        //{
        //    try
        //    {
        //        foreach (var _entity in context.ChangeTracker.Entries())
        //        {
        //            _entity.State = EntityState.Detached;
        //        }
        //        context.Courses.Update(course);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + ex.InnerException?.Message);
        //    }
        //}

        //public void Delete(int Id)
        //{
        //    try
        //    {
        //        var course = GetById(Id);

        //        if (course == null)
        //        {
        //            throw new NullReferenceException("El curso no existe.");
        //        }

        //        context.Courses.Remove(course);
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + ex.InnerException?.Message);
        //    }
        //}

        //public ICollection<Address> Get()
        //{
        //    return context.Courses.ToList();
        //}

        public List<Address> GetById(int IdStudent)
        {
            return context.Address.Where(a => a.IdStudent == IdStudent).ToList();
        }

    }
}
