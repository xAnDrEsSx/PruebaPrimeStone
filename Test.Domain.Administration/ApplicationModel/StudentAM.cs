using System.Collections.Generic;
using Test.Domain.Administration.ApplicationModel;

namespace Common.ApplicationModel
{
    public class StudentAM
    {
        public int Id { get; set; } = 0;
        public int DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } = true;
        //public virtual List<AddressAM> Address { get; set; }
    }
}
