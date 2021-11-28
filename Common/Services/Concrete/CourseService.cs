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
    public class CourseService : ICourseService
    {
        private readonly TestContext context;
        private readonly ILoggerManager logger;

        public CourseService(TestContext context, ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<CourseAM> GetAll()
        {
            try
            {
                ICourseBO course = new CourseBO(context,logger);
                return course.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CourseAM GetCourseById(int Id)
        {
            try
            {
                ICourseBO course = new CourseBO(context, logger);
                return course.GetCourseById(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tuple<bool, Course> AddCourse(CourseAM course)
        {
            try
            {
                ICourseBO courses = new CourseBO(context, logger);
                return courses.AddCourse(course);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Tuple<bool, Course> UpdateCourse(CourseAM course)
        {
            try
            {
                ICourseBO courses = new CourseBO(context, logger);
                return courses.UpdateCourse(course);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteCourse(int Id)
        {
            try
            {
                ICourseBO courses = new CourseBO(context, logger);
                return courses.DeleteCourse(Id);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ExistCourse(int Id)
        {
            try
            {
                ICourseBO courses = new CourseBO(context, logger);
                return courses.ExistCourse(Id);
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
