using Test.Domain.Administration.ApplicationModel;
using Common.ApplicationModel.Response;
using Nancy.Json;
using Newtonsoft.Json;
using RestSharp;
using System;
using Common.ApplicationModel;
using Microsoft.Extensions.Configuration;

namespace Common.Utilities
{
    public class WebApi
    {
        private static readonly string _baseUri = "https://localhost:44384/api/";

        public WebApi() {}


        #region Generic Serice
        public static object GetAll(string service, string method)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }


        public static object GetById(string service, string method, int Id)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method, "?Id=", Id));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }


        public static object DeleteById(string service, string method, int Id)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method, "?Id=", Id));
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }

        #endregion

        #region Student Service

        public static object AddStudent(string service, string method, StudentAM model)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(model), ParameterType.RequestBody);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }

        public static object GetStudentByDocumentNumber(string service, string method, int param)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method, "?DocumentNumber=", param));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }

        public static object UpdateStudent(string service, string method, StudentAM model)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method));
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", GetToken());
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(model), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }

        #endregion

        #region Course Service

        public static object AddCourse(string service, string method, CourseAM model)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", GetToken());
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(model), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }



        #endregion

        #region Enroll Service

        public static object AddEnroll(string service, string method, EnrollAM model)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", GetToken());
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(model), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }

        public static object GetEnrollsByIdStudent(string service, string method, int Id)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method, "?IdStudent=", Id));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }


        public static object GetEnroll(string service, string method, EnrollAM model)
        {
            var client = new RestClient(String.Concat(_baseUri, service, "/", method, "?IdStudent=", model.IdStudent, "&IdCourse=", model.IdCourse));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", GetToken());
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content) as ResponseModel;
        }





        #endregion

        #region Token
        private static string GetToken()
        {

            var body = @"{" + "\n" + @"    ""Username"": ""Jignesh""," + "\n" + @"    ""EmailAddress"": ""prueba@gmail.com"",
                          " + "\n" + @"    ""KeyPass"":""asdfasd123*850pruebatest""" + "\n" + @"}";

            var client = new RestClient(String.Concat(_baseUri, "login"));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var key = JsonConvert.DeserializeObject<TokenModel>(response.Content) as TokenModel;
            Console.WriteLine(response.Content);
            return String.Concat("Bearer ", key.Token);
        }
        #endregion

    }
}
