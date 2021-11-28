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
    public class EnrollSerivce : IEnrollService
    {
        private readonly TestContext context;
        private readonly ILoggerManager logger;

        public EnrollSerivce(TestContext context, ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Tuple<bool, Enroll> AddEnroll(EnrollAM enrollAM)
        {
            try
            {
                IEnrollBO enroll = new EnrollBO(context, logger);
                return enroll.AddEnroll(enrollAM);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteEnroll(int Id)
        {
            try
            {
                IEnrollBO enroll = new EnrollBO(context, logger);
                return enroll.DeleteEnroll(Id);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ExistEnroll(int Id)
        {
            try
            {
                IEnrollBO enroll = new EnrollBO(context, logger);
                return enroll.ExistEnroll(Id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<EnrollAM> GetAllEnrollsByStudent(int IdStudent)
        {
            try
            {
                IEnrollBO enroll = new EnrollBO(context, logger);
                return enroll.GetAllEnrollsByStudent(IdStudent);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public EnrollAM GetEnroll(int IdStudent, int IdCourse)
        {

            try
            {
                IEnrollBO enroll = new EnrollBO(context, logger);
                return enroll.GetEnroll(IdStudent, IdCourse);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
