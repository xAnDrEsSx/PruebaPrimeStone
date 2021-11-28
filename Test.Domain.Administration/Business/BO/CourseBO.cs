using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Common.ApplicationModel;
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
    public class CourseBO : ICourseBO
    {
        private readonly TestContext context;
        private readonly IMapper mapper;
        public readonly ILoggerManager _logger;

        public CourseBO(TestContext context, ILoggerManager logger)
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

        public List<CourseAM> GetAll()
        {
            _logger.LogInformation("Consumo Servicio GetAll Courses");
            ICourseRepository<Course> CourseRepository = new CourseRepository(context);
            var courses = CourseRepository.Get();
            return mapper.Map<List<CourseAM>>(courses);
        }

        public CourseAM GetCourseById(int Id)
        {
            _logger.LogInformation(String.Concat("Consumo Servicio GetCourseById: ", Id));
            ICourseRepository<Course> CourseRepository = new CourseRepository(context);
            var courses = CourseRepository.GetById(Id);
            return mapper.Map<CourseAM>(courses);
        }

        public Tuple<bool, Course> AddCourse(CourseAM courseAM)
        {
            try
            {
                ICourseRepository<Course> CourseRepository = new CourseRepository(context);
                var course = mapper.Map<Course>(courseAM);
                CourseRepository.Create(course);
                context.SaveChanges();
                return new Tuple<bool, Course>(true, course);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error AddCourse", ex);
                return new Tuple<bool, Course>(false, null);
            }

        }

        public Tuple<bool, Course> UpdateCourse(CourseAM courseAM)
        {
            try
            {
                ICourseRepository<Course> CourseRepository = new CourseRepository(context);
                var course = mapper.Map<Course>(courseAM);
                CourseRepository.Update(course);
                context.SaveChanges();
                return new Tuple<bool, Course>(true, course);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error UpdateCourse", ex);
                return new Tuple<bool, Course>(false, null);
            }

        }

        public bool DeleteCourse(int Id)
        {
            try
            {
                ICourseRepository<Course> CourseRepository = new CourseRepository(context);
                CourseRepository.Delete(Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error DeleteCourse", ex);
                return false;
            }
        }

        public bool ExistCourse(int Id)
        {
            try
            {
                return context.Courses.Any(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ExistCourse", ex);
                return false;
            }
        }

    }
}