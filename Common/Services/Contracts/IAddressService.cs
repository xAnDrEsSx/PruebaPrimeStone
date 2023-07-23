using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Common.Services.Contracts
{
    public interface IAddressService
    {


        /// <summary>
        /// Obtener Direcciones
        /// </summary>
        /// <returns></returns>
        public List<AddressAM> GetAddressByStudent(int Id);

        /// <summary>
        /// Crear un Curso
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Tuple<bool, Address> AddAddress(AddressAM address);
    }
}
