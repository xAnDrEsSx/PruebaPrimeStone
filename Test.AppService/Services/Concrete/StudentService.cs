using Common.ApplicationModel;
using Test.AppService.Services.Contracts;
using Test.Domain.Administration.Context;

namespace Test.AppService.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly TestContext context;

        public StudentService(TestContext context)
        {
            this.context = context;
        }

        public int AddStudent(StudentAM studentAM)
        {
            throw new System.NotImplementedException();
        }
    }

}
