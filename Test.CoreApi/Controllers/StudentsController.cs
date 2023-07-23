#region Imports
using System;
using System.Threading.Tasks;
using Common.ApplicationModel;
using Common.ApplicationModel.Response;
using Common.Services.Concrete;
using Common.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Test.CoreApi.Model;
using Microsoft.AspNetCore.Authorization;
using Test.Domain.Administration;
using Test.Domain.Administration.Context;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
#endregion

namespace Test.CoreApi.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        #region Parametros

        public TestContext context;
        public ILoggerManager logger;
        private readonly IStudentService _studentService;
        readonly ResponseMessages _messages = new();

        #endregion

        #region Constructor

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="context"></param>
        public StudentsController(TestContext context, ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
            _studentService = new StudentService(context,logger);
        }

        #endregion

        #region EndPoints

        // GET: api/Students
        //[Authorize]
        [HttpGet("getStudents")]
        [Authorize]
        public Task<ResponseModel> GetStudents()
        {

            logger.LogInformation("EndPoint /getStudents");
            var listStudents = _studentService.GetAll();

            if (listStudents != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Students", _messages.MessageOk),
                    Response = listStudents
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Students", _messages.MessageNotFound),
                    Response = listStudents
                });
            }

        }


        /// <summary>
        /// Metodo para Obtener un Estudiante en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getStudentById")]
        [Authorize]
        public Task<ResponseModel> GetStudentById(int Id)
        {
            var Students = _studentService.GetStudentById(Id);

            if (Students != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Student", _messages.MessageOk),
                    Response = Students
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Student", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Metodo para Obtener un Estudiante en especifico por # documento
        /// </summary>
        /// <param name="DocumentNumber"></param>
        /// <returns></returns>
        [HttpGet("getStudentByDocumentNumber")]
        [Authorize]
        public Task<ResponseModel> GetStudentByDocumentNumber(int DocumentNumber)
        {
            var Students = _studentService.GetStudentByDocumentNumber(DocumentNumber);

            if (Students != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Student", _messages.MessageOk),
                    Response = Students
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Student", _messages.MessageNotFound)
                });
            }

        }



        /// <summary>
        /// Metodo para Crear un Estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("addStudent")]
        [Authorize]
        public Task<ResponseModel> AddStudent([FromBody] StudentAM student)
        {

            logger.LogInformation(String.Concat("EndPoint /addStudent  Request: ", student));

            // Valida si Existe documento
            if (_studentService.ExistDocument(student.DocumentNumber))
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("El documento ya Existe")
                });
            }

            var insert = _studentService.AddStudent(student);
            logger.LogInformation(String.Concat("EndPoint /addStudent  Response: ", insert.Item2));

            if (insert.Item1)
            {

                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Estudiante Creado!", _messages.MessageOk),
                    Response = insert.Item2
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Add Student", _messages.MessageFail)
                });
            }

        }


        /// <summary>
        /// Metodo para Actualizar un Estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("updateStudent")]
        [Authorize]
        public Task<ResponseModel> UpdateStudent([FromBody] StudentAM student)
        {

            // valida si existe estudiante a actualizar
            if (_studentService.ExistStudent(student.Id))
            {
                var update = _studentService.UpdateStudent(student);

                if (update.Item1)
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Update Student", _messages.MessageOk),
                        Response = update.Item2
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
                    Message = String.Concat("Student", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Metodo para Borrar un Estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpDelete("deleteStudent")]
        [Authorize]
        public Task<ResponseModel> DeleteStudent(int Id)
        {

            // valida si existe estudiante a eliminar
            if (_studentService.ExistStudent(Id))
            {
                var delete = _studentService.DeleteStudent(Id);

                if (delete)
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Delete Student", _messages.MessageOk)
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
                    Message = String.Concat("Student", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Metodo para validar documento
        /// </summary>
        /// <param name="DocumentNumber"></param>
        /// <returns></returns>
        [HttpGet("validateDocumentNumber")]
        [Authorize]
        public Task<ResponseModel> ValidateDocumentNumber(int DocumentNumber)
        {

            if(DocumentNumber > 0)
            {
                if (_studentService.ExistDocument(DocumentNumber))
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Documento ya existe")
                    });
                }
                else
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Documento no existe")
                    });
                }
            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Documento no valido")
                });
            }
            

        }


        #endregion

    }
}
