using Common.Services.Contracts;
using System;
using System.Collections.Generic;
using Test.Domain.Administration;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Business.BO;
using Test.Domain.Administration.Business.Interface;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;


namespace Common.Services.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly TestContext context;
        private readonly ILoggerManager logger;

        public AddressService(TestContext context,ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<AddressAM> GetAddressByStudent(int IdStudent)
        {
            try
            {
                IAddressBO address = new AddressBO(context,logger);
                return address.GetAddressByStudent(IdStudent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tuple<bool, Address> AddAddress(AddressAM address)
        {
            try
            {
                IAddressBO addresss = new AddressBO(context,logger);
                return addresss.AddAddress(address);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
