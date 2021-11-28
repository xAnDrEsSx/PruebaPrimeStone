using Common.ApplicationModel;
using Common.ApplicationModel.Response;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Test.CoreApi.Model;
using Test.Web.Helpers;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Test.Web.Controllers
{
    public class StudentController : Controller
    {
        readonly ResponseMessages _messages = new();

        [HttpGet]
        public IActionResult Index()
        {
            StudentVM student = new();
            var service = (ResponseModel)WebApi.GetAll("Students", "getStudents");

            if (service.StatusCode == _messages.Code200)
            {
                student.StudentAM = JsonConvert.DeserializeObject<List<StudentAM>>(service.Response.ToString()) as List<StudentAM>;
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult IndexUpdate(int Id)
        {
            StudentVM student = new();

            var _student = (ResponseModel)WebApi.GetById("Students", "getStudentById", Id);
            if (_student.StatusCode == _messages.Code200)
            {
                var itemStudent = JsonConvert.DeserializeObject<StudentAM>(_student.Response.ToString()) as StudentAM;
                student.Id = itemStudent.Id;
                student.DocumentNumber = itemStudent.DocumentNumber;
                student.Name = itemStudent.Name;
                student.LastName = itemStudent.LastName;
                student.Email = itemStudent.Email;
            }

            var ListStudents = (ResponseModel)WebApi.GetAll("Students", "getStudents");
            if (ListStudents.StatusCode == _messages.Code200)
            {
                student.StudentAM = JsonConvert.DeserializeObject<List<StudentAM>>(ListStudents.Response.ToString()) as List<StudentAM>;
            }

            return View("Index", student);
        }

        [HttpPost]
        public IActionResult Index(StudentVM model)
        {
            var data = new StudentAM
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                DocumentNumber = model.DocumentNumber
            };
            var insert = (ResponseModel)WebApi.AddStudent("Students", "addStudent", data);

            return Content(JsonConvert.SerializeObject(
                new
                {
                    statusCode = insert.StatusCode,
                    message = insert.Message
                }), "application/json");
        }

        [HttpPost]
        public IActionResult UpdateStudent(StudentVM model)
        {
            var data = new StudentAM
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                DocumentNumber = model.DocumentNumber
            };

            var update = (ResponseModel)WebApi.UpdateStudent("Students", "updateStudent", data);

            return Content(JsonConvert.SerializeObject(
                new
                {
                    statusCode = update.StatusCode,
                    message = update.Message
                }), "application/json");
        }

        [HttpGet]
        public IActionResult ValidateStudent(int documentNumber)
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
                    statusCode = 400
                }), "application/json");


        }

        [HttpGet]
        public IActionResult DeleteStudent(int Id)
        {
            var service = (ResponseModel)WebApi.DeleteById("Students", "deleteStudent", Id);

            if (service.StatusCode == _messages.Code200)
            {
                return Content(JsonConvert.SerializeObject(
                    new
                    {
                        statusCode = service.StatusCode,
                        message = "Estudiante Eliminado correctamente!"
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
