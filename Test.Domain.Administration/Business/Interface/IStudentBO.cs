using Common.ApplicationModel;
using System;
using System.Collections.Generic;
using Test.Domain.Administration.Entities;

namespace Test.Domain.Administration.Business.Interface
{
    public interface IStudentBO
    {
        public List<StudentAM> GetAll();
        public StudentAM GetStudentById(int Id);
        public StudentAM GetStudentByDocumentNumber(int documentNumber);       
        public Tuple<bool, Student> AddStudent(StudentAM student);
        public Tuple<bool, Student> UpdateStudent(StudentAM student);
        public bool DeleteStudent(int Id);
        public bool ExistStudent(int Id);
        public bool ExistDocument(int documentNumber);
    }
}
