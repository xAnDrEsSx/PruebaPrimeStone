using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Domain.Administration.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public int DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        //public virtual Address Address { get; set; }

    }
}
