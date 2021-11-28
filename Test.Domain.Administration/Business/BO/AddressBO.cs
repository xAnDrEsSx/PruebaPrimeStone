using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Business.Interface;
using Test.Domain.Administration.Business.Profile;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;
using Test.Domain.Administration.Repository.Interface;
using Test.Domain.Administration.Repository.RepositoryDBO;

namespace Test.Domain.Administration.Business.BO
{
    public class AddressBO : IAddressBO
    {
        private readonly TestContext context;
        private readonly ILoggerManager _logger;
        private readonly IMapper mapper;

        public AddressBO(TestContext context, ILoggerManager logger)
        {
            this.context = context;
            _logger = logger;
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile<AdministracionProfile>();
            });
            mapper = new Mapper(mapConfig);
        }

        public List<AddressAM> GetAddressByStudent(int IdStudent)
        {
            try
            {
                _logger.LogInformation(String.Concat("Consumiendo GetAddressByStudent: ", IdStudent));

                IAddressRepository<Address> AddressRepository = new AddressRepository(context);
                var address = AddressRepository.GetById(IdStudent);
                return mapper.Map<List<AddressAM>>(address);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error GetAddressByStudent", ex);
                return null;
            }
        }

        public Tuple<bool, Address> AddAddress(AddressAM addressAM)
        {
            try
            {
                IAddressRepository<Address> AddressRepository = new AddressRepository(context);
                var address = mapper.Map<Address>(addressAM);
                AddressRepository.Create(address);
                context.SaveChanges();
                return new Tuple<bool, Address>(true, address);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error AddAddress", ex);
                return new Tuple<bool, Address>(false, null);
            }

        }

    }
}