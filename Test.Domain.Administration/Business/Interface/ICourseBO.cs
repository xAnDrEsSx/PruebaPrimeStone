using Common.ApplicationModel;
using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Test.Domain.Administration.Business.Interface
{
    public interface ICourseBO
    {
        public List<CourseAM> GetAll();
        public CourseAM GetCourseById(int Id);
        public Tuple<bool, Course> AddCourse(CourseAM course);
        public Tuple<bool, Course> UpdateCourse(CourseAM course);
        public bool DeleteCourse(int Id);
        public bool ExistCourse(int Id);
    }
}
