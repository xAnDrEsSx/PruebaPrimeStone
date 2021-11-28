using Common.ApplicationModel.Response;
using Common.Services.Concrete;
using Common.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Test.CoreApi.Model;
using Test.Domain.Administration;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Context;

namespace Test.CoreApi.Controllers
{
    [Route("api/Enroll")]
    [ApiController]
    public class EnrollController : Controller
    {

        #region Parametros

        public TestContext context;
        public ILoggerManager logger;
        private readonly IEnrollService _enrollService;
        readonly ResponseMessages _messages = new();

        #endregion

        #region Constructor

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="context"></param>
        public EnrollController(TestContext context,ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
            _enrollService = new EnrollSerivce(context, logger);
        }

        #endregion

        #region EndPoints

        /// <summary>
        /// Metodo para Registrar una Matricula
        /// </summary>
        /// <param name="enroll"></param>
        /// <returns></returns>
        [HttpPost("addEnroll")]
        [Authorize]
        public Task<ResponseModel> AddEnroll([FromBody] EnrollAM enroll)
        {

            var insert = _enrollService.AddEnroll(enroll);

            if (insert.Item1)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Curso Matriculado!", _messages.MessageOk),
                    Response = insert.Item2
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Add Matricula", _messages.MessageFail)
                });
            }

        }


        /// <summary>
        /// Metodo para Borrar un Estudiante
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("deleteEnroll")]
        [Authorize]
        public Task<ResponseModel> DeleteEnroll(int Id)
        {

            // valida si existe matricula a eliminar
            if (_enrollService.ExistEnroll(Id))
            {
                var delete = _enrollService.DeleteEnroll(Id);

                if (delete)
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Delete Matricula", _messages.MessageOk)
                    });

                }
                else
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code400,
                        Message = String.Concat(_messages.MessageFail)
                    });
                }

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Matricula", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Retorna todos los cursos matriculados por un estudiante
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEnrollsByIdStudent")]
        [Authorize]
        public Task<ResponseModel> GetEnrollsByIdStudent(int IdStudent)
        {
            var list = _enrollService.GetAllEnrollsByStudent(IdStudent);

            if (list != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Matriculas", _messages.MessageOk),
                    Response = list
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Students", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Retorna el id de la matricula
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEnroll")]
        [Authorize]
        public Task<ResponseModel> GetEnroll(int IdStudent, int IdCourse)
        {
            var enroll = _enrollService.GetEnroll(IdStudent, IdCourse);

            if (enroll != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Matriculas", _messages.MessageOk),
                    Response = enroll
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Students", _messages.MessageNotFound)
                });
            }

        }



        #endregion

    }
}
