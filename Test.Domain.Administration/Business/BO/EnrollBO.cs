using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Business.Interface;
using Test.Domain.Administration.Business.Profile;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;
using Test.Domain.Administration.Repository.Interface;
using Test.Domain.Administration.Repository.RepositoryDBO;

namespace Test.Domain.Administration.Business.BO
{
    public class EnrollBO : IEnrollBO
    {
        private readonly TestContext context;
        private readonly IMapper mapper;
        public readonly ILoggerManager _logger;

        public EnrollBO(TestContext context, ILoggerManager logger)
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

        public Tuple<bool, Enroll> AddEnroll(EnrollAM enrollAM)
        {
            try
            {
                IEnrollRepository<Enroll> EnrolRepository = new EnrollRepository(context);
                var enroll = mapper.Map<Enroll>(enrollAM);
                enroll.RegistrationDate = DateTime.Now;
                enroll.Active = true;
                EnrolRepository.Create(enroll);
                context.SaveChanges();
                return new Tuple<bool, Enroll>(true, enroll);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error AddEnroll", ex);
                return new Tuple<bool, Enroll>(false, null);
            }

        }

        public bool ExistEnroll(int Id)
        {
            try
            {
                return context.Enrolls.Any(e => e.Id == Id && e.Active == true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ExistEnroll", ex);
                return false;
            }
        }

        public bool DeleteEnroll(int Id)
        {
            try
            {
                IEnrollRepository<Enroll> EnrolRepository = new EnrollRepository(context);
                EnrolRepository.Delete(Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error DeleteEnroll", ex);
                return false;
            }
        }

        public List<EnrollAM> GetAllEnrollsByStudent(int IdStudent)
        {
            try
            {
                _logger.LogInformation(String.Concat("Consumiendo servicio GetAllEnrollsByStudent: ", IdStudent));
                IEnrollRepository<Enroll> EnrolRepository = new EnrollRepository(context);
                var enroll = EnrolRepository.GetEnrollsByIdStudent(IdStudent);
                return mapper.Map<List<EnrollAM>>(enroll);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error GetAllEnrollsByStudent", ex);
                return null;
            }
        }

        public EnrollAM GetEnroll(int IdStudent, int IdCourse)
        {
            IEnrollRepository<Enroll> EnrolRepository = new EnrollRepository(context);
            var enroll = EnrolRepository.GetEnroll(IdStudent, IdCourse);
            return mapper.Map<EnrollAM>(enroll);
        }

    }
}