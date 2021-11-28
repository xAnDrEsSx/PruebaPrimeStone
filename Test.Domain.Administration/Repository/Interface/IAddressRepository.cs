using System.Collections.Generic;

namespace Test.Domain.Administration.Repository.Interface
{
    public interface IAddressRepository<Address>
    {
        public void Create(Address address);
        //public void Update(Address course);
        //public void Delete(int Id);
        //public ICollection<Address> Get();
        public List<Address> GetById(int IdStudent);
    }
}
