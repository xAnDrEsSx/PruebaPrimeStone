using Common.ApplicationModel;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;

namespace Test.Web.Helpers
{
    public class EnrollVM
    {
        public bool Consult { get; set; } = false;
        public StudentAM StudentAM { get; set; }
        public List<CourseAM> ListCourses { get; set; }
    }

    public class EnrollRequestVM
    {
        public int IdCourse { get; set; }
        public int IdStudent { get; set; }
    }

}
