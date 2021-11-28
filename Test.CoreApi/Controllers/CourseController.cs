#region Imports
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using Common.ApplicationModel.Response;
using Common.Services.Concrete;
using Common.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Test.CoreApi.Model;
using Test.Domain.Administration;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Context;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
#endregion

namespace Test.CoreApi.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        #region Parametros

        public TestContext context;
        public ILoggerManager logger;
        private readonly ICourseService _courseService;
        readonly ResponseMessages _messages = new();

        #endregion

        #region Constructor

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="context"></param>
        public CourseController(TestContext context, ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
            _courseService = new CourseService(context, logger);
        }

        #endregion

        #region EndPoints

        // GET: api/Courses
        //[Authorize]
        [HttpGet("getCourses")]
        [Authorize]
        public Task<ResponseModel> GetCourses()
        {
            var listStudents = _courseService.GetAll();

            if (listStudents != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Courses", _messages.MessageOk),
                    Response = listStudents
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Courses", _messages.MessageNotFound),
                    Response = listStudents
                });
            }

        }


        /// <summary>
        /// Metodo para Obtener un Curso en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getCourseById")]
        [Authorize]
        public Task<ResponseModel> GetSCoursesById(int Id)
        {
            var Students = _courseService.GetCourseById(Id);

            if (Students != null)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Get Course", _messages.MessageOk),
                    Response = Students
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get Course", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Metodo para Crear un Curso
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("addCourse")]
        [Authorize]
        public Task<ResponseModel> AddCourses([FromBody] CourseAM course)
        {
            var insert = _courseService.AddCourse(course);

            if (insert.Item1)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Add Course", _messages.MessageOk),
                    Response = insert.Item2
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Add Course", _messages.MessageFail)
                });
            }

        }


        /// <summary>
        /// Metodo para Actualizar un Curso
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("updateCourse")]
        [Authorize]
        public Task<ResponseModel> UpdateCourse([FromBody] CourseAM course)
        {

            // valida si existe curso a actualizar
            if (_courseService.ExistCourse(course.Id))
            {
                var update = _courseService.UpdateCourse(course);

                if (update.Item1)
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Update Course", _messages.MessageOk),
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
                    Message = String.Concat("Course", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Metodo para Borrar un Curso
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpDelete("deleteCourse")]
        [Authorize]
        public Task<ResponseModel> DeleteCourse(int Id)
        {

            // valida si existe curso a eliminar
            if (_courseService.ExistCourse(Id))
            {
                var update = _courseService.DeleteCourse(Id);

                if (update)
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Delete Course", _messages.MessageOk)
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
                    Message = String.Concat("Course", _messages.MessageNotFound)
                });
            }

        }


        #endregion

    }
}
