using Common.ApplicationModel;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Test.Domain.Administration.Business.Profile
{

    /// <summary>
    /// Perfil para el mapeo de entidades de base de datos
    /// </summary>
    public class AdministracionProfile : AutoMapper.Profile
    {
        public AdministracionProfile()
        {
            CreateMap<Student, StudentAM>().ReverseMap();
            CreateMap<Course, CourseAM>().ReverseMap();
            CreateMap<Address, AddressAM>().ReverseMap();
            CreateMap<Enroll, EnrollAM>().ReverseMap();
        }
    }
}
