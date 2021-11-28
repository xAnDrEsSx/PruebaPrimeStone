using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Common.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Domain.Administration.Business.Interface;
using Test.Domain.Administration.Business.Profile;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;
using Test.Domain.Administration.Repository.Interface;
using Test.Domain.Administration.Repository.RepositoryDBO;

namespace Test.Domain.Administration.Business.BO
{
    public class StudentBO : IStudentBO
    {
        private readonly TestContext context;
        private readonly IMapper mapper;
        public readonly ILoggerManager _logger;

        public StudentBO(TestContext context, ILoggerManager logger)
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

        public List<StudentAM> GetAll()
        {
            _logger.LogInformation("Consumo Servicio GetAll Students");
            IStudentRepository<Student> StudentRepository = new StudentRepository(context);
            var students = StudentRepository.Get();
            return mapper.Map<List<StudentAM>>(students);
        }

        public StudentAM GetStudentById(int Id)
        {
            IStudentRepository<Student> StudentRepository = new StudentRepository(context);
            var students = StudentRepository.GetById(Id);
            return mapper.Map<StudentAM>(students);
        }

        public StudentAM GetStudentByDocumentNumber(int documentNumber)
        {
            IStudentRepository<Student> StudentRepository = new StudentRepository(context);
            var students = StudentRepository.GetByDocumentNumber(documentNumber);
            return mapper.Map<StudentAM>(students);
        }

        public Tuple<bool, Student> AddStudent(StudentAM studentAM)
        {
            try
            {
                IStudentRepository<Student> StudentRepository = new StudentRepository(context);
                var student = mapper.Map<Student>(studentAM);
                StudentRepository.Create(student);
                context.SaveChanges();
                return new Tuple<bool, Student> (true, student);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error AddStudent",ex);
                return new Tuple<bool, Student>(false, null);
            }

        }

        public Tuple<bool, Student> UpdateStudent(StudentAM studentAM)
        {
            try
            {
                IStudentRepository<Student> StudentRepository = new StudentRepository(context);
                var student = mapper.Map<Student>(studentAM);
                StudentRepository.Update(student);
                context.SaveChanges();
                return new Tuple<bool, Student>(true, student);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error UpdateStudent", ex);
                return new Tuple<bool, Student>(false, null);
            }

        }

        public bool DeleteStudent(int Id)
        {
            try
            {
                IStudentRepository<Student> StudentRepository = new StudentRepository(context);
                StudentRepository.Delete(Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error DeleteStudent", ex);
                return false;
            }
        }

        public bool ExistStudent(int Id)
        {
            try
            {
                return context.Students.Any(e => e.Id == Id && e.Active == true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ExistStudent", ex);
                return false;
            }
        }

        public bool ExistDocument(int documentNumber)
        {
            try
            {
                return context.Students.Any(e => e.DocumentNumber == documentNumber && e.Active == true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ExistDocument", ex);
                return false;
            }
        }

    }
}