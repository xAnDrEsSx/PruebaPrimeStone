using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Domain.Administration.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public string NameAddress { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; }

        #region FK
        [ForeignKey("IdStudent")]
        public virtual Student Student { get; set; }
        #endregion

    }
}
