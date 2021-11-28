using Common.ApplicationModel;
using Common.ApplicationModel.Response;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Test.CoreApi.Model;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;
using Test.Web.Helpers;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using Enroll = Test.Domain.Administration.Entities.Enroll;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Test.Web.Controllers
{
    public class EnrollController : Controller
    {
        readonly ResponseMessages _messages = new();

        [HttpGet]
        public IActionResult Index()
        {
            EnrollVM enroll = new();
            return View(enroll);
        }

        /// <summary>
        /// Inserta matricula
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(EnrollRequestVM model)
        {
            var data = new EnrollAM
            {
                IdCourse = model.IdCourse,
                IdStudent = model.IdStudent
            };
            var insert = (ResponseModel)WebApi.AddEnroll("Enroll", "addEnroll", data);

            return Content(JsonConvert.SerializeObject(
                new
                {
                    statusCode = insert.StatusCode,
                    message = insert.Message
                }), "application/json");
        }

        [HttpGet]
        public IActionResult GetStudent(int documentNumber)
        {

            var service = (ResponseModel)WebApi.GetStudentByDocumentNumber("Students", "getStudentByDocumentNumber", documentNumber);

            if (service.StatusCode == _messages.Code200)
            {
                return Content(JsonConvert.SerializeObject(
                    new
                    {
                        statusCode = service.StatusCode,
                        message = "Estudiante ya Existe",
                        response = JsonConvert.DeserializeObject<StudentAM>(service.Response.ToString()) as StudentAM
                    }), "application/json");
            }

            return Content(JsonConvert.SerializeObject(
                new
                {
                    statusCode = 400,
                    message = "Estudiante No encontrado!"
                }), "application/json");


        }


        [HttpGet]
        public IActionResult IndexConsulta(int IdStudent)
        {
            EnrollVM enroll = new();

            // Marca que es la accion cuando se consulto
            enroll.Consult = true;
            List<EnrollAM> enrollList = new();

            // Get Student
            var serviceStudent = (ResponseModel)WebApi.GetById("Students", "getStudentById", IdStudent);
            enroll.StudentAM = JsonConvert.DeserializeObject<StudentAM>(serviceStudent.Response.ToString()) as StudentAM;

            // Obtiene Cursos Disponibles
            var serviceCourse = (ResponseModel)WebApi.GetAll("Course", "getCourses");
            if (serviceCourse.StatusCode == _messages.Code200)
            {
                enroll.ListCourses = JsonConvert.DeserializeObject<List<CourseAM>>(serviceCourse.Response.ToString()) as List<CourseAM>;
            }

            // Obtiene Matriculas
            var serviceEnroll = (ResponseModel)WebApi.GetEnrollsByIdStudent("Enroll", "getEnrollsByIdStudent", IdStudent);
            if (serviceEnroll.StatusCode == _messages.Code200)
            {
                enrollList = JsonConvert.DeserializeObject<List<EnrollAM>>(serviceEnroll.Response.ToString()) as List<EnrollAM>;
            }


            if(enrollList.Count > 0)
            {
                foreach (var Item in enroll.ListCourses)
                {
                    if (enrollList.Find(x => x.IdCourse == Item.Id) == null ? false : true)
                    {
                        Item.Enrolled = "S";
                    }
                }
            }



            return View("Index", enroll);
        }


        [HttpPost]
        public IActionResult DeleteEnroll(EnrollRequestVM model)
        {

            var enrollRequest = new EnrollAM
            {
                IdCourse = model.IdCourse,
                IdStudent = model.IdStudent
            };

            // Get Matricula
            var matricula = (ResponseModel)WebApi.GetEnroll("Enroll", "GetEnroll", enrollRequest);
            var _matricula = JsonConvert.DeserializeObject<EnrollAM>(matricula.Response.ToString()) as EnrollAM;

            if (matricula.StatusCode != _messages.Code200)
            {
                return Content(JsonConvert.SerializeObject(
                    new
                    {
                        statusCode = 400
                    }), "application/json");
            }

            var service = (ResponseModel)WebApi.DeleteById("Enroll", "deleteEnroll", _matricula.Id);

            if (service.StatusCode == _messages.Code200)
            {
                return Content(JsonConvert.SerializeObject(
                    new
                    {
                        statusCode = service.StatusCode,
                        message = "Matricula Eliminado correctamente!"
                    }), "application/json");
            }

            return Content(JsonConvert.SerializeObject(
                new
                {
                    statusCode = 400
                }), "application/json");


        }



    }
}
