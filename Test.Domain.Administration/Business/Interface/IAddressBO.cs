using System;
using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;
using Test.Domain.Administration.Entities;

namespace Test.Domain.Administration.Business.Interface
{
    public interface IAddressBO
    {
        public List<AddressAM> GetAddressByStudent(int IdStudent);
        public Tuple<bool, Address> AddAddress(AddressAM addressAM);
    }
}
