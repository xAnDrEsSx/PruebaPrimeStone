using Common.ApplicationModel;
using Common.Services.Contracts;
using System;
using System.Collections.Generic;
using Test.Domain.Administration;
using Test.Domain.Administration.Business.BO;
using Test.Domain.Administration.Business.Interface;
using Test.Domain.Administration.Context;
using Test.Domain.Administration.Entities;

namespace Common.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly TestContext context;
        private readonly ILoggerManager logger;

        public StudentService(TestContext context, ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<StudentAM> GetAll()
        {
            try
            {
                IStudentBO students = new StudentBO(context,logger);
                return students.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public StudentAM GetStudentById(int Id)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.GetStudentById(Id);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public StudentAM GetStudentByDocumentNumber(int documentNumber)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.GetStudentByDocumentNumber(documentNumber);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Tuple<bool, Student> AddStudent(StudentAM student)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.AddStudent(student);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Tuple<bool, Student> UpdateStudent(StudentAM student)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.UpdateStudent(student);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteStudent(int Id)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.DeleteStudent(Id);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ExistStudent(int Id)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.ExistStudent(Id);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ExistDocument(int documentNumber)
        {
            try
            {
                IStudentBO students = new StudentBO(context, logger);
                return students.ExistDocument(documentNumber);
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
