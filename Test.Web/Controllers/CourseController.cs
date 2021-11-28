using Common.ApplicationModel;
using Common.ApplicationModel.Response;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Test.CoreApi.Model;
using Test.Domain.Administration.ApplicationModel;
using Test.Web.Helpers;
using Test.Web.Helpers.Course;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Test.Web.Controllers
{
    public class CourseController : Controller
    {
        readonly ResponseMessages _messages = new();

        [HttpGet]
        public IActionResult Index()
        {
            CourseVM course = new();
            var service = (ResponseModel)WebApi.GetAll("Course", "getCourses");

            if (service.StatusCode == _messages.Code200)
            {
                course.CourseAM = JsonConvert.DeserializeObject<List<CourseAM>>(service.Response.ToString()) as List<CourseAM>;
            }

            // Fecha por defecto minima establecida
            course.StartDate = DateTime.Now;

            return View(course);
        }


        [HttpPost]
        public IActionResult Index(CourseVM model)
        {
            var data = new CourseAM
            {
                Name = model.Name,
                StartDate = model.StartDate,
                Hours = model.Hours
            };
            var insert = (ResponseModel)WebApi.AddCourse("Course", "addCourse", data);

            return Content(JsonConvert.SerializeObject(
                new
                {
                    statusCode = insert.StatusCode,
                    message = insert.Message
                }), "application/json");
        }

        [HttpGet]
        public IActionResult ValidateStudent(int documentNumber)
        {

            EnrollVM student = new EnrollVM();
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
                    statusCode = 400
                }), "application/json");


        }

        [HttpGet]
        public IActionResult DeleteCourse(int Id)
        {

            var service = (ResponseModel)WebApi.DeleteById("Course", "deleteCourse", Id);

            if (service.StatusCode == _messages.Code200)
            {
                return Content(JsonConvert.SerializeObject(
                    new
                    {
                        statusCode = service.StatusCode,
                        message = "Curso Eliminado correctamente!"
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
