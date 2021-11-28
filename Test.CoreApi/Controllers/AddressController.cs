#region Imports
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Common.ApplicationModel.Response;
using Common.Services.Concrete;
using Common.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.CoreApi.Model;
using Test.Domain.Administration;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Context;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
#endregion

namespace Test.CoreApi.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        #region Parametros

        public TestContext context;
        public ILoggerManager logger;
        private readonly IAddressService _addressService;
        readonly ResponseMessages _messages = new();

        #endregion

        #region Constructor

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="context"></param>
        public AddressController(TestContext context,ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;
            _addressService = new AddressService(context, logger);
        }

        #endregion

        #region EndPoints

        /// <summary>
        /// Metodo para Obtener Direcciones de un Estudiante especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getAddressByIdStudent")]
        [Authorize]
        public Task<ResponseModel> GetAddressByIdStudent(int IdStudent)
        {

            var Address = _addressService.GetAddressByStudent(IdStudent);

            if (Address != null)
            {
                if (Address.Count == 0)
                {
                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code400,
                        Message = String.Concat("Address", _messages.MessageNotFound)
                    });
                }
                else
                {


                    return Task.FromResult(new ResponseModel()
                    {
                        StatusCode = _messages.Code200,
                        Message = String.Concat("Get Address", _messages.MessageOk),
                        Response = Address
                    });
                }

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Get User and Address", _messages.MessageNotFound)
                });
            }

        }


        /// <summary>
        /// Metodo para Crear una Direcion
        /// </summary>
        /// <param name = "Address" ></ param >
        /// < returns ></ returns >
        [HttpPost("addAddress")]
        [Authorize]
        public Task<ResponseModel> AddAddress([FromBody] AddressAM address)
        {
            var insert = _addressService.AddAddress(address);

            if (insert.Item1)
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code200,
                    Message = String.Concat("Add address", _messages.MessageOk),
                    Response = insert.Item2
                });

            }
            else
            {
                return Task.FromResult(new ResponseModel()
                {
                    StatusCode = _messages.Code400,
                    Message = String.Concat("Add address", _messages.MessageFail)
                });
            }

        }

        #endregion

    }
}
