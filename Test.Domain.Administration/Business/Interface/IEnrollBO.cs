using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Test.Domain.Administration.Business.Interface
{
    public interface IEnrollBO 
    {
        public Tuple<bool, Enroll> AddEnroll(EnrollAM enrollAM);

        public bool ExistEnroll(int Id);

        public bool DeleteEnroll(int Id);

        public List<EnrollAM> GetAllEnrollsByStudent(int IdStudent);


        public EnrollAM GetEnroll(int IdStudent, int IdCourse);

    }
}
